using SkiaSharp;

namespace WPFPaintApp
{
    public enum ShapeType
    {
        Line,
        Rectangle,
        Circle,
        Triangle
    }

    public static class MakeShape
    {
        public static IDrawable Create(ShapeType type, SKColor color)
        {
            switch (type)
            {
                case ShapeType.Line:
                    return new LineShape(color);
                case ShapeType.Rectangle:
                    return new RectangleShape(color);
                case ShapeType.Triangle:
                    return new TriangleShape(color);
                case ShapeType.Circle:
                    return new CircleShape(color);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
