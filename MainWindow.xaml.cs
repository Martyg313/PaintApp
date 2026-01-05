using SkiaSharp;
using SkiaSharp.Views.WPF;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace WPFPaintApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Tools
        {
            Brush,
            Select,
            Shape,
            Fill,
            Text,
            Erase,
            None
        }

        private enum Colors
        {
            Red,
            Blue,
            Yellow,
            Green,
            Orange,
            Purple,
            Black,
            White
        }
        

        private int selectedTool = (int)Tools.Brush;
        private int selectedColor = (int)Colors.Black;
        private int lastColor;
        private List<ToggleButton> toolControls;
        private List<ToggleButton> colorControls;
        private bool activeBrush = false;
        private bool activeSelect = false;

        private bool selectedArea = false;

        
        public MainWindow()
        {
            InitializeComponent();
            toolControls = new List<ToggleButton>() {ButtonBrush, ButtonSelect, ButtonShape, ButtonFill, ButtonText, ButtonErase};
            colorControls = new List<ToggleButton>() {ButtonRed, ButtonBlue, ButtonYellow, ButtonGreen, ButtonOrange, ButtonPurple, ButtonBlack};
            lastColor = selectedColor;
        }
     
        private void ClickMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            
        }

        private void ClickMaximize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else 
                WindowState = WindowState.Maximized;
        }

        private void ClickClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ClickBrush(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Brush)
            {
                selectedTool = (int)Tools.Brush;
                selectedColor = lastColor;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }             
            else
                selectedTool = (int)Tools.None;
            toggleOffButtons((int)Tools.Brush);
        }

        private void ClickSelect(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Select)
            {
                selectedTool = (int)Tools.Select;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }         
            else
                selectedTool = (int)Tools.None;
            toggleOffButtons((int)Tools.Select);
        }

        private void ClickShape(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Shape)
            {
                selectedTool = (int)Tools.Shape;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }
            else
                selectedTool = (int)Tools.None;
            toggleOffButtons((int)Tools.Shape);
        }

        private void ClickFill(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Fill)
            {
                selectedTool = (int)Tools.Fill;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }
            else
                selectedTool = (int)Tools.None;
            toggleOffButtons((int)Tools.Fill);
        }

        private void ClickText(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Text)
            {
                selectedTool = (int)Tools.Text;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }
            else
                selectedTool = (int)Tools.None;
            toggleOffButtons((int)Tools.Text);
        }

        private void ClickErase(object sender, RoutedEventArgs e)
        {
            if (selectedTool != (int)Tools.Erase)
            {
                selectedTool = (int)Tools.Erase;
                lastColor = selectedColor;
                selectedColor = (int)Colors.White;

                ButtonRed.Visibility = Visibility.Hidden;
                ButtonBlue.Visibility = Visibility.Hidden;
                ButtonYellow.Visibility = Visibility.Hidden;
                ButtonGreen.Visibility = Visibility.Hidden;
                ButtonOrange.Visibility = Visibility.Hidden;
                ButtonPurple.Visibility = Visibility.Hidden;
                ButtonBlack.Visibility = Visibility.Hidden;
            }              
            else
            {
                selectedTool = (int)Tools.None;

                ButtonRed.Visibility = Visibility.Visible;
                ButtonBlue.Visibility = Visibility.Visible;
                ButtonYellow.Visibility = Visibility.Visible;
                ButtonGreen.Visibility = Visibility.Visible;
                ButtonOrange.Visibility = Visibility.Visible;
                ButtonPurple.Visibility = Visibility.Visible;
                ButtonBlack.Visibility = Visibility.Visible;
            }
               
            toggleOffButtons((int)Tools.Erase);
        }

        private void toggleOffButtons(int toolNum)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i != toolNum)
                    toolControls[i].IsChecked = false;
            }
        }
        

        private void ClickRed(object sender, RoutedEventArgs e)
        {
            ButtonRed.IsChecked = true;
            selectedColor = (int)Colors.Red;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Red);
        }

        private void ClickBlue(object sender, RoutedEventArgs e)
        {
            ButtonBlue.IsChecked = true;
            selectedColor = (int)Colors.Blue;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Blue);
        }

        private void ClickYellow(object sender, RoutedEventArgs e)
        {
            ButtonYellow.IsChecked = true;
            selectedColor = (int)Colors.Yellow;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Yellow);
        }

        private void ClickGreen(object sender, RoutedEventArgs e)
        {
            ButtonGreen.IsChecked = true;
            selectedColor = (int)Colors.Green;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Green);
        }

        private void ClickOrange(object sender, RoutedEventArgs e)
        {
            ButtonOrange.IsChecked = true;
            selectedColor = (int)Colors.Orange;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Orange);
        }

        private void ClickPurple(object sender, RoutedEventArgs e)
        {
            ButtonPurple.IsChecked = true;
            selectedColor = (int)Colors.Purple;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Purple);
        }

        private void ClickBlack(object sender, RoutedEventArgs e)
        {
            ButtonBlack.IsChecked = true;
            selectedColor = (int)Colors.Black;
            lastColor = selectedColor;
            toggleOffColors((int)Colors.Black);
        }

        private void toggleOffColors(int colorNum)
        {
            for (int i = 0; i < 7; i++)
            {
                if (i != colorNum)
                    colorControls[i].IsChecked = false;
            }
        }

        /**
         * 
         */
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        

        private void SkiaCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (selectedTool == (int)Tools.Brush)
            {
                activeBrush = true;
                Drawing.BeginDraw(selectedColor, false);
            }
            else if (selectedTool == (int)Tools.Select)
            {
                activeSelect = true;
                Select.BeginSelect(e.GetPosition(SkiaCanvas).ToSKPoint());
                
                // Hide other ui elements
                ButtonSelect.Visibility = Visibility.Collapsed;
                ButtonShape.Visibility = Visibility.Collapsed;
                ButtonFill.Visibility = Visibility.Collapsed;
                ButtonText.Visibility = Visibility.Collapsed;

                ButtonRed.Visibility = Visibility.Collapsed;
                ButtonBlue.Visibility = Visibility.Collapsed;
                ButtonYellow.Visibility = Visibility.Collapsed;
                ButtonGreen.Visibility = Visibility.Collapsed;
                ButtonOrange.Visibility = Visibility.Collapsed;
                ButtonPurple.Visibility = Visibility.Collapsed;
                ButtonBlack.Visibility = Visibility.Collapsed;
            }
            else if (selectedArea && selectedTool == (int)Tools.Erase)
            {
                activeBrush = true;
                Drawing.BeginDraw(selectedColor, false);
            }
            else if (selectedTool == (int)Tools.Erase)
            {
                activeBrush = true;
                Drawing.BeginDraw(selectedColor, true);
            }
        }

        private void SkiaCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (activeBrush) // Brush is being used
            {
                Drawing.AddPoint(e.GetPosition(SkiaCanvas).ToSKPoint());
                SkiaCanvas.InvalidateVisual();
            }
            else if (activeSelect) // Select is being used
            {
                Select.UpdateSelectPoints(e.GetPosition(SkiaCanvas).ToSKPoint());
                SkiaCanvas.InvalidateVisual();
            }
                
           
        }

        private void SkiaCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (activeBrush)        // If the brush/eraser was just used, show the ui of tools since select might have blocked all other features
            {
                ButtonSelect.Visibility = Visibility.Visible;
                ButtonShape.Visibility = Visibility.Visible;
                ButtonFill.Visibility = Visibility.Visible;
                ButtonText.Visibility = Visibility.Visible;
            }

            activeBrush = false;
            activeSelect = false;       
            SkiaCanvas.InvalidateVisual();

            selectedArea = false;
        }

        private void SkiaCanvasPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {          
            switch (selectedTool)
            {
                case (int)Tools.Brush:
                    if (selectedArea)                           // If the select tool was used, then only draw in the selected area
                    {
                        Select.ClipCanvas(e.Surface.Canvas);    // Constant clipping
                        Drawing.Draw(e.Surface.Canvas);         // Draws all the points but only shows the ones in the clipped area
                        Drawing.constrictStrokesToBounds(Select.GetClippedDimensions());
                    }
                    else
                    {
                        e.Surface.Canvas.Clear();
                        Drawing.Draw(e.Surface.Canvas);    
                    }                
                    break;
                case (int)Tools.Select:
                    e.Surface.Canvas.Clear();                   // Clears the prior selections
                    Drawing.Draw(e.Surface.Canvas);             // Draws all strokes
                    Select.DrawSelect(e.Surface.Canvas);        // Draws the new select box
                    selectedArea = true;                        // The area is now selected, allow next brush stroke to only appear in selected box area
                    break;
                case (int)Tools.Erase:
                    if (selectedArea)                           // If the select tool was used, then only draw in the selected area
                    {
                        Select.ClipCanvas(e.Surface.Canvas);    // Constant clipping
                        Drawing.Draw(e.Surface.Canvas);         // Draws all the points but only shows the ones in the clipped area
                        Drawing.constrictStrokesToBounds(Select.GetClippedDimensions());
                    }
                    else
                    {
                        e.Surface.Canvas.Clear();
                        Drawing.Draw(e.Surface.Canvas);
                    }
                    break;









            }             
        }
    
    }
}