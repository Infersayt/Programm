using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WPFCollage
{
    /// <summary>
    /// Класс - конктретная реализация интерфейса Адаптера для сохранения файла проекта
    /// </summary>
    public class ProjectExportAdapter : IExportAdapter
    {
        public void Save(Collage collage, string fileName)
        {
            // Сохраняем свойства проекта в XML-файл:
            XDocument doc = new XDocument(
                new XElement("CollageProject",
                    new XElement("Name", collage.Name),
                    new XElement("Description", collage.Description),
                    new XElement("Strategy", collage.Strategy.GetPictureCount()),
                    new XElement("PicturesPath", collage.PicturesPath)
                )
            );
            doc.Save(fileName);
        }
    }
}
