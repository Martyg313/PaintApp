using SkiaSharp;

namespace WPFPaintApp
{
    internal class ShapeTool : ITool
    {
        private readonly Document document;
        private ShapeType shapeType;
        private IDrawable? activeShape;
        private bool BeganShape = false;

        public ShapeTool(Document document)
        {
            this.document = document;
        }

        public void OnMouseDown(SKPoint point, SKColor color)
        {
            activeShape = MakeShape.Create(shapeType, color);
            activeShape.BeginPoint(point);
            BeganShape = true;
        }

        public void OnMouseMove(SKPoint point)
        {
            if (BeganShape)
                activeShape?.UpdateEndPoint(point);
        }

        public void OnMouseUp(SKPoint point)
        {
            if (activeShape == null)
                return;

            document.Add(activeShape);
            activeShape = null;
            BeganShape = false;
        }

        public void DrawPreview(SKCanvas canvas)
        {
            activeShape?.Draw(canvas);      
        }

        public void SetShapeType(ShapeType shapeType)
        {
            this.shapeType = shapeType;
        }
    }
}
