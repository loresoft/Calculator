namespace Calculator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.historyPanel = new System.Windows.Forms.Panel();
            this.historyLabel = new System.Windows.Forms.Label();
            this.historyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqrtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.expToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.velocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.millimeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centimeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilometerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ounceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilogramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.celsiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fahrenheitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kelvinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.milePerHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meterPerSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footPerHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilometerPerHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.historyFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuStrip.SuspendLayout();
            this.historyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.functionsToolStripMenuItem,
            this.conversionsToolStripMenuItem,
            this.helpToolStripMenuItem}); 
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(644, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveToolStripMenuItem.Text = "&Save History";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 444);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(644, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // historyPanel
            // 
            this.historyPanel.Controls.Add(this.historyRichTextBox);
            this.historyPanel.Controls.Add(this.historyLabel);
            this.historyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyPanel.Location = new System.Drawing.Point(0, 24);
            this.historyPanel.Name = "historyPanel";
            this.historyPanel.Size = new System.Drawing.Size(644, 420);
            this.historyPanel.TabIndex = 4;
            // 
            // historyLabel
            // 
            this.historyLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.historyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.historyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.historyLabel.Location = new System.Drawing.Point(0, 0);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.historyLabel.Size = new System.Drawing.Size(644, 23);
            this.historyLabel.TabIndex = 0;
            this.historyLabel.Text = "History";
            this.historyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // historyRichTextBox
            // 
            this.historyRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyRichTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyRichTextBox.Location = new System.Drawing.Point(0, 23);
            this.historyRichTextBox.Name = "historyRichTextBox";
            this.historyRichTextBox.ReadOnly = true;
            this.historyRichTextBox.Size = new System.Drawing.Size(644, 397);
            this.historyRichTextBox.TabIndex = 1;
            this.historyRichTextBox.Text = "";
            // 
            // inputLabel
            // 
            this.inputLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.inputLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.inputLabel.Location = new System.Drawing.Point(0, 395);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.inputLabel.Size = new System.Drawing.Size(644, 23);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "Input";
            this.inputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(0, 418);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(644, 26);
            this.inputTextBox.TabIndex = 3;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "F&unctions";
            // 
            // conversionsToolStripMenuItem
            // 
            this.conversionsToolStripMenuItem.Name = "conversionsToolStripMenuItem";
            this.conversionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.conversionsToolStripMenuItem.Text = "&Conversions";
            // 
            // absToolStripMenuItem
            // 
            this.absToolStripMenuItem.Name = "absToolStripMenuItem";
            this.absToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.absToolStripMenuItem.Text = "abs";
            // 
            // sqrtToolStripMenuItem
            // 
            this.sqrtToolStripMenuItem.Name = "sqrtToolStripMenuItem";
            this.sqrtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sqrtToolStripMenuItem.Text = "sqrt";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // cosToolStripMenuItem
            // 
            this.cosToolStripMenuItem.Name = "cosToolStripMenuItem";
            this.cosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cosToolStripMenuItem.Text = "cos";
            // 
            // acosToolStripMenuItem
            // 
            this.acosToolStripMenuItem.Name = "acosToolStripMenuItem";
            this.acosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acosToolStripMenuItem.Text = "acos";
            // 
            // sinToolStripMenuItem
            // 
            this.sinToolStripMenuItem.Name = "sinToolStripMenuItem";
            this.sinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sinToolStripMenuItem.Text = "sin";
            // 
            // asinToolStripMenuItem
            // 
            this.asinToolStripMenuItem.Name = "asinToolStripMenuItem";
            this.asinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.asinToolStripMenuItem.Text = "asin";
            // 
            // tanToolStripMenuItem
            // 
            this.tanToolStripMenuItem.Name = "tanToolStripMenuItem";
            this.tanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tanToolStripMenuItem.Text = "tan";
            // 
            // atanToolStripMenuItem
            // 
            this.atanToolStripMenuItem.Name = "atanToolStripMenuItem";
            this.atanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.atanToolStripMenuItem.Text = "atan";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // expToolStripMenuItem
            // 
            this.expToolStripMenuItem.Name = "expToolStripMenuItem";
            this.expToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expToolStripMenuItem.Text = "exp";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logToolStripMenuItem.Text = "log";
            // 
            // lengthToolStripMenuItem
            // 
            this.lengthToolStripMenuItem.Name = "lengthToolStripMenuItem";
            this.lengthToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lengthToolStripMenuItem.Text = "Length";
            // 
            // massToolStripMenuItem
            // 
            this.massToolStripMenuItem.Name = "massToolStripMenuItem";
            this.massToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.massToolStripMenuItem.Text = "Mass";
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.timeToolStripMenuItem.Text = "Time";
            // 
            // velocityToolStripMenuItem
            // 
            this.velocityToolStripMenuItem.Name = "velocityToolStripMenuItem";
            this.velocityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.velocityToolStripMenuItem.Text = "Velocity";
            // 
            // temperatureToolStripMenuItem
            // 
            this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
            this.temperatureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.temperatureToolStripMenuItem.Text = "Temperature";
            // 
            // inchesToolStripMenuItem
            // 
            this.inchesToolStripMenuItem.Name = "inchesToolStripMenuItem";
            this.inchesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.inchesToolStripMenuItem.Text = "inches (in)";
            // 
            // feetToolStripMenuItem
            // 
            this.feetToolStripMenuItem.Name = "feetToolStripMenuItem";
            this.feetToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.feetToolStripMenuItem.Text = "feet (ft)";
            // 
            // yardToolStripMenuItem
            // 
            this.yardToolStripMenuItem.Name = "yardToolStripMenuItem";
            this.yardToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.yardToolStripMenuItem.Text = "yard (yd)";
            // 
            // mileToolStripMenuItem
            // 
            this.mileToolStripMenuItem.Name = "mileToolStripMenuItem";
            this.mileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.mileToolStripMenuItem.Text = "mile (mile)";
            // 
            // millimeterToolStripMenuItem
            // 
            this.millimeterToolStripMenuItem.Name = "millimeterToolStripMenuItem";
            this.millimeterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.millimeterToolStripMenuItem.Text = "millimeter (mm)";
            // 
            // centimeterToolStripMenuItem
            // 
            this.centimeterToolStripMenuItem.Name = "centimeterToolStripMenuItem";
            this.centimeterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.centimeterToolStripMenuItem.Text = "centimeter (cm)";
            // 
            // meterToolStripMenuItem
            // 
            this.meterToolStripMenuItem.Name = "meterToolStripMenuItem";
            this.meterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.meterToolStripMenuItem.Text = "meter (m)";
            // 
            // kilometerToolStripMenuItem
            // 
            this.kilometerToolStripMenuItem.Name = "kilometerToolStripMenuItem";
            this.kilometerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.kilometerToolStripMenuItem.Text = "kilometer (km)";
            // 
            // poundsToolStripMenuItem
            // 
            this.poundsToolStripMenuItem.Name = "poundsToolStripMenuItem";
            this.poundsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.poundsToolStripMenuItem.Text = "pounds (lb)";
            // 
            // ounceToolStripMenuItem
            // 
            this.ounceToolStripMenuItem.Name = "ounceToolStripMenuItem";
            this.ounceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ounceToolStripMenuItem.Text = "ounce (oz)";
            // 
            // gramsToolStripMenuItem
            // 
            this.gramsToolStripMenuItem.Name = "gramsToolStripMenuItem";
            this.gramsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gramsToolStripMenuItem.Text = "grams (g)";
            // 
            // kilogramsToolStripMenuItem
            // 
            this.kilogramsToolStripMenuItem.Name = "kilogramsToolStripMenuItem";
            this.kilogramsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kilogramsToolStripMenuItem.Text = "kilograms (kg)";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dayToolStripMenuItem.Text = "day (d)";
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.minuteToolStripMenuItem.Text = "minute (min)";
            // 
            // secondToolStripMenuItem
            // 
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.secondToolStripMenuItem.Text = "second (s)";
            // 
            // celsiusToolStripMenuItem
            // 
            this.celsiusToolStripMenuItem.Name = "celsiusToolStripMenuItem";
            this.celsiusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.celsiusToolStripMenuItem.Text = "celsius (c)";
            // 
            // fahrenheitToolStripMenuItem
            // 
            this.fahrenheitToolStripMenuItem.Name = "fahrenheitToolStripMenuItem";
            this.fahrenheitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fahrenheitToolStripMenuItem.Text = "fahrenheit (f)";
            // 
            // kelvinToolStripMenuItem
            // 
            this.kelvinToolStripMenuItem.Name = "kelvinToolStripMenuItem";
            this.kelvinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kelvinToolStripMenuItem.Text = "kelvin (k)";
            // 
            // milePerHourToolStripMenuItem
            // 
            this.milePerHourToolStripMenuItem.Name = "milePerHourToolStripMenuItem";
            this.milePerHourToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.milePerHourToolStripMenuItem.Text = "mile per hour (mi/h)";
            // 
            // meterPerSecondToolStripMenuItem
            // 
            this.meterPerSecondToolStripMenuItem.Name = "meterPerSecondToolStripMenuItem";
            this.meterPerSecondToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.meterPerSecondToolStripMenuItem.Text = "meter per second (m/s)";
            // 
            // footPerHourToolStripMenuItem
            // 
            this.footPerHourToolStripMenuItem.Name = "footPerHourToolStripMenuItem";
            this.footPerHourToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.footPerHourToolStripMenuItem.Text = "foot per hour (ft/h)";
            // 
            // kilometerPerHourToolStripMenuItem
            // 
            this.kilometerPerHourToolStripMenuItem.Name = "kilometerPerHourToolStripMenuItem";
            this.kilometerPerHourToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.kilometerPerHourToolStripMenuItem.Text = "kilometer per hour (km/h)";
            // 
            // knotToolStripMenuItem
            // 
            this.knotToolStripMenuItem.Name = "knotToolStripMenuItem";
            this.knotToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.knotToolStripMenuItem.Text = "knot (knot)";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileName = "History.txt";
            this.saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // historyFontToolStripMenuItem
            // 
            this.historyFontToolStripMenuItem.Name = "historyFontToolStripMenuItem";
            this.historyFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.historyFontToolStripMenuItem.Text = "&History Font...";
            // 
            // inputFontToolStripMenuItem
            // 
            this.inputFontToolStripMenuItem.Name = "inputFontToolStripMenuItem";
            this.inputFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inputFontToolStripMenuItem.Text = "&Input Font...";
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearHistoryToolStripMenuItem.Text = "&Clear History";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 466);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.historyPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.historyPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel historyPanel;
        private System.Windows.Forms.RichTextBox historyRichTextBox;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqrtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem expToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem millimeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centimeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilometerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem velocityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ounceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilogramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem celsiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fahrenheitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kelvinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem milePerHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meterPerSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem footPerHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilometerPerHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knotToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem historyFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputFontToolStripMenuItem;
    }
}

