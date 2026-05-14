using SkiaSharp;

namespace WPFPaintApp
{
    public class LineShape : IDrawable
    {
        private SKPoint start;
        private SKPoint end;
        private readonly SKColor color;

        public LineShape(SKColor color)
        {
            this.color = color;
        }

        public void BeginPoint(SKPoint point)
        {
            start = point;
            UpdateEndPoint(point);
        }

        public void UpdateEndPoint(SKPoint point)
        {
            end = point;
        }

        public void Draw(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4,
            };

            canvas.DrawLine(start, end, paint);
        }  
    }
}
