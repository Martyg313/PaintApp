using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace WPFPaintApp
{
    static internal class Drawing
    {
        static readonly private  List<List<SKPoint>> drawingPoints = new List<List<SKPoint>>();
        static readonly private  List<int> colorsOfPoints = new List<int>();
        static readonly private  List<bool> sizeOfPoints = new List<bool>();

        static readonly private  Dictionary<int, SKColor> colorsDict = new Dictionary<int, SKColor>()
        {
            {0, SKColors.Red},
            {1, SKColors.Blue},
            {2, SKColors.Yellow},
            {3, SKColors.Green},
            {4, SKColors.Orange},
            {5, SKColors.Purple},
            {6, SKColors.Black},
            {7, SKColors.White}
        };

        static readonly private Dictionary<bool, int> sizeDict = new Dictionary<bool, int>()
        {
            {false, 4},
            {true, 30}
        };

        static public void BeginDraw(int colorNumCurr, bool size)
        {
            drawingPoints.Add(new List<SKPoint>());
            colorsOfPoints.Add(colorNumCurr);
            sizeOfPoints.Add(size);
        }

        static public void AddPoint(SKPoint point)
        {
            drawingPoints.Last().Add(point);
        }

        static public void Draw(SKCanvas canvas)
        {                 
            for (int i = 0; i < drawingPoints.Count; i++)
            {
                using SKPaint paint = new SKPaint()
                {
                    Color = colorsDict[colorsOfPoints[i]],
                    StrokeWidth = sizeDict[sizeOfPoints[i]],             
                };

                //if (colorsDict[colorsOfPoints[i]] == SKColors.White)
                //    paint.StrokeWidth = 30;
              
                for (int j = 1; j < drawingPoints[i].Count; j++)
                {
                    canvas.DrawLine(drawingPoints[i][j - 1], drawingPoints[i][j], paint);
                }
            }
        }


        static public void constrictStrokesToBounds(SKRect bounds)
        {
            for (int i = 0; i < drawingPoints.Last().Count(); i++)
            {
                SKPoint p = drawingPoints.Last()[i];

                if (p.X <= bounds.Left)
                {
                    p.X = bounds.Left + 1;
                }
                if (p.X >= bounds.Right)
                {
                    p.X = bounds.Right - 1;
                }

                if (p.Y <= bounds.Top)
                {
                    p.Y = bounds.Top + 1;
                }
                if (p.Y >= bounds.Bottom)
                {
                    p.Y = bounds.Bottom - 1;
                }

                drawingPoints.Last()[i] = p;
            }
        }
    }
}
