using DpiConverter.Presenters;

namespace DpiConverter.Presenters
{
    public partial class MainPresenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip uxMenu;
        private System.Windows.Forms.ToolStripMenuItem uxMenuCategoryFile;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemSaveFile;
        private System.Windows.Forms.ListBox uxListBoxStations;
        private System.Windows.Forms.DataGridView uxDataGridViewObservations;
        private System.Windows.Forms.Label uxLabelStations;
        private System.Windows.Forms.Label uxLabelSelectedStation;
        private System.Windows.Forms.TextBox uxTextBoxSelectedStation;
        private System.Windows.Forms.Label uxLabelInstrumentHeight;
        private System.Windows.Forms.TextBox uxTextBoxInstrumentHeight;
        private System.Windows.Forms.CheckBox uxCheckBoxUseStation;
        private System.Windows.Forms.Label uxLabelProgramVersion;
        private System.Windows.Forms.ToolStripMenuItem uxMenuCategoryHelp;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemAbout;
        private System.Windows.Forms.GroupBox uxGroupBoxChangeCode;
        private System.Windows.Forms.Button uxButtonChangeCode;
        private System.Windows.Forms.TextBox uxTextBoxNewCodeValue;
        private System.Windows.Forms.TextBox uxTextBoxOldCodeValue;
        private System.Windows.Forms.Label uxLabelNewCodeValue;
        private System.Windows.Forms.Label uxLabelOldCodeValue;
        private System.Windows.Forms.ToolStripMenuItem uxMenuCategoryEdit;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemChangeSettings;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemExitApplication;
        private System.Windows.Forms.Button uxButtonCalculateIndexErrors;
        private System.Windows.Forms.GroupBox uxGroupBoxChangeRows;
        private System.Windows.Forms.Button uxButtonDeleteSelectedObservations;
        private System.Windows.Forms.Button uxButtonAddNewObservation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem uxMenuItemOpenNewSerialPortTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn horizontalAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn slopeDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn zenithAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn doubleIndexError;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointCode;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPresenter));
            this.uxMenu = new System.Windows.Forms.MenuStrip();
            this.uxMenuCategoryFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.uxMenuItemOpenNewSerialPortTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uxMenuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.uxMenuItemExitApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuCategoryEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuItemChangeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuCategoryHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.uxListBoxStations = new System.Windows.Forms.ListBox();
            this.uxDataGridViewObservations = new System.Windows.Forms.DataGridView();
            this.pointNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horizontalAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slopeDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenithAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doubleIndexError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxLabelStations = new System.Windows.Forms.Label();
            this.uxLabelSelectedStation = new System.Windows.Forms.Label();
            this.uxTextBoxSelectedStation = new System.Windows.Forms.TextBox();
            this.uxLabelInstrumentHeight = new System.Windows.Forms.Label();
            this.uxTextBoxInstrumentHeight = new System.Windows.Forms.TextBox();
            this.uxCheckBoxUseStation = new System.Windows.Forms.CheckBox();
            this.uxLabelProgramVersion = new System.Windows.Forms.Label();
            this.uxGroupBoxChangeCode = new System.Windows.Forms.GroupBox();
            this.uxButtonChangeCode = new System.Windows.Forms.Button();
            this.uxTextBoxNewCodeValue = new System.Windows.Forms.TextBox();
            this.uxTextBoxOldCodeValue = new System.Windows.Forms.TextBox();
            this.uxLabelNewCodeValue = new System.Windows.Forms.Label();
            this.uxLabelOldCodeValue = new System.Windows.Forms.Label();
            this.uxButtonCalculateIndexErrors = new System.Windows.Forms.Button();
            this.uxGroupBoxChangeRows = new System.Windows.Forms.GroupBox();
            this.uxButtonAddNewObservation = new System.Windows.Forms.Button();
            this.uxButtonDeleteSelectedObservations = new System.Windows.Forms.Button();
            this.uxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewObservations)).BeginInit();
            this.uxGroupBoxChangeCode.SuspendLayout();
            this.uxGroupBoxChangeRows.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenu
            // 
            this.uxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuCategoryFile,
            this.uxMenuCategoryEdit,
            this.uxMenuCategoryHelp});
            this.uxMenu.Location = new System.Drawing.Point(0, 0);
            this.uxMenu.Name = "mainMenu";
            this.uxMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.uxMenu.Size = new System.Drawing.Size(752, 24);
            this.uxMenu.TabIndex = 0;
            this.uxMenu.Text = "menuStrip1";
            // 
            // uxMenuCategoryFile
            // 
            this.uxMenuCategoryFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuItemOpenFile,
            this.toolStripSeparator3,
            this.uxMenuItemOpenNewSerialPortTerminal,
            this.toolStripSeparator1,
            this.uxMenuItemSaveFile,
            this.toolStripSeparator2,
            this.uxMenuItemExitApplication});
            this.uxMenuCategoryFile.Name = "fileMenu";
            this.uxMenuCategoryFile.Size = new System.Drawing.Size(48, 20);
            this.uxMenuCategoryFile.Text = "Файл";
            // 
            // uxMenuItemOpenFile
            // 
            this.uxMenuItemOpenFile.Name = "fileOpen";
            this.uxMenuItemOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.uxMenuItemOpenFile.Size = new System.Drawing.Size(169, 22);
            this.uxMenuItemOpenFile.Text = "Отваряне";
            this.uxMenuItemOpenFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // uxMenuItemOpenNewSerialPortTerminal
            // 
            this.uxMenuItemOpenNewSerialPortTerminal.Name = "uxMenuItemOpenNewSerialPortTerminal";
            this.uxMenuItemOpenNewSerialPortTerminal.Size = new System.Drawing.Size(169, 22);
            this.uxMenuItemOpenNewSerialPortTerminal.Text = "Сериен порт";
            this.uxMenuItemOpenNewSerialPortTerminal.Click += new System.EventHandler(this.OpenNewSerialPortTerminalButtonClickedEventHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // uxMenuItemSaveFile
            // 
            this.uxMenuItemSaveFile.Enabled = false;
            this.uxMenuItemSaveFile.Name = "fileSave";
            this.uxMenuItemSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.uxMenuItemSaveFile.Size = new System.Drawing.Size(169, 22);
            this.uxMenuItemSaveFile.Text = "Запис";
            this.uxMenuItemSaveFile.Click += new System.EventHandler(this.SaveFile);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // uxMenuItemExitApplication
            // 
            this.uxMenuItemExitApplication.Name = "fileExit";
            this.uxMenuItemExitApplication.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.uxMenuItemExitApplication.Size = new System.Drawing.Size(169, 22);
            this.uxMenuItemExitApplication.Text = "Изход";
            this.uxMenuItemExitApplication.Click += new System.EventHandler(this.ExitApplication);
            // 
            // uxMenuCategoryEdit
            // 
            this.uxMenuCategoryEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuItemChangeSettings});
            this.uxMenuCategoryEdit.Name = "editMenu";
            this.uxMenuCategoryEdit.Size = new System.Drawing.Size(88, 20);
            this.uxMenuCategoryEdit.Text = "Редактиране";
            // 
            // uxMenuItemChangeSettings
            // 
            this.uxMenuItemChangeSettings.Name = "editSettings";
            this.uxMenuItemChangeSettings.Size = new System.Drawing.Size(134, 22);
            this.uxMenuItemChangeSettings.Text = "Настройки";
            this.uxMenuItemChangeSettings.Click += new System.EventHandler(this.ShowSettingsPresenter);
            // 
            // uxMenuCategoryHelp
            // 
            this.uxMenuCategoryHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuItemAbout});
            this.uxMenuCategoryHelp.Name = "helpMenu";
            this.uxMenuCategoryHelp.Size = new System.Drawing.Size(62, 20);
            this.uxMenuCategoryHelp.Text = "Помощ";
            // 
            // uxMenuItemAbout
            // 
            this.uxMenuItemAbout.Name = "itemAbout";
            this.uxMenuItemAbout.Size = new System.Drawing.Size(155, 22);
            this.uxMenuItemAbout.Text = "За програмата";
            this.uxMenuItemAbout.Click += new System.EventHandler(this.ShowAbountMessage);
            // 
            // uxListBoxStations
            // 
            this.uxListBoxStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxListBoxStations.FormattingEnabled = true;
            this.uxListBoxStations.Location = new System.Drawing.Point(14, 66);
            this.uxListBoxStations.Name = "stationsListBox";
            this.uxListBoxStations.Size = new System.Drawing.Size(139, 368);
            this.uxListBoxStations.TabIndex = 2;
            // 
            // uxDataGridViewObservations
            // 
            this.uxDataGridViewObservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uxDataGridViewObservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.uxDataGridViewObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridViewObservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointNumber,
            this.targetHeight,
            this.horizontalAngle,
            this.slopeDistance,
            this.zenithAngle,
            this.doubleIndexError,
            this.pointCode});
            this.uxDataGridViewObservations.Location = new System.Drawing.Point(161, 66);
            this.uxDataGridViewObservations.Name = "observationsDataGridView";
            this.uxDataGridViewObservations.Size = new System.Drawing.Size(577, 277);
            this.uxDataGridViewObservations.TabIndex = 3;
            this.uxDataGridViewObservations.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EndObservationCellEditEventHandler);
            this.uxDataGridViewObservations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ObservationsDataGridViewDataError);
            // 
            // pointNumber
            // 
            this.pointNumber.DataPropertyName = "FullName";
            this.pointNumber.HeaderText = "Набл. точка";
            this.pointNumber.MaxInputLength = 10;
            this.pointNumber.Name = "pointNumber";
            // 
            // targetHeight
            // 
            this.targetHeight.DataPropertyName = "TargetHeight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.targetHeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.targetHeight.HeaderText = "Височина";
            this.targetHeight.MaxInputLength = 9;
            this.targetHeight.Name = "targetHeight";
            // 
            // horizontalAngle
            // 
            this.horizontalAngle.DataPropertyName = "HorizontalAngle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.horizontalAngle.DefaultCellStyle = dataGridViewCellStyle3;
            this.horizontalAngle.HeaderText = "Хоризонтален ъгъл";
            this.horizontalAngle.MaxInputLength = 9;
            this.horizontalAngle.Name = "horizontalAngle";
            // 
            // slopeDistance
            // 
            this.slopeDistance.DataPropertyName = "SlopeDistance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.slopeDistance.DefaultCellStyle = dataGridViewCellStyle4;
            this.slopeDistance.HeaderText = "Наклонено разстояние";
            this.slopeDistance.MaxInputLength = 9;
            this.slopeDistance.Name = "slopeDistance";
            // 
            // zenithAngle
            // 
            this.zenithAngle.DataPropertyName = "ZenithAngle";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.zenithAngle.DefaultCellStyle = dataGridViewCellStyle5;
            this.zenithAngle.HeaderText = "Зенитен ъгъл";
            this.zenithAngle.MaxInputLength = 9;
            this.zenithAngle.Name = "zenithAngle";
            // 
            // doubleIndexError
            // 
            this.doubleIndexError.DataPropertyName = "VerticalAngleError";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.doubleIndexError.DefaultCellStyle = dataGridViewCellStyle6;
            this.doubleIndexError.HeaderText = "Двойна индексна грешка";
            this.doubleIndexError.MaxInputLength = 10;
            this.doubleIndexError.Name = "doubleIndexError";
            this.doubleIndexError.ReadOnly = true;
            // 
            // pointCode
            // 
            this.pointCode.DataPropertyName = "PointDescription";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointCode.DefaultCellStyle = dataGridViewCellStyle7;
            this.pointCode.HeaderText = "Код";
            this.pointCode.MaxInputLength = 20;
            this.pointCode.Name = "pointCode";
            // 
            // uxLabelStations
            // 
            this.uxLabelStations.AutoSize = true;
            this.uxLabelStations.Location = new System.Drawing.Point(14, 40);
            this.uxLabelStations.Name = "stationsLabel";
            this.uxLabelStations.Size = new System.Drawing.Size(57, 13);
            this.uxLabelStations.TabIndex = 4;
            this.uxLabelStations.Text = "Станции";
            // 
            // uxLabelSelectedStation
            // 
            this.uxLabelSelectedStation.AutoSize = true;
            this.uxLabelSelectedStation.Location = new System.Drawing.Point(158, 40);
            this.uxLabelSelectedStation.Name = "selectedStationLabel";
            this.uxLabelSelectedStation.Size = new System.Drawing.Size(62, 13);
            this.uxLabelSelectedStation.TabIndex = 5;
            this.uxLabelSelectedStation.Text = "Станция:";
            // 
            // uxTextBoxSelectedStation
            // 
            this.uxTextBoxSelectedStation.Location = new System.Drawing.Point(226, 37);
            this.uxTextBoxSelectedStation.MaxLength = 10;
            this.uxTextBoxSelectedStation.Name = "selectedStationTextBox";
            this.uxTextBoxSelectedStation.Size = new System.Drawing.Size(100, 21);
            this.uxTextBoxSelectedStation.TabIndex = 6;
            // 
            // uxLabelInstrumentHeight
            // 
            this.uxLabelInstrumentHeight.AutoSize = true;
            this.uxLabelInstrumentHeight.Location = new System.Drawing.Point(332, 40);
            this.uxLabelInstrumentHeight.Name = "instrumentHeightLabel";
            this.uxLabelInstrumentHeight.Size = new System.Drawing.Size(68, 13);
            this.uxLabelInstrumentHeight.TabIndex = 7;
            this.uxLabelInstrumentHeight.Text = "Височина:";
            // 
            // uxTextBoxInstrumentHeight
            // 
            this.uxTextBoxInstrumentHeight.Location = new System.Drawing.Point(406, 37);
            this.uxTextBoxInstrumentHeight.MaxLength = 9;
            this.uxTextBoxInstrumentHeight.Name = "instrumentHeightTextBox";
            this.uxTextBoxInstrumentHeight.Size = new System.Drawing.Size(100, 21);
            this.uxTextBoxInstrumentHeight.TabIndex = 8;
            this.uxTextBoxInstrumentHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxCheckBoxUseStation
            // 
            this.uxCheckBoxUseStation.AutoSize = true;
            this.uxCheckBoxUseStation.Location = new System.Drawing.Point(512, 40);
            this.uxCheckBoxUseStation.Name = "useStationCheckBox";
            this.uxCheckBoxUseStation.Size = new System.Drawing.Size(94, 17);
            this.uxCheckBoxUseStation.TabIndex = 9;
            this.uxCheckBoxUseStation.Text = "използване";
            this.uxCheckBoxUseStation.UseVisualStyleBackColor = true;
            // 
            // uxLabelProgramVersion
            // 
            this.uxLabelProgramVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLabelProgramVersion.AutoSize = true;
            this.uxLabelProgramVersion.Location = new System.Drawing.Point(659, 421);
            this.uxLabelProgramVersion.Name = "programVersionLabel";
            this.uxLabelProgramVersion.Size = new System.Drawing.Size(81, 13);
            this.uxLabelProgramVersion.TabIndex = 10;
            this.uxLabelProgramVersion.Text = "версия 0.7.3";
            // 
            // uxGroupBoxChangeCode
            // 
            this.uxGroupBoxChangeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxGroupBoxChangeCode.Controls.Add(this.uxButtonChangeCode);
            this.uxGroupBoxChangeCode.Controls.Add(this.uxTextBoxNewCodeValue);
            this.uxGroupBoxChangeCode.Controls.Add(this.uxTextBoxOldCodeValue);
            this.uxGroupBoxChangeCode.Controls.Add(this.uxLabelNewCodeValue);
            this.uxGroupBoxChangeCode.Controls.Add(this.uxLabelOldCodeValue);
            this.uxGroupBoxChangeCode.Location = new System.Drawing.Point(161, 400);
            this.uxGroupBoxChangeCode.Name = "codeEditGroupBox";
            this.uxGroupBoxChangeCode.Size = new System.Drawing.Size(492, 50);
            this.uxGroupBoxChangeCode.TabIndex = 11;
            this.uxGroupBoxChangeCode.TabStop = false;
            this.uxGroupBoxChangeCode.Text = "Преименуване на кодове";
            // 
            // uxButtonChangeCode
            // 
            this.uxButtonChangeCode.Location = new System.Drawing.Point(357, 18);
            this.uxButtonChangeCode.Name = "codeEditButton";
            this.uxButtonChangeCode.Size = new System.Drawing.Size(86, 23);
            this.uxButtonChangeCode.TabIndex = 4;
            this.uxButtonChangeCode.Text = "Промени";
            this.uxButtonChangeCode.UseVisualStyleBackColor = true;
            this.uxButtonChangeCode.Click += new System.EventHandler(this.ChangePointCode);
            // 
            // uxTextBoxNewCodeValue
            // 
            this.uxTextBoxNewCodeValue.Location = new System.Drawing.Point(250, 20);
            this.uxTextBoxNewCodeValue.Name = "newCodeTextBox";
            this.uxTextBoxNewCodeValue.Size = new System.Drawing.Size(100, 21);
            this.uxTextBoxNewCodeValue.TabIndex = 3;
            // 
            // uxTextBoxOldCodeValue
            // 
            this.uxTextBoxOldCodeValue.Location = new System.Drawing.Point(78, 20);
            this.uxTextBoxOldCodeValue.Name = "oldCodeTextBox";
            this.uxTextBoxOldCodeValue.Size = new System.Drawing.Size(100, 21);
            this.uxTextBoxOldCodeValue.TabIndex = 2;
            // 
            // uxLabelNewCodeValue
            // 
            this.uxLabelNewCodeValue.AutoSize = true;
            this.uxLabelNewCodeValue.Location = new System.Drawing.Point(184, 23);
            this.uxLabelNewCodeValue.Name = "newCodeLabel";
            this.uxLabelNewCodeValue.Size = new System.Drawing.Size(60, 13);
            this.uxLabelNewCodeValue.TabIndex = 1;
            this.uxLabelNewCodeValue.Text = "Нов код:";
            // 
            // uxLabelOldCodeValue
            // 
            this.uxLabelOldCodeValue.AutoSize = true;
            this.uxLabelOldCodeValue.Location = new System.Drawing.Point(6, 23);
            this.uxLabelOldCodeValue.Name = "oldCodeLabel";
            this.uxLabelOldCodeValue.Size = new System.Drawing.Size(66, 13);
            this.uxLabelOldCodeValue.TabIndex = 0;
            this.uxLabelOldCodeValue.Text = "Стар код:";
            // 
            // uxButtonCalculateIndexErrors
            // 
            this.uxButtonCalculateIndexErrors.Location = new System.Drawing.Point(612, 35);
            this.uxButtonCalculateIndexErrors.Name = "calculateIndexErrorsButton";
            this.uxButtonCalculateIndexErrors.Size = new System.Drawing.Size(126, 23);
            this.uxButtonCalculateIndexErrors.TabIndex = 12;
            this.uxButtonCalculateIndexErrors.Text = "Индексна грешка";
            this.uxButtonCalculateIndexErrors.UseVisualStyleBackColor = true;
            this.uxButtonCalculateIndexErrors.Click += new System.EventHandler(this.CalculateVerticalAngleErrorButtonClickedEventHandler);
            // 
            // uxGroupBoxChangeRows
            // 
            this.uxGroupBoxChangeRows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxGroupBoxChangeRows.Controls.Add(this.uxButtonAddNewObservation);
            this.uxGroupBoxChangeRows.Controls.Add(this.uxButtonDeleteSelectedObservations);
            this.uxGroupBoxChangeRows.Location = new System.Drawing.Point(161, 349);
            this.uxGroupBoxChangeRows.Name = "rowsEditGroupBox";
            this.uxGroupBoxChangeRows.Size = new System.Drawing.Size(492, 45);
            this.uxGroupBoxChangeRows.TabIndex = 13;
            this.uxGroupBoxChangeRows.TabStop = false;
            this.uxGroupBoxChangeRows.Text = "Редактиране на измервания";
            // 
            // uxButtonAddNewObservation
            // 
            this.uxButtonAddNewObservation.Location = new System.Drawing.Point(95, 16);
            this.uxButtonAddNewObservation.Name = "uxButtonAddNewObservation";
            this.uxButtonAddNewObservation.Size = new System.Drawing.Size(80, 23);
            this.uxButtonAddNewObservation.TabIndex = 1;
            this.uxButtonAddNewObservation.Text = "Добавяне";
            this.uxButtonAddNewObservation.UseVisualStyleBackColor = true;
            this.uxButtonAddNewObservation.Click += new System.EventHandler(this.AddNewObservationButtonClickedEventHandler);
            // 
            // uxButtonDeleteSelectedObservations
            // 
            this.uxButtonDeleteSelectedObservations.Location = new System.Drawing.Point(9, 16);
            this.uxButtonDeleteSelectedObservations.Name = "uxButtonDeleteSelectedObservations";
            this.uxButtonDeleteSelectedObservations.Size = new System.Drawing.Size(80, 23);
            this.uxButtonDeleteSelectedObservations.TabIndex = 0;
            this.uxButtonDeleteSelectedObservations.Text = "Изтриване";
            this.uxButtonDeleteSelectedObservations.UseVisualStyleBackColor = true;
            this.uxButtonDeleteSelectedObservations.Click += new System.EventHandler(this.DeleteSelectedObservationsButtonClickedEventHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 462);
            this.Controls.Add(this.uxGroupBoxChangeRows);
            this.Controls.Add(this.uxButtonCalculateIndexErrors);
            this.Controls.Add(this.uxGroupBoxChangeCode);
            this.Controls.Add(this.uxLabelProgramVersion);
            this.Controls.Add(this.uxCheckBoxUseStation);
            this.Controls.Add(this.uxTextBoxInstrumentHeight);
            this.Controls.Add(this.uxLabelInstrumentHeight);
            this.Controls.Add(this.uxTextBoxSelectedStation);
            this.Controls.Add(this.uxLabelSelectedStation);
            this.Controls.Add(this.uxLabelStations);
            this.Controls.Add(this.uxDataGridViewObservations);
            this.Controls.Add(this.uxListBoxStations);
            this.Controls.Add(this.uxMenu);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.uxMenu;
            this.MinimumSize = new System.Drawing.Size(768, 475);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DPI Converter - Конвертиране на данни от полски измервания";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.uxMenu.ResumeLayout(false);
            this.uxMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewObservations)).EndInit();
            this.uxGroupBoxChangeCode.ResumeLayout(false);
            this.uxGroupBoxChangeCode.PerformLayout();
            this.uxGroupBoxChangeRows.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}