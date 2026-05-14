using Microsoft.Win32;
using SkiaSharp;
using System.IO;

namespace WPFPaintApp
{
    internal class Document
    {
        private SKBitmap bitMap = new SKBitmap(1920, 1080);
        public SKBitmap BitMap { get { return bitMap; } }
        private SKCanvas bitMapCanvas = null!;
        private IDrawable? drawnItem;
        

        public void Add(IDrawable item)
        {
            drawnItem = item;
        }

        public void NewWork()
        {
            drawnItem = null;
            bitMapCanvas.Clear(SKColors.White);
        }

        public void SaveWork()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Save Image";//png
            saveFileDialog.FileName = "Untitled.png";
            saveFileDialog.Filter = "PNG Image (*.png) | *.png";

            bool? success = saveFileDialog.ShowDialog();
            
            if (success == true)
            {
                using SKImage image = SKImage.FromBitmap(BitMap);
                using SKData data = image.Encode(SKEncodedImageFormat.Png, 100);
                using FileStream stream = File.OpenWrite(saveFileDialog.FileName);
                data.SaveTo(stream);
            }
        }

        public void OpenWork()
        {
            drawnItem = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";//png
            openFileDialog.Filter = "PNG Image (*.png) | *.png";

            bool? success = openFileDialog.ShowDialog();
            if (success == true)
            {
                string path = openFileDialog.FileName;
                bitMap = SKBitmap.Decode(path);
                bitMapCanvas = new SKCanvas(bitMap);
            }
        }

        public void SetBitMap()
        {
            bitMapCanvas = new SKCanvas(bitMap);
            bitMapCanvas.Clear(SKColors.White);
        }

        public void Draw()
        {
            drawnItem?.Draw(bitMapCanvas);
        }
    }
}
