using System.Drawing;

namespace WPFCollage
{
    /// <summary>
    /// Реализация паттерна Абстрактная Фабрика
    /// </summary>

    public interface IImageFactory
    {
        Image[] GetBitmaps();
    }
}
