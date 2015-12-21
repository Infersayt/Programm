using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCollage
{
    /// <summary>
    /// Интерфейс для импорта коллажей
    /// </summary>
    interface IImportAdapter
    {
        void Load(Collage collage, string fileName);
    }
}
