using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
        }
        private bool check_expression(List<string> expression)
        {
            if (expression.Count % 2 == 0)
                return false;
            for (int i = 0; i < expression.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (!double.TryParse(expression[i], out _))
                        return false;
                }
                else if (!(expression[i] == "+" || expression[i] == "-" || expression[i] == "/" || expression[i] == "*"))
                    return false;
            }


            return true;
        }
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            double result;
            var matches = Regex.Matches(str, @"([*+/\-)(])|([0-9]+)");

            List<string> tokens = new List<string>();
            foreach (Match item in matches)
                tokens.Add(item.Value);

            if (!check_expression(tokens))
            {
                MessageBox.Show("Please try again");
                return;
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "/")
                {
                    double num1 = double.Parse(tokens[i - 1]);
                    double num2 = double.Parse(tokens[i + 1]);
                    result = num1 / num2;
                    tokens.RemoveAt(i + 1);
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i - 1);
                    tokens.Insert(i - 1, result.ToString());
                    i--;
                }
                else if (tokens[i] == "*")
                {
                    double num1 = double.Parse(tokens[i - 1]);
                    double num2 = double.Parse(tokens[i + 1]);
                    result = num1 * num2;
                    tokens.RemoveAt(i + 1);
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i - 1);
                    tokens.Insert(i - 1, result.ToString());
                    i--;
                }
            }

            result = double.Parse(tokens[0]);

            for (int i = 1; i < tokens.Count; i++)
            {
                if (tokens[i] == "+")
                    result += double.Parse(tokens[i + 1]);
                else if (tokens[i] == "-")
                    result -= double.Parse(tokens[i + 1]);
            }


            textBox1.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("+");

        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("-");
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("*");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
