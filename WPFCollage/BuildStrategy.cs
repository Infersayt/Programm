using System.Drawing;

namespace WPFCollage
{
    // Базовый класс для всех стратегий:
    public abstract class BuildStrategy : IBuildStrategy
    {
        public abstract int GetPictureCount();
        public Image Build(string path)
        {
            // Создаём коллаж из восьми картинок, используя Director (Builder):
            BuilderDirector director = new BuilderDirector();
            return director.Construct(GetPictureCount(), path);
        }        
    }
}
