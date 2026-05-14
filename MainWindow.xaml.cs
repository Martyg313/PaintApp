using SkiaSharp;
using SkiaSharp.Views.WPF;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFPaintApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();
        private readonly double targetFrameTime = 1000.0 / 60.0; // 60 FPS

        private readonly AppState state = new AppState();
        private readonly Document document = new Document();

        private readonly BrushTool brushTool;
        private readonly SelectTool selectTool;
        private readonly SelectBrushTool selectBrushTool;
        private readonly ShapeTool shapeTool;
        private readonly FillTool fillTool;
        private readonly TextTool textTool;

        private ITool currentTool;

        public MainWindow()
        {
            InitializeComponent();

            brushTool = new BrushTool(document);
            selectTool = new SelectTool();  
            selectBrushTool = new SelectBrushTool(document, selectTool);
            shapeTool = new ShapeTool(document);
            fillTool = new FillTool(document);
            textTool = new TextTool(document, state);         

            currentTool = brushTool;
            shapeTool.SetShapeType(ShapeType.Line);
            document.SetBitMap();

            CompositionTarget.Rendering += OnRendering;
            DataContext = state;
        }

        private void OnRendering(object? sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds < targetFrameTime)
                return;

            stopwatch.Restart();
            SkiaCanvas.InvalidateVisual();
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
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ClickClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void ClickBrush(object sender, RoutedEventArgs e)
        {
            currentTool = brushTool;
            state.ShowShapeButtons = false;
            state.ShowCurrentToolButton = "/Icons/paint-brush.png";
            state.ShowTextControls = false;
        }

        private void ClickSelect(object sender, RoutedEventArgs e)
        {
            currentTool = selectTool;
            state.ShowShapeButtons = false;
            state.ShowCurrentToolButton = "/Icons/selection-box.png";
            state.ShowTextControls = false;
        }

        private void ClickShape(object sender, RoutedEventArgs e)
        {
            currentTool = shapeTool;
            state.ShowShapeButtons = true;
            state.ShowCurrentToolButton = "/Icons/shapes.png";
            state.ShowTextControls = false;
        }

        private void ClickFill(object sender, RoutedEventArgs e)
        {
            currentTool = fillTool;
            state.ShowShapeButtons = false;
            state.ShowCurrentToolButton = "/Icons/paint-bucket.png";
            state.ShowTextControls = false;
        }
            
        private void ClickText(object sender, RoutedEventArgs e)
        {
            currentTool = textTool;
            state.ShowShapeButtons = false;
            state.ShowCurrentToolButton = "/Icons/text.png";
            state.ShowTextControls = true;
        }

            

        private void ClickRed(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Red;
            state.ShowCurrentColorButton = Brushes.Red;
        }

        private void ClickBlue(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Blue;
            state.ShowCurrentColorButton = Brushes.Blue;
        }

        private void ClickYellow(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Yellow;
            state.ShowCurrentColorButton = Brushes.Yellow;
        }

        private void ClickGreen(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Green;
            state.ShowCurrentColorButton = Brushes.Green;
        }

        private void ClickOrange(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Orange;
            state.ShowCurrentColorButton = Brushes.Orange;
        }

        private void ClickPurple(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Purple;
            state.ShowCurrentColorButton = Brushes.Purple;
        }

        private void ClickBlack(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.Black;
            state.ShowCurrentColorButton = Brushes.Black;
        }

        private void ClickErase(object sender, RoutedEventArgs e)
        {
            state.SelectedColor = SKColors.White;
            state.ShowCurrentColorButton = Brushes.White;
        }



        private void ClickSelectBrush(object sender, RoutedEventArgs e)
        {
            currentTool = selectBrushTool;
            state.ShowCurrentToolButton = "/Icons/paint-brush.png";
        }

        

        private void ClickLine(object sender, RoutedEventArgs e)
        {
            shapeTool.SetShapeType(ShapeType.Line);
            state.ShowCurrentShapeButton = "/Icons/diagonal-line.png";
        }

        private void ClickRectangle(object sender, RoutedEventArgs e)
        {
            shapeTool.SetShapeType(ShapeType.Rectangle);
            state.ShowCurrentShapeButton = "/Icons/rectangle.png";
        }

        private void ClickTriangle(object sender, RoutedEventArgs e)
        {
            shapeTool.SetShapeType(ShapeType.Triangle);
            state.ShowCurrentShapeButton = "/Icons/triangle.png";
        }

        private void ClickCircle(object sender, RoutedEventArgs e)
        {
            shapeTool.SetShapeType(ShapeType.Circle);
            state.ShowCurrentShapeButton = "/Icons/circle.png";
        }



        private void ClickNew(object sender, RoutedEventArgs e)
        {
            document.NewWork();
            SkiaCanvas.InvalidateVisual();
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            document.SaveWork();
        }

        private void ClickOpen(object sender, RoutedEventArgs e)
        {
            document.OpenWork();
        }
        


        private void SkiaCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            currentTool.OnMouseDown(e.GetPosition(SkiaCanvas).ToSKPoint(), state.SelectedColor);
            FlipButtonsForSelectTool(false);
        }

        private void SkiaCanvasMouseMove(object sender, MouseEventArgs e)
        {
            currentTool.OnMouseMove(e.GetPosition(SkiaCanvas).ToSKPoint());
        }

        private void SkiaCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            currentTool.OnMouseUp(e.GetPosition(SkiaCanvas).ToSKPoint());
            FlipButtonsForSelectTool(true);
        }

        /**
         * Render pipeline
         */
        private void SkiaCanvasPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {     
            SKCanvas canvas = e.Surface.Canvas;
            canvas.Clear();

            document.Draw();
            canvas.DrawBitmap(document.BitMap, 0, 0);

            currentTool.DrawPreview(canvas);                    // The new item to be drawn given the current tool
            selectTool.DrawPreview(canvas);
        }

        private void FlipButtonsForSelectTool(bool mouseUp)
        {
            if (currentTool is SelectTool)
            {            
                if (!mouseUp)
                {
                    state.ShowToolButtons = false;
                    state.ShowColorButtons = false;
                }
                else
                {
                    state.ShowSelectToolButtons = true;
                    state.ShowColorButtons = true;
                }
                    
            }
            else if (currentTool is SelectBrushTool)
            {
                if (!mouseUp)
                {
                    state.ShowSelectToolButtons = false;
                    state.ShowColorButtons = false;
                }                         
                else
                {
                    state.ShowToolButtons = true;
                    state.ShowColorButtons = true;
                    currentTool = brushTool;
                }
            }
        } 
    }
}