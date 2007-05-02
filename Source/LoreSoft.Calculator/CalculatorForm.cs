using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LoreSoft.Calculator.Properties;
using LoreSoft.MathExpressions;

namespace LoreSoft.Calculator
{
    public partial class CalculatorForm : Form
    {
        private MathEvaluator _eval = new MathEvaluator();
        private List<string> _history = new List<string>();
        private int _historyIndex = 0;
        private Stopwatch watch = new Stopwatch();

        public CalculatorForm()
        {
            InitializeComponent();
            InitializeSettings();
            Application.Idle += new EventHandler(OnApplicationIdle);
        }

        private void InitializeSettings()
        {
            SuspendLayout();
            if (Settings.Default["CalculatorLocation"] != null)
                Location = Settings.Default.CalculatorLocation;
            if (Settings.Default["CalculatorSize"] != null)
                Size = Settings.Default.CalculatorSize;
            if (Settings.Default["CalculatorWindowState"] != null)
                WindowState = Settings.Default.CalculatorWindowState;
            if (Settings.Default["HistoryFont"] != null)
                historyRichTextBox.Font = Settings.Default.HistoryFont;
            if (Settings.Default["InputFont"] != null)
                inputTextBox.Font = Settings.Default.InputFont;

            replaceCalculatorToolStripMenuItem.Checked = (Application.ExecutablePath.Equals(
                ImageFileOptions.GetDebugger(CalculatorConstants.WindowsCalculatorName),
                StringComparison.OrdinalIgnoreCase));

            ResumeLayout(true);
        }

        private void OnApplicationIdle(object sender, EventArgs e)
        {
            numLockToolStripStatusLabel.Text = NativeMethods.IsNumLockOn ? "NUM" : string.Empty;
            answerToolStripStatusLabel.Text = "Answer: " + _eval.Answer;

            undoToolStripMenuItem.Enabled = inputTextBox.ContainsFocus && inputTextBox.CanUndo;
            undoToolStripButton.Enabled = undoToolStripMenuItem.Enabled;
            undoContextStripMenuItem.Enabled = undoToolStripMenuItem.Enabled;

            cutToolStripMenuItem.Enabled = inputTextBox.ContainsFocus && inputTextBox.CanSelect;
            cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled;
            cutContextStripMenuItem.Enabled = cutToolStripMenuItem.Enabled;

            pasteToolStripMenuItem.Enabled = inputTextBox.ContainsFocus && Clipboard.ContainsText();
            pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled;
            pasteContextStripMenuItem.Enabled = pasteToolStripMenuItem.Enabled;
        }

        private void SetInputFromHistory()
        {
            inputTextBox.Text = _history[_historyIndex];
            inputTextBox.Select(inputTextBox.TextLength, 0);
            inputTextBox.Focus();
        }

        private void Eval(string input)
        {
            string answer;
            bool hasError = false;

            watch.Reset();
            watch.Start();
            try
            {
                answer = _eval.Evaluate(input).ToString();
            }
            catch (ParseException ex)
            {
                answer = "Error: " + ex.Message;
                hasError = true;
            }
            watch.Stop();
            timerToolStripStatusLabel.Text = watch.Elapsed.TotalMilliseconds + " ms";

            _history.Add(input);
            _historyIndex = 0;

            historyRichTextBox.SuspendLayout();
            historyRichTextBox.AppendText(input);
            historyRichTextBox.AppendText(Environment.NewLine);
            historyRichTextBox.AppendText("\t");
            if (hasError)
                historyRichTextBox.SelectionColor = Color.Maroon;
            else
                historyRichTextBox.SelectionColor = Color.Blue;
            historyRichTextBox.SelectionFont = new Font(historyRichTextBox.Font, FontStyle.Bold);
            historyRichTextBox.AppendText(answer);
            historyRichTextBox.AppendText(Environment.NewLine);
            historyRichTextBox.ScrollToCaret();
            historyRichTextBox.ResumeLayout();

            inputTextBox.ResetText();
            inputTextBox.Focus();
            inputTextBox.Select();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            inputTextBox.Focus();
            inputTextBox.Select();
        }

        private void CalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.CalculatorLocation = Location;
            Settings.Default.CalculatorSize = Size;
            Settings.Default.CalculatorWindowState = WindowState;
            Settings.Default.HistoryFont = historyRichTextBox.Font;
            Settings.Default.InputFont = inputTextBox.Font;
            Settings.Default.Save();
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

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputTextBox.TextLength != 0 || !OperatorExpression.IsSymbol(e.KeyChar))
                return;

            inputTextBox.Text = MathEvaluator.AnswerVariable + e.KeyChar;
            inputTextBox.Select(inputTextBox.TextLength, 0);
            e.Handled = true;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, historyRichTextBox.Text);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyRichTextBox.ContainsFocus)
                historyRichTextBox.Copy();
            else
                inputTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputTextBox.SelectAll();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyRichTextBox.ResetText();
        }

        private void historyFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = historyRichTextBox.Font;
            DialogResult result = fontDialog.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            historyRichTextBox.Font = fontDialog.Font;
        }

        private void inputFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = inputTextBox.Font;
            DialogResult result = fontDialog.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            inputTextBox.Font = fontDialog.Font;
        }

        private void replaceCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceCalculatorToolStripMenuItem.Checked)
                ImageFileOptions.SetDebugger(
                    CalculatorConstants.WindowsCalculatorName,
                    Application.ExecutablePath);
            else
                ImageFileOptions.ClearDebugger(
                    CalculatorConstants.WindowsCalculatorName);
        }

        private void function_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item == null || item.Tag == null)
                return;

            string insert = item.Tag.ToString();

            int start = inputTextBox.SelectionStart;
            int length = inputTextBox.SelectionLength;
            int pad = insert.IndexOf('|');


            if (pad < 0 && length == 0)
                pad = insert.Length;
            else if (pad >= 0 && length > 0)
                pad = insert.Length;

            inputTextBox.SuspendLayout();
            inputTextBox.Paste(insert.Replace("|", inputTextBox.SelectedText));
            inputTextBox.Select(start + pad + length, 0);
            inputTextBox.ResumeLayout();
        }

    }
}