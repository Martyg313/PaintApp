using SkiaSharp;

namespace WPFPaintApp
{
    internal class Text : IDrawable
    {
        private SKPoint textLocation;
        private readonly SKColor color;
        private readonly string text;
        private readonly int fontSize;
        
        public Text(SKColor color, string text, int fontSize)
        {
            this.color = color;
            this.text = text;
            this.fontSize = fontSize;
        }

        public void BeginPoint(SKPoint point)
        {
            textLocation = point;
        }

        public void UpdateEndPoint(SKPoint point) { }

        public void Draw(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = color,
                StrokeWidth = 4
            };

            using SKFont font = new SKFont()
            {
                Size = fontSize
            };

            canvas.DrawText(text, textLocation, SKTextAlign.Left, font, paint);
        }
    }
}
