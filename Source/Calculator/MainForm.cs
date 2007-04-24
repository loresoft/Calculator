using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private JScript.Evalulator _evalulator = new JScript.Evalulator();
        private string _answer = string.Empty;
        private List<string> _history = new List<string>();
        private int _historyIndex = 0;

        private static readonly string[] mathFunctions = new string[] { 
            "abs", "acos", "asin", "atan", "atan2", "ceil", "cos",
            "exp", "floor", "log", "max", "min", "pow", "random",
            "round", "sin", "sqrt", "tan" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && inputTextBox.TextLength > 0)
            {
                Eval(inputTextBox.Text);
                e.Handled = true;
                return;
            }

            if (e.KeyData == Keys.Up && _history.Count > 0)
            {
                _historyIndex--;

                if (_historyIndex < 0)
                    _historyIndex = _history.Count - 1;

                SetInputFromHistory();
                e.Handled = true;
                return;
            }

            if (e.KeyData == Keys.Down && _history.Count > 0)
            {
                _historyIndex++;
                if (_historyIndex >= _history.Count)
                    _historyIndex = 0;

                SetInputFromHistory();
                e.Handled = true;
                return;
            }
        }

        private void SetInputFromHistory()
        {
            inputTextBox.Text = _history[_historyIndex];
            inputTextBox.Select(inputTextBox.TextLength, 0);
            inputTextBox.Focus();
        }

        private void Eval(string input)
        {
            Stopwatch watch = Stopwatch.StartNew();
            string expr = CleanMathFunctions(input);
            string answer = string.Empty;
            bool hasError = false;
            try
            {
                answer = _evalulator.Eval(expr);
            }
            catch (Microsoft.JScript.JScriptException ex)
            {
                hasError = true;
                answer = "Error: " + ex.Message;
            }
            Debug.WriteLine(watch.Elapsed.TotalMilliseconds.ToString() + " ms");

            if (!hasError && !answer.Equals("undefined",
                StringComparison.OrdinalIgnoreCase))
                _answer = answer;

            _history.Add(input);
            _historyIndex = 0;

            historyRichTextBox.SuspendLayout();
            historyRichTextBox.AppendText(input);
            historyRichTextBox.AppendText(Environment.NewLine);
            historyRichTextBox.AppendText("\t");
            historyRichTextBox.AppendText(answer);
            historyRichTextBox.AppendText(Environment.NewLine);
            historyRichTextBox.ResumeLayout();
            inputTextBox.ResetText();
            inputTextBox.Focus();
        }

        private string CleanMathFunctions(string input)
        {
            string result = input;
            foreach (string mathFunction in mathFunctions)
                result = result.Replace(mathFunction + "(", "Math." + mathFunction + "(");

            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            inputTextBox.Focus();
        }
    }
}