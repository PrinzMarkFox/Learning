using System;
using System.Collections.Generic;
using System.IO;
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

namespace egyszamjatek_graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string filename = "egyszamjatek2.txt";
        List<string> players;

        public MainWindow()
        {
            InitializeComponent();
            Reader();
        }

        private void Reader()
        {
            players = File.ReadAllLines("egyszamjatek2.txt").ToList();
        }

        private void Tbx_Tips_KeyUp(object sender, KeyEventArgs e)
        {
            lb_Count.Content = tbx_Tips.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString() + " db";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = tbx_Name.Text;
            string tips = tbx_Tips.Text;
            string[] actualTips = tbx_Tips.Text.Split(' ');
            string result = String.Empty;

            if (players.Any(p => p.Split(' ')[0] == name))
            {
                MessageBox.Show("Van már ilyen nevű játékos!", "Hiba!");
            }
            else
            {
                if (players.First().Split(' ').Length - 1 != int.Parse(lb_Count.Content.ToString().Split(' ')[0])) //Összeveti az első játékos számsorozatának hosszával a felhasználó által megadott számsorozat hosszával amit a 'label'-ből olvas ki.
                {
                    MessageBox.Show("A tippek száma nem megfelelő!");
                }
                else
                {
                    result = $"{name} {actualTips[0]} {actualTips[1]} {actualTips[2]} {actualTips[3]}";
                    File.AppendAllText(filename, result + Environment.NewLine);
                    MessageBox.Show("Az állomány bővítése sikeres volt!");
                }
            }
        }
    }
}
