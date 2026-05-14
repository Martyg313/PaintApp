using SkiaSharp;

namespace WPFPaintApp
{
    internal class SelectStroke : IDrawable
    {        
        private readonly List<SKPoint> drawingPoints = new List<SKPoint>();
        private readonly SKRect bounds;
        private readonly SKColor color;

        public SelectStroke(SKColor color, SKRect bounds)
        {
            this.color = color;
            this.bounds = bounds;
        }

        public void BeginPoint(SKPoint point)
        {
            drawingPoints.Add(computePoints(point, bounds));
        }

        public void UpdateEndPoint(SKPoint point)
        {
            drawingPoints.Add(computePoints(point, bounds));
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

        private SKPoint computePoints(SKPoint point, SKRect bounds)
        {

            if (point.X <= bounds.Left)
            {
                point.X = bounds.Left + 1;
            }
            if (point.X >= bounds.Right)
            {
                point.X = bounds.Right - 1;
            }

            if (point.Y <= bounds.Top)
            {
                point.Y = bounds.Top + 1;
            }
            if (point.Y >= bounds.Bottom)
            {
                point.Y = bounds.Bottom - 1;
            }

            return point;
        }
    }
}
