using System.Drawing.Imaging;

namespace WPFCollage
{
    public class JpegExportAdaper : IExportAdapter
    {
        public void Save(Collage collage, string fileName)
        {
            collage.Result.Save(fileName, ImageFormat.Jpeg);
        }
    }
}
