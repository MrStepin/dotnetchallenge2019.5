using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FractalTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Brush _brush = Brushes.SteelBlue;

        public MainWindow()
        {
            Loaded += (sender, args) => DrawFractal(new Point(400, 450), 200, Math.PI / 2);
            InitializeComponent();
        }

        private void DrawFractal(Point start, double length, double angle)
        {

            var myLine = new Line
            {
                Stroke = _brush,
                X1 = start.X,
                Y1 = start.Y,
                X2 = start.X + length * Math.Cos(angle),
                Y2 = start.Y - length * Math.Sin(angle),
                StrokeThickness = 1
            };
            canvas.Children.Add(myLine);
            Sleep();
            if (length > 2)
            {
                DrawFractal(new Point(myLine.X2, myLine.Y2), length / 2, (angle + 1));
                DrawFractal(new Point(myLine.X2, myLine.Y2), length / 2, (angle - 1));
            }
            return;
        }

        private void Sleep(int ms = 1)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
            Thread.Sleep(ms);
        }
    }
}
