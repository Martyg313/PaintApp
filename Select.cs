using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPaintApp
{
    static internal class Select
    {
        static private SKPoint currFirstPoint;
        static private SKPoint currSecondPoint;
        static private SKPoint first, second, third, fourth;

        static public void BeginSelect(SKPoint firstPoint)
        {
            currFirstPoint = firstPoint;
        }

        static public void UpdateSelectPoints(SKPoint secondPoint)
        {
            currSecondPoint = secondPoint;
            computePoints();
        }

        static public void DrawSelect(SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint()
            {
                Color = SKColors.Black,
                StrokeWidth = 1,
                PathEffect = SKPathEffect.CreateDash(new float[] {2, 2}, 0),
            };

            canvas.DrawLine(first, second, paint);
            canvas.DrawLine(fourth, third, paint);
            canvas.DrawLine(first, fourth, paint);
            canvas.DrawLine(second, third, paint);

            // Clip the canvas and relay to code behind


        }

        static private void computePoints()
        {
            first = currFirstPoint;
            second = new SKPoint(currFirstPoint.X + (currSecondPoint.X - currFirstPoint.X), currFirstPoint.Y); // First X
            third = currSecondPoint;
            fourth = new SKPoint(currFirstPoint.X, currFirstPoint.Y + (currSecondPoint.Y - currFirstPoint.Y)); // First y
        }

        static public void ClipCanvas(SKCanvas canvas)
        {
            canvas.ClipRect(new SKRect(currFirstPoint.X + 1, currFirstPoint.Y + 1, currSecondPoint.X, currSecondPoint.Y));
        }

        static public SKRect GetClippedDimensions()
        {
            return new SKRect(currFirstPoint.X + 2, currFirstPoint.Y + 2, currSecondPoint.X - 1, currSecondPoint.Y - 1);
        }
    }
}
