using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using SkiaSharp;

namespace WPFPaintApp
{
    internal class AppState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private SKColor selectedColor = SKColors.Black;
        public SKColor SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                OnPropertyChanged();
            }
        }



        private bool showToolButtons = true;
        public bool ShowToolButtons
        {
            get { return showToolButtons; }
            set
            {
                showToolButtons = value;
                OnPropertyChanged();
            }
        }

        private bool showShapeButtons = false;
        public bool ShowShapeButtons
        {
            get { return showShapeButtons; }
            set
            {
                showShapeButtons = value;
                OnPropertyChanged();
            }
        }

        private bool showSelectToolButtons = false;
        public bool ShowSelectToolButtons
        {
            get { return showSelectToolButtons; }
            set
            {
                showSelectToolButtons = value;
                OnPropertyChanged();
            }
        }

        private bool showColorButtons = true;
        public bool ShowColorButtons
        {
            get { return showColorButtons; }
            set
            {
                showColorButtons = value;
                OnPropertyChanged();
            }
        }

        private string showCurrentToolButton = "/Icons/paint-brush.png";
        public string ShowCurrentToolButton
        {
            get { return showCurrentToolButton; }
            set
            {
                showCurrentToolButton = value;
                OnPropertyChanged();
            }
        }

        private Brush showCurrentColorButton = Brushes.Black;
        public Brush ShowCurrentColorButton
        {
            get { return showCurrentColorButton; }
            set
            {
                showCurrentColorButton = value;
                OnPropertyChanged();
            }
        }

        private string showCurrentShapeButton = "/Icons/diagonal-line.png";
        public string ShowCurrentShapeButton
        {
            get { return showCurrentShapeButton; }
            set
            {
                showCurrentShapeButton = value;
                OnPropertyChanged();
            }
        }

        private bool showTextControls = false;
        public bool ShowTextControls
        {
            get { return showTextControls; }
            set
            {
                showTextControls = value;
                OnPropertyChanged();
            }
        }

        private string showTextControlsString = "Text";
        public string ShowTextControlString
        {
            get { return showTextControlsString; }
            set
            {
                showTextControlsString = value;
                OnPropertyChanged();
            }
        }

        private int showTextControlsSize = 12;
        public int ShowTextControlsSize
        {
            get { return showTextControlsSize; }
            set
            {
                showTextControlsSize = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
