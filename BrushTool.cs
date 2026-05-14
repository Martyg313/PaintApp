using SkiaSharp;

namespace WPFPaintApp
{
    internal class BrushTool : ITool
    {
        private readonly Document document;
        private IDrawable? activeStroke;
        private bool BeganStroke = false;

        public BrushTool(Document document)
        {
            this.document = document;
        }

        public void OnMouseDown(SKPoint point, SKColor color)
        {
            activeStroke = new Stroke(color);
            activeStroke.BeginPoint(point);
            BeganStroke = true;
        }

        public void OnMouseMove(SKPoint point)
        {
            if (BeganStroke) 
                activeStroke?.UpdateEndPoint(point);
        }

        public void OnMouseUp(SKPoint point)
        {
            if (activeStroke == null)
                return;

            document.Add(activeStroke);
            activeStroke = null;     
            BeganStroke = false;
        }

        public void DrawPreview(SKCanvas canvas)
        {
            activeStroke?.Draw(canvas);
        }
    }
}
