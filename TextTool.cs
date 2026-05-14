using SkiaSharp;

namespace WPFPaintApp
{
    internal class TextTool : ITool
    {
        private readonly Document document;
        private readonly AppState state;
        private IDrawable? activeText;

        public TextTool(Document document, AppState state)
        {
            this.document = document;
            this.state = state;
        }

        public void OnMouseDown(SKPoint point, SKColor color)
        {
            activeText = new Text(color, state.ShowTextControlString, state.ShowTextControlsSize);
            activeText.BeginPoint(point);
        }

        public void OnMouseMove(SKPoint point) { }

        public void OnMouseUp(SKPoint point)
        {
            if (activeText == null)
                return;
            document.Add(activeText);
            activeText = null;
        }

        public void DrawPreview(SKCanvas canvas)
        {
            activeText?.Draw(canvas);
        }
    }
}
