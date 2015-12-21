using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Spire.Presentation;
using Spire.Presentation.Drawing;
using Spire.Presentation.Drawing.Transition;

namespace WPFCollage
{
    /// <summary>
    /// Класс - конктретная реализация интерфейса Адаптера для экспорта коллажа в PowerPoint
    /// </summary>
    public class PowerPointExportAdapter : IExportAdapter
    {
        public void Save(Collage collage, string fileName)
        {
            // Сохраняем в PowerPoint, сохраняем картинку в первый слайд:
            Presentation ppt = new Presentation();
            ISlide slide = ppt.Slides[0];
            SizeF pptSize = ppt.SlideSize.Size;

            RectangleF logoRect = new RectangleF(10, 10, pptSize.Width, pptSize.Height);

            using (Stream imageStream = new MemoryStream())
            {
                collage.Result.Save(imageStream, ImageFormat.Jpeg);
                imageStream.Position = 0;
                IEmbedImage image = slide.Shapes.AppendEmbedImage(ShapeType.Rectangle, imageStream, logoRect);
                image.Line.FillType = FillFormatType.None;
            }

            slide.SlideShowTransition.Type = TransitionType.Cover;
            ppt.SaveToFile(fileName, FileFormat.Pptx2010);
        }
    }
}
