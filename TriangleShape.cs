using SkiaSharp;

namespace WPFPaintApp
{
    class TriangleShape : IDrawable
    {
        private SKPoint firstPointTri;
        private SKPoint secondPointTri;
        private SKPoint thirdPointTri;
        private readonly SKColor color;

        public TriangleShape(SKColor color)
        {
            this.color = color;
        }

        public void BeginPoint(SKPoint point)
        {
            firstPointTri = point;
            UpdateEndPoint(point);
        }

        public void UpdateEndPoint(SKPoint point)
        {
            secondPointTri = point;
            computePoints();
        }

        public void Draw(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4
            };

            canvas.DrawLine(firstPointTri, secondPointTri, paint);
            canvas.DrawLine(firstPointTri, thirdPointTri, paint);
            canvas.DrawLine(secondPointTri, thirdPointTri, paint);
        }

        private void computePoints()
        {
            float dx = secondPointTri.X - firstPointTri.X;
            float dy = secondPointTri.Y - firstPointTri.Y;

            thirdPointTri = new SKPoint(
                firstPointTri.X + dx * 0.5f - dy * 0.866f,
                firstPointTri.Y + dy * 0.5f + dx * 0.866f
            );
        }
    }
}
