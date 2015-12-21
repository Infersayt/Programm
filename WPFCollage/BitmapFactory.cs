using System.Drawing;
using System.IO;

namespace WPFCollage
{
    /// <summary>
    /// Конкретная реализация абстрактной фабрики для изготовления картинок
    /// </summary>
    public class BitmapFactory : IImageFactory
    {
        string _path;
        int _count;

        private Bitmap CreateEmptyFile()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
            }
            return bitmap;
        }

        public Image[] GetBitmaps()
        {

            Bitmap[] bitmaps = new Bitmap[_count];
            string[] files = Directory.GetFiles(_path, "*.jpg");
            // Возвращаем нужное количество картинок из каталога.
            // Если картинок в каталоге меньше, чем нужно, возвращаем всё что есть, добиваем пустышками
            for (int i = 0; i < _count; i++)
            {                
                if (i < files.Length)
                    bitmaps[i] = new Bitmap(files[i]);
                else
                    bitmaps[i] = CreateEmptyFile();
            }            
            return bitmaps;
        }

        public BitmapFactory(string path, int count)
        {
            _path = path;
            _count = count;
        }
    }

}
