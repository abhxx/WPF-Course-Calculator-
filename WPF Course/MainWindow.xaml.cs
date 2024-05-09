using System;
using System.Windows;

namespace WPF_Course
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// 
        /// when a number is entered then an op then number USE the equal button to show the result
        /// when a number is entered then an op then number THEN AN OP show the result without equal button and USE THE RESULT AS NUM1 AND MAKE A COPY TO NUM3
        ///
        /// </summary>
        double num1;
        double num2;
        
        double res;

       

        

        enum State 
        {
            resultShownByEqual,
            resultShownBySecOP,
            noResult,
        }

        enum LastPressedButton 
        {
            num,
            reSet,
            reStart,
            eqaul,
            OP,
        }

        enum Writing
        {
            writeNum1,
            writeNum2,
        }

        LastPressedButton lastPressedButton;
        
        State resState;
        Writing numState;

        string op;
        public MainWindow()
        {
            InitializeComponent();
            resState = State.noResult;
            numState = Writing.writeNum1;
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("7");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

            AddNumbersFromButtons("4");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("1");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("8");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("5");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("2");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("9");
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("0");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("6");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            AddNumbersFromButtons("3");
        }
        private void dot_Click(object sender, RoutedEventArgs e)
        {//later
            
        }
        private void reStart_Click(object sender, RoutedEventArgs e)
        { /// when CE pressed RESTART EVERYTHING FROM NUMBERS TO RESULT BOX TEXT
            lastPressedButton = LastPressedButton.reStart;
            numState = Writing.writeNum1;
            resState = 0;

            num1 = 0;
            num2 = 0;
            res = 0;
            resultBox.Text = "";
           
            op = "";
        }

        private void reSet_Click(object sender, RoutedEventArgs e)
        {// WHEN C IS PRESSED DELETE THE LAST DIGIT OR OP
           if(lastPressedButton == LastPressedButton.eqaul) 
            {
                num1 = 0;
                numState = Writing.writeNum1;
            }
            lastPressedButton = LastPressedButton.reSet;
            resultBox.Text = "";
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {//when the op is pressed delete the entire line
            SettingOP("+");
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            SettingOP("-");
        }
           
        private void Mlutiply_Click(object sender, RoutedEventArgs e)
        {
            SettingOP("*");
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            SettingOP("/");
        }
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            lastPressedButton = LastPressedButton.eqaul;
            switch (op) 
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
            }
            resultBox.Text = res.ToString();
            resState =State.resultShownByEqual;
            numState = Writing.writeNum2;
            num1 = res;
        }

        private void AddNumbersFromButtons(string buttonNumber) 
        {
            
            lastPressedButton = LastPressedButton.num;
            if (resultBox.Text == "0")
            {
                resultBox.Text = buttonNumber;
            }
            else
            {
                resultBox.Text += buttonNumber;
            }
            if (numState ==Writing.writeNum2)
            {
                num2 = Convert.ToDouble(resultBox.Text);
            }
            else if(numState ==Writing.writeNum1) 
            {
                num1 = Convert.ToDouble(resultBox.Text);
            }
        }
        private void SettingOP(string OP) 
        {
            
            numState = Writing.writeNum2;
            lastPressedButton = LastPressedButton.OP;
            resultBox.Text = "";
            op = OP;
            
        }
    }
}

