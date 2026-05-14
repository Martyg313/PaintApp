using SkiaSharp;

namespace WPFPaintApp
{
    internal class Stroke : IDrawable
    {
        private readonly List<SKPoint> drawingPoints = new List<SKPoint>();
        private readonly SKColor color;

        public Stroke(SKColor color)
        {
            this.color = color;
        }

        public void BeginPoint(SKPoint point)
        {
            drawingPoints.Add(point);
        }

        public void UpdateEndPoint(SKPoint point)
        {
            drawingPoints.Add(point);
        }

        public void Draw(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4
            };

            if (color.Equals(SKColors.White))
            {
                paint.StrokeWidth = 20;
            }

            for (int i = 1; i < drawingPoints.Count; i++)
            {
                canvas.DrawLine(drawingPoints[i - 1], drawingPoints[i], paint);
            }
        }
    }
}
