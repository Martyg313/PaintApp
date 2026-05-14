using SkiaSharp;

namespace WPFPaintApp
{
    internal class FillTool : ITool
    {
        private readonly Document document;
        private IDrawable? activeFill;

        public FillTool(Document document)
        {
            this.document = document;
        }   

        public void OnMouseDown(SKPoint point, SKColor color) 
        {
            FloodFill(point, color);
        }

        public void OnMouseMove(SKPoint point) { }

        public void OnMouseUp(SKPoint point) { }

        public void DrawPreview(SKCanvas canvas) 
        {
            activeFill?.Draw(canvas);
        }

        private void FloodFill(SKPoint point, SKColor color)
        {
            SKBitmap fillBitMap = document.BitMap;   // Aliases the document bitmap
            Stack<(int x, int y)> pixels = new Stack<(int x, int y)>();   
            
            (int x, int y) firstPixel = (Convert.ToInt32(point.X), Convert.ToInt32(point.Y));          
            SKColor currentColor = fillBitMap.GetPixel(firstPixel.x, firstPixel.y);

            pixels.Push(firstPixel);
            while (pixels.Count > 0)
            {
                (int x, int y) poppedPixel = pixels.Pop();

                if (0 <= poppedPixel.x && poppedPixel.x < fillBitMap.Width && 0 <= poppedPixel.y && poppedPixel.y < fillBitMap.Height)
                {
                    if (fillBitMap.GetPixel(poppedPixel.x, poppedPixel.y).Equals(currentColor))
                    {
                        //Set the pixel
                        fillBitMap.SetPixel(poppedPixel.x, poppedPixel.y, color);

                        //Add other pixels to stack
                        pixels.Push((poppedPixel.x + 1, poppedPixel.y));
                        pixels.Push((poppedPixel.x, poppedPixel.y + 1));
                        pixels.Push((poppedPixel.x - 1, poppedPixel.y));
                        pixels.Push((poppedPixel.x, poppedPixel.y - 1));
                    }
                }
            }
           
            activeFill = new Fill(fillBitMap);
            document.Add(activeFill);
            activeFill = null;
        }
    }
}
