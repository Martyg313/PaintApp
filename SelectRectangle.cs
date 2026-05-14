using SkiaSharp;

namespace WPFPaintApp
{
    internal class SelectRectangle : IDrawable
    {
        private SKPoint firstPointRect;
        private SKPoint secondPointRect;
        private SKPoint thirdPointRect;
        private SKPoint fourthPointRect;
        private int phaseVal = 0;

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
            phaseVal++;
            if (phaseVal == 40)
                phaseVal = 0;

            using SKPaint paint = new SKPaint()
            {
                Color = SKColors.Black,
                StrokeWidth = 1,
                PathEffect = SKPathEffect.CreateDash(new float[] { 8, 4 }, phaseVal)
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

        public SKRect GetSelectedArea()
        {
            return new SKRect(firstPointRect.X + 2, firstPointRect.Y + 2, fourthPointRect.X - 1, fourthPointRect.Y - 1);
        }
    }
}
