using SkiaSharp;

namespace WPFPaintApp
{
    class CircleShape : IDrawable
    {
        private SKPoint firstPointCircle;
        private SKPoint secondPointCircle;
        private float radius;
        private readonly SKColor color;

        public CircleShape(SKColor color)
        {
            this.color = color;
        }

        public void BeginPoint(SKPoint point)
        {
            firstPointCircle = point;
            UpdateEndPoint(point);
        }

        public void UpdateEndPoint(SKPoint point)
        {
            secondPointCircle = point;
            computePoints();
        }

        public void Draw(SKCanvas canvas) 
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4,
                Style = SKPaintStyle.Stroke
            };

            canvas.DrawCircle(firstPointCircle.X, firstPointCircle.Y, radius, paint);
        }

        private void computePoints()
        {
            float dx = secondPointCircle.X - firstPointCircle.X;
            float dy = secondPointCircle.Y - firstPointCircle.Y;

            radius = (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
