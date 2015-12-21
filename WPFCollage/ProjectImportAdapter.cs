using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WPFCollage
{
    /// <summary>
    /// Класс для импорта коллажей из файлов проекта
    /// </summary>
    public class ProjectImportAdapter : IImportAdapter
    {
        public void Load(Collage collage, string fileName)
        {
            // Загружаем свойства из XML-файла:
            XDocument doc = XDocument.Load(fileName);
            collage.Name = doc.Root.Element("Name").Value;
            collage.Description = doc.Root.Element("Description").Value;
            collage.PictureCount = Int32.Parse(doc.Root.Element("Strategy").Value);
            collage.PicturesPath = doc.Root.Element("PicturesPath").Value;
        }
    }
}
