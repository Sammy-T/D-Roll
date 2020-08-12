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
using System.Xml;

namespace D_Roll {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        Random random = new Random();

        private async void RollButton_Click(object sender, RoutedEventArgs e) {
            rollNumLabel.Content = ""; // Clear the roll value
            rollButton.IsEnabled = false; // Disable the roll button to keep from spamming issues

            await Task.Delay(250); // Pause before executing the roll

            XmlElement selectedDice = (XmlElement) diceSelectBox.SelectedItem;
            string diceValue = selectedDice.GetAttribute("Value");

            Console.WriteLine("Rolling a D" + diceValue);

            int diceMaxVal;
            int diceMinVal;

            if (diceValue.Equals("%")) {
                // Keep percentage random integers in the 0-9 range
                diceMaxVal = 10;
                diceMinVal = 0;
            } else {
                diceMaxVal = int.Parse(diceValue) + 1;
                diceMinVal = 1;
            }

            int rollVal = random.Next(diceMinVal, diceMaxVal);

            if (diceValue.Equals("%")) {
                rollVal *= 10; // Multiply the percentage random integer to receive the 0-90(increment of 10) percentage 
            }

            Console.WriteLine("Rolled " + rollVal);

            rollNumLabel.Content = rollVal; // Display the value
            rollButton.IsEnabled = true; // Enable the roll button
        }

        private void DiceSelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rollNumLabel.Content = ""; // Clear the roll value when changing dice
        }
    }
}
