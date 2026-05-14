using SkiaSharp;

namespace WPFPaintApp
{
    class RectangleShape : IDrawable
    {
        private SKPoint firstPointRect;
        private SKPoint secondPointRect;
        private SKPoint thirdPointRect;
        private SKPoint fourthPointRect;
        private readonly SKColor color;

        public RectangleShape(SKColor color)
        {
            this.color = color;
        }

        public void BeginPoint(SKPoint point)
        {
            firstPointRect = point;
            UpdateEndPoint(point);
        }

        public void UpdateEndPoint(SKPoint point)
        {
            fourthPointRect = point;
            ComputePoints();
        }

        public void Draw(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4
            };

            canvas.DrawLine(firstPointRect, secondPointRect, paint);
            canvas.DrawLine(firstPointRect, thirdPointRect, paint);
            canvas.DrawLine(secondPointRect, fourthPointRect, paint);
            canvas.DrawLine(thirdPointRect, fourthPointRect, paint);
        }

        private void ComputePoints()
        {
            secondPointRect = new SKPoint(firstPointRect.X + (fourthPointRect.X - firstPointRect.X), firstPointRect.Y);
            thirdPointRect = new SKPoint(firstPointRect.X, firstPointRect.Y + (fourthPointRect.Y - firstPointRect.Y));
        }
    }
}
