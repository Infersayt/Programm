using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WPFCollage
{
    /// <summary>
    /// Паттерн Строитель - реализация строителя
    /// </summary>
    public class Builder : IBuilder
    {
        // Константы - ширина и высота картинки - результата:
        private int _width;
        private int _height;
        private Image[] _pictures;

        public Builder(int width, int height, Image[] pictures)
        {
            _width = width;
            _height = height;
            _pictures = pictures;
        }

        public Image Build()
        {
            int count = _pictures.Length;
            int vertOffset = 6;
            int horzOffset = 8;
            // Картинки выстраиваем в две колонки:
            int imageWidth = (_width - 3 * horzOffset) / 2;
            int imageHeight = (_height - (count / 2 + 1) * vertOffset) / (count / 2);
            

            Bitmap image = new Bitmap(_width, _height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                for (int i = 0; i < count; i++)
                {
                    // Расчитываем координаты маленькой картинки внутри большой:
                    int left = horzOffset + (i % 2) * (imageWidth + horzOffset);
                    int top = vertOffset + (i / 2) * (imageHeight + vertOffset);

                    // Картинку перед отрисовкой пропорционально уменьшаем:
                    graphics.DrawImage(_pictures[i], left, top, imageWidth, imageHeight);
                }                
            }
            return image;
        }
    }
}
