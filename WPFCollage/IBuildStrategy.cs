using System.Drawing;

namespace WPFCollage
{
    /// <summary>
    /// Базовый интерфейс стратегии построения коллажей (паттерн Стратегия)
    /// </summary>
    public interface IBuildStrategy
    {
        Image Build(string path);
        // Общий для всех стратегий построения метод - получение количества изображений
        int GetPictureCount();
    }

}
