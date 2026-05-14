using SkiaSharp;

namespace WPFPaintApp
{
    public interface IDrawable
    {
        public void BeginPoint(SKPoint point);
        public void UpdateEndPoint(SKPoint point);
        public void Draw(SKCanvas canvas);
    }
}
