using SkiaSharp;

namespace WPFPaintApp
{
    internal class SelectBrushTool : ITool
    {
        private readonly Document document;
        private readonly SelectTool selectTool;
        private IDrawable? activeSelectStroke;
        private bool BeganSelectStroke = false;

        public SelectBrushTool(Document document, SelectTool selectTool)
        {
            this.document = document;
            this.selectTool = selectTool;
        }

        public void OnMouseDown(SKPoint point, SKColor color)
        {
            activeSelectStroke = new SelectStroke(color, selectTool.ActiveSelectRectangle!.GetSelectedArea());
            activeSelectStroke.BeginPoint(point);
            BeganSelectStroke = true;
        }

        public void OnMouseMove(SKPoint point)
        {
            if (BeganSelectStroke)
                activeSelectStroke?.UpdateEndPoint(point);
        }

        public void OnMouseUp(SKPoint point)
        {
            if (activeSelectStroke == null)
                return;

            document.Add(activeSelectStroke);
            activeSelectStroke = null;
            BeganSelectStroke = false;

            selectTool.ClearSelection();
        }

        public void DrawPreview(SKCanvas canvas)
        {
            activeSelectStroke?.Draw(canvas);
        }
    }
}
