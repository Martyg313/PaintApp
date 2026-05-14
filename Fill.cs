using SkiaSharp;

namespace WPFPaintApp
{
    internal class Fill : IDrawable
    {
        private readonly SKBitmap bitMap;

        public Fill(SKBitmap bitMap)
        {
            this.bitMap = bitMap;
        }

        public void BeginPoint(SKPoint point) { }

        public void UpdateEndPoint(SKPoint point) { }

        public void Draw(SKCanvas canvas)
        {
            canvas.DrawBitmap(bitMap, 0, 0);
        }
    }
}
