using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCollage
{
    /// <summary>
    /// Реализация конкретной стратегии построения коллажа из 4 изображений, (паттерн Стратегия)
    /// </summary>
    public class BuildStrategy4 : BuildStrategy
    {
        public override int GetPictureCount()
        {
            return 4;
        }
    }
}
