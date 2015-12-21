using System.Drawing;

namespace WPFCollage
{

    /// <summary>
    /// Паттерн Строитель - интерфейс директора
    /// </summary>
    public class BuilderDirector
    {
        public Image Construct(int pictureCount, string picturePath)
        {
            // Коллекцию фотографий берём из Абстрактной Фабрики картинок:
            IImageFactory factory = new BitmapFactory(picturePath, pictureCount);
            // Создаём экземпляр Строителя коллажей, в конструкторе передаём картинки, полученные Фабрикой:
            IBuilder builder = new Builder(600, 800, factory.GetBitmaps());
            // Строим коллаж с помощью строителя:
            return builder.Build();
        }

    }

}