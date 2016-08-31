namespace SerialPortTerminal
{
    public partial class MainPresenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.RichTextBox outputTerminal;
        private System.Windows.Forms.TextBox textBoxSendData;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.ComboBox portNamesComboBox;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.RadioButton dataModeOptionHex;
        private System.Windows.Forms.RadioButton dataModeOptionText;
        private System.Windows.Forms.GroupBox dataModeGroupBox;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.Label dataBitsLabel;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.Label stopBitsLabel;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.Button openComPortButton;
        private System.Windows.Forms.GroupBox portSettingsGroupBox;
        private System.Windows.Forms.GroupBox lineSignalsGroupBox;
        private System.Windows.Forms.CheckBox optionCD;
        private System.Windows.Forms.CheckBox optionDsr;
        private System.Windows.Forms.CheckBox optionCts;
        private System.Windows.Forms.CheckBox optionDtr;
        private System.Windows.Forms.CheckBox optionRts;
        private System.Windows.Forms.Button buttonClearTerminal;
        private System.Windows.Forms.CheckBox optionClearOnOpen;
        private System.Windows.Forms.CheckBox optionClearWithDtr;
        private System.Windows.Forms.Timer tmrCheckComPorts;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem itemFile;
        private System.Windows.Forms.ToolStripMenuItem itemHelp;
        private System.Windows.Forms.ToolStripMenuItem showAboutFormButton;
        private System.Windows.Forms.ToolStripMenuItem closeFormButton;
        private System.Windows.Forms.ToolStripMenuItem saveFileButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPresenter));
            this.outputTerminal = new System.Windows.Forms.RichTextBox();
            this.textBoxSendData = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.portNamesComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.dataModeOptionHex = new System.Windows.Forms.RadioButton();
            this.dataModeOptionText = new System.Windows.Forms.RadioButton();
            this.dataModeGroupBox = new System.Windows.Forms.GroupBox();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.parityLabel = new System.Windows.Forms.Label();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.stopBitsLabel = new System.Windows.Forms.Label();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.openComPortButton = new System.Windows.Forms.Button();
            this.portSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.lineSignalsGroupBox = new System.Windows.Forms.GroupBox();
            this.optionRts = new System.Windows.Forms.CheckBox();
            this.optionCD = new System.Windows.Forms.CheckBox();
            this.optionDsr = new System.Windows.Forms.CheckBox();
            this.optionCts = new System.Windows.Forms.CheckBox();
            this.optionDtr = new System.Windows.Forms.CheckBox();
            this.buttonClearTerminal = new System.Windows.Forms.Button();
            this.optionClearOnOpen = new System.Windows.Forms.CheckBox();
            this.optionClearWithDtr = new System.Windows.Forms.CheckBox();
            this.tmrCheckComPorts = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.itemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFormButton = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.showAboutFormButton = new System.Windows.Forms.ToolStripMenuItem();
            this.dataModeGroupBox.SuspendLayout();
            this.portSettingsGroupBox.SuspendLayout();
            this.lineSignalsGroupBox.SuspendLayout();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputTerminal
            // 
            this.outputTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTerminal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTerminal.Location = new System.Drawing.Point(14, 28);
            this.outputTerminal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outputTerminal.Name = "outputTerminal";
            this.outputTerminal.ReadOnly = true;
            this.outputTerminal.Size = new System.Drawing.Size(657, 124);
            this.outputTerminal.TabIndex = 0;
            this.outputTerminal.Text = string.Empty;
            // 
            // textBoxSendData
            // 
            this.textBoxSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSendData.Location = new System.Drawing.Point(66, 161);
            this.textBoxSendData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSendData.Name = "textBoxSendData";
            this.textBoxSendData.Size = new System.Drawing.Size(420, 21);
            this.textBoxSendData.TabIndex = 2;
            this.textBoxSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendDataKeyDown);
            this.textBoxSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataKeyPress);
            // 
            // lblSend
            // 
            this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(12, 165);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(48, 13);
            this.lblSend.TabIndex = 1;
            this.lblSend.Text = "Данни:";
            // 
            // buttonSendData
            // 
            this.buttonSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendData.Location = new System.Drawing.Point(492, 160);
            this.buttonSendData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(87, 22);
            this.buttonSendData.TabIndex = 3;
            this.buttonSendData.Text = "Изпрати";
            this.buttonSendData.UseMnemonic = false;
            this.buttonSendData.Click += new System.EventHandler(this.SendDataButtonClick);
            // 
            // portNamesComboBox
            // 
            this.portNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portNamesComboBox.FormattingEnabled = true;
            this.portNamesComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.portNamesComboBox.Location = new System.Drawing.Point(15, 35);
            this.portNamesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portNamesComboBox.Name = "portNamesComboBox";
            this.portNamesComboBox.Size = new System.Drawing.Size(77, 21);
            this.portNamesComboBox.TabIndex = 1;
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudRateComboBox.Location = new System.Drawing.Point(100, 35);
            this.baudRateComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(80, 21);
            this.baudRateComboBox.TabIndex = 3;
            this.baudRateComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBaudRate);
            // 
            // dataModeOptionHex
            // 
            this.dataModeOptionHex.AutoSize = true;
            this.dataModeOptionHex.Location = new System.Drawing.Point(14, 39);
            this.dataModeOptionHex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataModeOptionHex.Name = "dataModeOptionHex";
            this.dataModeOptionHex.Size = new System.Drawing.Size(47, 17);
            this.dataModeOptionHex.TabIndex = 1;
            this.dataModeOptionHex.Text = "Hex";
            this.dataModeOptionHex.CheckedChanged += new System.EventHandler(this.OptionHexCheckedChanged);
            // 
            // dataModeOptionText
            // 
            this.dataModeOptionText.AutoSize = true;
            this.dataModeOptionText.Location = new System.Drawing.Point(14, 19);
            this.dataModeOptionText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataModeOptionText.Name = "dataModeOptionText";
            this.dataModeOptionText.Size = new System.Drawing.Size(50, 17);
            this.dataModeOptionText.TabIndex = 0;
            this.dataModeOptionText.Text = "Text";
            this.dataModeOptionText.CheckedChanged += new System.EventHandler(this.OptionTextCheckedChanged);
            // 
            // dataModeGroupBox
            // 
            this.dataModeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataModeGroupBox.Controls.Add(this.dataModeOptionText);
            this.dataModeGroupBox.Controls.Add(this.dataModeOptionHex);
            this.dataModeGroupBox.Location = new System.Drawing.Point(453, 187);
            this.dataModeGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataModeGroupBox.Name = "dataModeGroupBox";
            this.dataModeGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataModeGroupBox.Size = new System.Drawing.Size(104, 64);
            this.dataModeGroupBox.TabIndex = 5;
            this.dataModeGroupBox.TabStop = false;
            this.dataModeGroupBox.Text = "Data &Mode";
            // 
            // comPortLabel
            // 
            this.comPortLabel.AutoSize = true;
            this.comPortLabel.Location = new System.Drawing.Point(12, 19);
            this.comPortLabel.Name = "comPortLabel";
            this.comPortLabel.Size = new System.Drawing.Size(66, 13);
            this.comPortLabel.TabIndex = 0;
            this.comPortLabel.Text = "COM Port:";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(97, 19);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(71, 13);
            this.baudRateLabel.TabIndex = 2;
            this.baudRateLabel.Text = "Baud Rate:";
            // 
            // parityLabel
            // 
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(185, 19);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(45, 13);
            this.parityLabel.TabIndex = 4;
            this.parityLabel.Text = "Parity:";
            // 
            // parityComboBox
            // 
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.parityComboBox.Location = new System.Drawing.Point(188, 35);
            this.parityComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(69, 21);
            this.parityComboBox.TabIndex = 5;
            // 
            // dataBitsLabel
            // 
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Location = new System.Drawing.Point(262, 19);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(64, 13);
            this.dataBitsLabel.TabIndex = 6;
            this.dataBitsLabel.Text = "Data Bits:";
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.dataBitsComboBox.Location = new System.Drawing.Point(265, 35);
            this.dataBitsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(69, 21);
            this.dataBitsComboBox.TabIndex = 7;
            this.dataBitsComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateDataBits);
            // 
            // stopBitsLabel
            // 
            this.stopBitsLabel.AutoSize = true;
            this.stopBitsLabel.Location = new System.Drawing.Point(339, 19);
            this.stopBitsLabel.Name = "stopBitsLabel";
            this.stopBitsLabel.Size = new System.Drawing.Size(63, 13);
            this.stopBitsLabel.TabIndex = 8;
            this.stopBitsLabel.Text = "Stop Bits:";
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.stopBitsComboBox.Location = new System.Drawing.Point(342, 35);
            this.stopBitsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(75, 21);
            this.stopBitsComboBox.TabIndex = 9;
            // 
            // openComPortButton
            // 
            this.openComPortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openComPortButton.Location = new System.Drawing.Point(584, 266);
            this.openComPortButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openComPortButton.Name = "openComPortButton";
            this.openComPortButton.Size = new System.Drawing.Size(87, 39);
            this.openComPortButton.TabIndex = 6;
            this.openComPortButton.Text = "Отвори порт";
            this.toolTip.SetToolTip(this.openComPortButton, "Отваряне на порт и изчакване за получаване или изпращане на данни");
            this.openComPortButton.UseMnemonic = false;
            this.openComPortButton.Click += new System.EventHandler(this.OpenPort);
            // 
            // portSettingsGroupBox
            // 
            this.portSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.portSettingsGroupBox.Controls.Add(this.portNamesComboBox);
            this.portSettingsGroupBox.Controls.Add(this.baudRateComboBox);
            this.portSettingsGroupBox.Controls.Add(this.stopBitsComboBox);
            this.portSettingsGroupBox.Controls.Add(this.parityComboBox);
            this.portSettingsGroupBox.Controls.Add(this.dataBitsComboBox);
            this.portSettingsGroupBox.Controls.Add(this.comPortLabel);
            this.portSettingsGroupBox.Controls.Add(this.stopBitsLabel);
            this.portSettingsGroupBox.Controls.Add(this.baudRateLabel);
            this.portSettingsGroupBox.Controls.Add(this.dataBitsLabel);
            this.portSettingsGroupBox.Controls.Add(this.parityLabel);
            this.portSettingsGroupBox.Location = new System.Drawing.Point(14, 187);
            this.portSettingsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portSettingsGroupBox.Name = "portSettingsGroupBox";
            this.portSettingsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portSettingsGroupBox.Size = new System.Drawing.Size(432, 64);
            this.portSettingsGroupBox.TabIndex = 4;
            this.portSettingsGroupBox.TabStop = false;
            this.portSettingsGroupBox.Text = "Настройки на сериен порт";
            // 
            // lineSignalsGroupBox
            // 
            this.lineSignalsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lineSignalsGroupBox.Controls.Add(this.optionRts);
            this.lineSignalsGroupBox.Controls.Add(this.optionCD);
            this.lineSignalsGroupBox.Controls.Add(this.optionDsr);
            this.lineSignalsGroupBox.Controls.Add(this.optionCts);
            this.lineSignalsGroupBox.Controls.Add(this.optionDtr);
            this.lineSignalsGroupBox.Location = new System.Drawing.Point(14, 256);
            this.lineSignalsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineSignalsGroupBox.Name = "lineSignalsGroupBox";
            this.lineSignalsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineSignalsGroupBox.Size = new System.Drawing.Size(317, 48);
            this.lineSignalsGroupBox.TabIndex = 7;
            this.lineSignalsGroupBox.TabStop = false;
            this.lineSignalsGroupBox.Text = "&Line Signals";
            // 
            // optionRts
            // 
            this.optionRts.AutoSize = true;
            this.optionRts.Location = new System.Drawing.Point(76, 20);
            this.optionRts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionRts.Name = "optionRts";
            this.optionRts.Size = new System.Drawing.Size(49, 17);
            this.optionRts.TabIndex = 1;
            this.optionRts.Text = "RTS";
            this.toolTip.SetToolTip(this.optionRts, "Pin 7 on DB9, Output, Request to Send");
            this.optionRts.UseVisualStyleBackColor = true;
            this.optionRts.CheckedChanged += new System.EventHandler(this.OptionRtsCheckedChanged);
            // 
            // optionCD
            // 
            this.optionCD.AutoSize = true;
            this.optionCD.Enabled = false;
            this.optionCD.Location = new System.Drawing.Point(264, 20);
            this.optionCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionCD.Name = "optionCD";
            this.optionCD.Size = new System.Drawing.Size(44, 17);
            this.optionCD.TabIndex = 4;
            this.optionCD.Text = "CD";
            this.toolTip.SetToolTip(this.optionCD, "Pin 1 on DB9, Input, Data Carrier Detect");
            this.optionCD.UseVisualStyleBackColor = true;
            // 
            // optionDsr
            // 
            this.optionDsr.AutoSize = true;
            this.optionDsr.Enabled = false;
            this.optionDsr.Location = new System.Drawing.Point(201, 20);
            this.optionDsr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionDsr.Name = "optionDsr";
            this.optionDsr.Size = new System.Drawing.Size(51, 17);
            this.optionDsr.TabIndex = 3;
            this.optionDsr.Text = "DSR";
            this.toolTip.SetToolTip(this.optionDsr, "Pin 6 on DB9, Input, Data Set Ready");
            this.optionDsr.UseVisualStyleBackColor = true;
            // 
            // optionCts
            // 
            this.optionCts.AutoSize = true;
            this.optionCts.Enabled = false;
            this.optionCts.Location = new System.Drawing.Point(139, 20);
            this.optionCts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionCts.Name = "optionCts";
            this.optionCts.Size = new System.Drawing.Size(50, 17);
            this.optionCts.TabIndex = 2;
            this.optionCts.Text = "CTS";
            this.toolTip.SetToolTip(this.optionCts, "Pin 8 on DB9, Input, Clear to Send");
            this.optionCts.UseVisualStyleBackColor = true;
            // 
            // optionDtr
            // 
            this.optionDtr.AutoSize = true;
            this.optionDtr.Location = new System.Drawing.Point(12, 20);
            this.optionDtr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionDtr.Name = "optionDtr";
            this.optionDtr.Size = new System.Drawing.Size(50, 17);
            this.optionDtr.TabIndex = 0;
            this.optionDtr.Text = "DTR";
            this.toolTip.SetToolTip(this.optionDtr, "Pin 4 on DB9, Output, Data Terminal Ready");
            this.optionDtr.UseVisualStyleBackColor = true;
            this.optionDtr.CheckedChanged += new System.EventHandler(this.OptionDtrCheckedChanged);
            // 
            // buttonClearTerminal
            // 
            this.buttonClearTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearTerminal.Location = new System.Drawing.Point(584, 160);
            this.buttonClearTerminal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClearTerminal.Name = "buttonClearTerminal";
            this.buttonClearTerminal.Size = new System.Drawing.Size(87, 22);
            this.buttonClearTerminal.TabIndex = 9;
            this.buttonClearTerminal.Text = "Изчисти";
            this.buttonClearTerminal.UseMnemonic = false;
            this.buttonClearTerminal.Click += new System.EventHandler(this.ClearTerminalButtonClick);
            // 
            // optionClearOnOpen
            // 
            this.optionClearOnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionClearOnOpen.AutoSize = true;
            this.optionClearOnOpen.Location = new System.Drawing.Point(338, 267);
            this.optionClearOnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionClearOnOpen.Name = "optionClearOnOpen";
            this.optionClearOnOpen.Size = new System.Drawing.Size(224, 17);
            this.optionClearOnOpen.TabIndex = 10;
            this.optionClearOnOpen.Text = "Изчистване при отваряне на порт";
            this.toolTip.SetToolTip(this.optionClearOnOpen, "Изчистване на терминала при отваряне на порт");
            this.optionClearOnOpen.UseVisualStyleBackColor = true;
            // 
            // optionClearWithDtr
            // 
            this.optionClearWithDtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionClearWithDtr.AutoSize = true;
            this.optionClearWithDtr.Location = new System.Drawing.Point(338, 288);
            this.optionClearWithDtr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionClearWithDtr.Name = "optionClearWithDtr";
            this.optionClearWithDtr.Size = new System.Drawing.Size(146, 17);
            this.optionClearWithDtr.TabIndex = 11;
            this.optionClearWithDtr.Text = "Изчистване при DTR";
            this.optionClearWithDtr.UseVisualStyleBackColor = true;
            // 
            // tmrCheckComPorts
            // 
            this.tmrCheckComPorts.Enabled = true;
            this.tmrCheckComPorts.Interval = 500;
            this.tmrCheckComPorts.Tick += new System.EventHandler(this.CheckComPortsTimerTick);
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFile,
            this.itemHelp});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(684, 24);
            this.topMenu.TabIndex = 12;
            this.topMenu.Text = "menuStrip1";
            // 
            // itemFile
            // 
            this.itemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileButton,
            this.closeFormButton});
            this.itemFile.Name = "itemFile";
            this.itemFile.Size = new System.Drawing.Size(48, 20);
            this.itemFile.Text = "Файл";
            // 
            // saveFileButton
            // 
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(155, 22);
            this.saveFileButton.Text = "Запис на файл";
            this.saveFileButton.Click += new System.EventHandler(this.SaveFile);
            // 
            // closeFormButton
            // 
            this.closeFormButton.Name = "closeFormButton";
            this.closeFormButton.Size = new System.Drawing.Size(155, 22);
            this.closeFormButton.Text = "Изход";
            this.closeFormButton.Click += new System.EventHandler(this.CloseForm);
            // 
            // itemHelp
            // 
            this.itemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAboutFormButton});
            this.itemHelp.Name = "itemHelp";
            this.itemHelp.Size = new System.Drawing.Size(62, 20);
            this.itemHelp.Text = "Помощ";
            // 
            // showAboutFormButton
            // 
            this.showAboutFormButton.Name = "showAboutFormButton";
            this.showAboutFormButton.Size = new System.Drawing.Size(155, 22);
            this.showAboutFormButton.Text = "За програмата";
            this.showAboutFormButton.Click += new System.EventHandler(this.ShowAboutMessageBox);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 317);
            this.Controls.Add(this.optionClearWithDtr);
            this.Controls.Add(this.optionClearOnOpen);
            this.Controls.Add(this.buttonClearTerminal);
            this.Controls.Add(this.lineSignalsGroupBox);
            this.Controls.Add(this.portSettingsGroupBox);
            this.Controls.Add(this.openComPortButton);
            this.Controls.Add(this.dataModeGroupBox);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.textBoxSendData);
            this.Controls.Add(this.outputTerminal);
            this.Controls.Add(this.topMenu);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(700, 355);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Port Terminal - Връзка със сериен порт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitApplicaton);
            this.dataModeGroupBox.ResumeLayout(false);
            this.dataModeGroupBox.PerformLayout();
            this.portSettingsGroupBox.ResumeLayout(false);
            this.portSettingsGroupBox.PerformLayout();
            this.lineSignalsGroupBox.ResumeLayout(false);
            this.lineSignalsGroupBox.PerformLayout();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}