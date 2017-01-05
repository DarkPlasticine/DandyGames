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

namespace DandyGames_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> styles = new List<string> { "DarkBlue", "DarkOrange" };
            cmbxTheme.SelectionChanged += ThemeChange;
            cmbxTheme.ItemsSource = styles;
            cmbxTheme.SelectedItem = "DarkBlue";
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = cmbxTheme.SelectedItem as string;

            var uri = new Uri(@"Theme\"+ style + @"\Brushes.xaml", UriKind.Relative);
            var core = new Uri(@"Theme\" + style + @"\Core.xaml", UriKind.Relative);

            Application.Current.Resources.Clear();

            ResourceDictionary resCore = Application.LoadComponent(core) as ResourceDictionary;
            ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.MergedDictionaries.Add(resCore);
            Application.Current.Resources.MergedDictionaries.Add(resDict);

            //resDict = Application.LoadComponent(core) as ResourceDictionary;

            //Application.Current.Resources.MergedDictionaries.Add(resDict);
        }
    }
}
