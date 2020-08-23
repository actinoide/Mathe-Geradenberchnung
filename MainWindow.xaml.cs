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

namespace GeradeRechnungenMathe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isParalel;//global variables
        public static bool isIdentical;
        public static bool isCrossing;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (FirstEquationTextbox.Text == "" || SecondEquationTextbox.Text == "") return;//if either textbox is empty it stops the calculations
            string[] firstEquationParts = FirstEquationTextbox.Text.Split('=');//initializing arrays with the content of the textboxes being split
            string[] firstEquationParts2 = firstEquationParts[1].Split('x');
            string[] secondEquationParts = SecondEquationTextbox.Text.Split('=');
            string[] secondEquationParts2 = secondEquationParts[1].Split('x');
            int firstEquationM;//initializing other variables
            int firstEquationB;
            int secondEquationM;
            int secondEquationB;
            double crossingPointY;
            double crossingPointX;
            try
            {
                firstEquationM = Convert.ToInt32(firstEquationParts2[0]);//converts the split up data from string to int
                firstEquationB = Convert.ToInt32(firstEquationParts2[1]);
                secondEquationM = Convert.ToInt32(secondEquationParts2[0]);
                secondEquationB = Convert.ToInt32(secondEquationParts2[1]);
            }
            catch
            {
                return;
            }
            if (firstEquationM == secondEquationM && firstEquationB == secondEquationB)//tests for conditions that show certain relations between the lines
            {
                isIdentical = true;
            }
            else if(firstEquationM == secondEquationM)
            {
                isParalel = true;
            }
            else if(firstEquationM * secondEquationM == -1)
            {
                isCrossing = true;
            }
            if(firstEquationM == secondEquationM)//checks if both ms are equal to avoid dividing by 0 issues
            {
                crossingPointX = 0;//sets the crossing point to 0|0
                crossingPointY = 0;
            }
            else//does the calculation for the crossing point
            {
                crossingPointX = -1 * (firstEquationB - secondEquationB) / (firstEquationM - secondEquationM);
                crossingPointY = (firstEquationM * crossingPointX) + firstEquationB;
            }
            string outputText;//initializing variable
            if (isParalel)//writes output text depending on the relations of the lines determined earlier
            {
                outputText = "die geraden sind paralel und es gibt keinen schnittpunkt";
            }
            else if (isCrossing)
            {
                outputText = "die geraden kreuzen sich im rechten winkel und der schnittpunkt ist" + crossingPointX + "|" + crossingPointY;
            }
            else if (isIdentical)
            {
                outputText = "die geraden sind identisch und kreuzen sich nicht";
            }
            else
            {
                outputText = "die geraden sind nicht parallel zueinander nicht identisch und kreuzen sich nicht im rechten winkel der schnittpunkt ist" + crossingPointX + "|" + crossingPointY;
            }
            OutputTextBlock.Text = outputText;//shows the results in the textblock
            isCrossing = false;//resets the global variables
            isIdentical = false;
            isParalel = false;
        }
    }
}
