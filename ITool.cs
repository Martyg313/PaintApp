using SkiaSharp;

namespace WPFPaintApp
{
    internal interface ITool
    {
        public void OnMouseDown(SKPoint point, SKColor color);
        public void OnMouseMove(SKPoint point);
        public void OnMouseUp(SKPoint point);
        public void DrawPreview(SKCanvas canvas);
    }
}
