using System.Drawing;

namespace WPFCollage
{
    /// <summary>
    /// Паттерн Строитель - интерфейс строителя
    /// </summary>
    interface IBuilder
    {
        Image Build();
    }
}
