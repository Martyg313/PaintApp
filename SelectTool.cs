using SkiaSharp;

namespace WPFPaintApp
{
    internal class SelectTool : ITool
    {
        public SelectRectangle? ActiveSelectRectangle { get; private set; }
        private bool BeganSelect = false;

        public void OnMouseDown(SKPoint point, SKColor color)
        {
            ActiveSelectRectangle = new SelectRectangle();
            ActiveSelectRectangle.BeginPoint(point);
            BeganSelect = true;
        }

        public void OnMouseMove(SKPoint point)
        {
            if (BeganSelect)
                ActiveSelectRectangle?.UpdateEndPoint(point);
        }

        public void OnMouseUp(SKPoint point)
        {
            if (ActiveSelectRectangle == null)
                return;

            BeganSelect = false;  
        }

        public void DrawPreview(SKCanvas canvas)
        {
            ActiveSelectRectangle?.Draw(canvas);
        }

        public void ClearSelection()
        {
            ActiveSelectRectangle = null;
        }
    }
}
