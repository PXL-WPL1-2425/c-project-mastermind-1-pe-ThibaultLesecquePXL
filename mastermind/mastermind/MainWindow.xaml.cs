using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        SolidColorBrush[] colorSelection = [Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.White, Brushes.Yellow, Brushes.Orange];
        string[] colorSelectionString = ["Red", "Blue", "Green", "White", "Yellow", "Orange"];
        int[] colorsRandom = new int[4];

        public MainWindow()
        {
            InitializeComponent();
            pickColors();
            comboBoxItemsInit();
        }

        private void pickColors()
        {
            for (int i = 0; i < colorsRandom.Length; i++)
            {
                colorsRandom[i] = rnd.Next(1, 6);
            }

            this.Title = $"Mastermind ({colorSelectionString[colorsRandom[0]]}, {colorSelectionString[colorsRandom[1]]}, {colorSelectionString[colorsRandom[2]]}, {colorSelectionString[colorsRandom[3]]})";
        }

        private void comboBoxItemsInit()
        {
            color1ComboBox.ItemsSource = colorSelectionString;
            color2ComboBox.ItemsSource = colorSelectionString;
            color3ComboBox.ItemsSource = colorSelectionString;
            color4ComboBox.ItemsSource = colorSelectionString;
        }

        private void ComboBox_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;


            if (comboBox.Name == "color1ComboBox")
            {
                color1Ellipse.Fill = colorSelection[comboBox.SelectedIndex];
            }
            else if (comboBox.Name == "color2ComboBox")
            {
                color2Ellipse.Fill = colorSelection[comboBox.SelectedIndex];
            }
            else if (comboBox.Name == "color3ComboBox")
            {
                color3Ellipse.Fill = colorSelection[comboBox.SelectedIndex];
            }
            else if (comboBox.Name == "color4ComboBox")
            {
                color4Ellipse.Fill = colorSelection[comboBox.SelectedIndex];
            }
            
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            CheckComboBox(color1Ellipse, color1ComboBox, 0);
            CheckComboBox(color2Ellipse, color2ComboBox, 1);
            CheckComboBox(color3Ellipse, color3ComboBox, 2);
            CheckComboBox(color4Ellipse, color4ComboBox, 3);
        }

        private void CheckComboBox(Ellipse elipse, ComboBox combobox, int number)
        {
            elipse.Stroke = Brushes.Black;
            elipse.StrokeThickness = 1;

            if (combobox.SelectedIndex == colorsRandom[number])
            {
                elipse.Stroke = Brushes.DarkRed;
                elipse.StrokeThickness = 5;
            }
            else if (colorsRandom.Contains(combobox.SelectedIndex))
            {
                elipse.Stroke = Brushes.Wheat;
                elipse.StrokeThickness = 5;
            }
        }
    }
}