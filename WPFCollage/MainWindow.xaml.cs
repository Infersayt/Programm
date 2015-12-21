using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.Windows.Forms;
using System.Diagnostics;

namespace WPFCollage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtSourceFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        void Preview(string fileName)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName);
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void ApplyProjectProperties()
        {
            // Назначаем стратегию для формирования коллажа:
            switch (cmbPictureCount.SelectedIndex)
            {
                case 0:
                    Collage.Instance.Strategy = new BuildStrategy4();
                    break;
                case 1:
                    Collage.Instance.Strategy = new BuildStrategy6();
                    break;
                case 2:
                    Collage.Instance.Strategy = new BuildStrategy8();
                    break;
            }
            // Назначаем остальные свойства:
            Collage.Instance.PicturesPath = txtSourceFolder.Text;
            Collage.Instance.Name = txtName.Text;
            Collage.Instance.Description = txtDescription.Text;
        }

        private void ReadProjectProperties()
        {
            // Назначаем стратегию для формирования коллажа:
            switch (Collage.Instance.PictureCount)
            {
                case 4:
                    cmbPictureCount.SelectedIndex = 0;
                    break;
                case 6:
                    cmbPictureCount.SelectedIndex = 1;
                    break;
                case 8:
                    cmbPictureCount.SelectedIndex = 2;
                    break;
            }
            // Назначаем остальные свойства:
            txtSourceFolder.Text = Collage.Instance.PicturesPath;
            txtName.Text = Collage.Instance.Name;
            txtDescription.Text = Collage.Instance.Description;
        }

        private void btnNewProject_Click(object sender, RoutedEventArgs e)
        {
            // Назначаем свойства коллажа:
            ApplyProjectProperties();

            // Формируем коллаж:
            Collage.Instance.BuilCollage();

            // Открываем коллаж для просмотра:
            string tempFileName = Path.GetTempFileName() + ".jpg";
            IExportAdapter adapter = new JpegExportAdaper();
            adapter.Save(Collage.Instance, tempFileName);
            Preview(tempFileName);
        }

        private void btnSelectSourceFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSourceFolder.Text = dialog.SelectedPath;
            }
        }

        private void btnSaveBroject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Файл проекта|*.proj|Изображения JPEG|*.jpg|Презентация PowerPoint|*.pptx";
            dialog.Title = "Сохранить коллаж...";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IExportAdapter adapter = null;
                switch (dialog.FilterIndex)
                {
                    case 1:
                        adapter = new ProjectExportAdapter();
                        break;
                    case 2:
                        adapter = new JpegExportAdaper();
                        break;
                    case 3:
                        adapter = new PowerPointExportAdapter();
                        break;
                }

                if (adapter != null)
                {
                    ApplyProjectProperties();
                    adapter.Save(Collage.Instance, dialog.FileName);
                }

            }
        }

        private void btnLoadProject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файл проекта|*.proj";
            dialog.Title = "Загрузить коллаж...";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IImportAdapter adapter = new ProjectImportAdapter();
                adapter.Load(Collage.Instance, dialog.FileName);
                ReadProjectProperties();
            }
        }
    }
}
