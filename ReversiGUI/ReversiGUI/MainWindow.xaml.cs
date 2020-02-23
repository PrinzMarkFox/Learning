using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReversiGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            InitializeTable();

            Write();
        }

        private void Write()
        {
            foreach (var item in GridGUI.Children)
            {
                if (item is Ellipse)
                {
                    var circle = item as Ellipse;
                    MessageBox.Show(circle.Fill.ToString());
                }
            }
        }

        public void InitializeTable()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var circle = new Ellipse();
                    circle.MouseDown += Circle_Click;
                    circle.Height = 50;
                    circle.Width = 50;
                    circle.Stroke = Brushes.Green;
                    circle.StrokeThickness = 1;
                    circle.SetValue(Grid.ColumnProperty, j);
                    circle.SetValue(Grid.RowProperty, i);
                    GridGUI.Children.Add(circle);
                    var rgb = GenerateColor();
                    circle.Fill = new SolidColorBrush(Color.FromRgb(rgb.Red, rgb.Green,rgb.Blue));
                }
            }
        }
        public MyColor GenerateColor()
        {
            var myColor = new MyColor();
            myColor.Red = (byte)rnd.Next(0,256);
            myColor.Green = (byte)rnd.Next(0, 256);
            myColor.Blue = (byte)rnd.Next(0, 256);

            return myColor;
        }

        private void Circle_Click(object sender, MouseButtonEventArgs e)
        {
            var s = (Ellipse)sender;
            var hexa = s.Fill.ToString();
            mw1.Title = ((SolidColorBrush)new BrushConverter().ConvertFromString(hexa)).Color.ToString();
        }

    }
}
