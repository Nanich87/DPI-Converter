namespace DpiConverter.Presenters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Contracts.Files;
    using Data;
    using DpiConverter.Helpers;
    using Files.Exportable;

    public partial class MainPresenter : Form
    {
        private BindingSource stationsBindingSource;

        public MainPresenter()
        {
            this.InitializeComponent();
            this.InitializaStationsBindingSource();
            this.InitializeStationsListBox();
            this.InitializeDataBindings();
            this.InitializeControlStates();
        }

        private void InitializeControlStates()
        {
            this.uxDataGridViewObservations.AutoGenerateColumns = false;
            this.uxButtonCalculateIndexErrors.Enabled = false;
        }

        private void InitializeDataBindings()
        {
            Binding stationFullNameBinding = this.uxTextBoxSelectedStation.DataBindings.Add("Text", this.stationsBindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            Binding instrumentHeightBinding = this.uxTextBoxInstrumentHeight.DataBindings.Add("Text", this.stationsBindingSource, "InstrumentHeight", true, DataSourceUpdateMode.OnPropertyChanged);
            this.uxCheckBoxUseStation.DataBindings.Add("Checked", this.stationsBindingSource, "UseStation", false, DataSourceUpdateMode.OnPropertyChanged);
            this.uxDataGridViewObservations.DataBindings.Add("DataSource", this.stationsBindingSource, "Observations", false, DataSourceUpdateMode.OnPropertyChanged);

            stationFullNameBinding.BindingComplete += new BindingCompleteEventHandler(StationBindingComplete);
            instrumentHeightBinding.BindingComplete += new BindingCompleteEventHandler(StationBindingComplete);
        }

        void StationBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
            {
                LogHelper.Error(e.ErrorText);
            }
        }

        private void InitializeStationsListBox()
        {
            this.uxListBoxStations.DisplayMember = "FullName";
            this.uxListBoxStations.ValueMember = "StationIndex";
            this.uxListBoxStations.DataSource = this.stationsBindingSource;
        }

        private void InitializaStationsBindingSource()
        {
            this.stationsBindingSource = new BindingSource();
            this.stationsBindingSource.ListChanged += this.StationsListChangedEventHandler;
            this.stationsBindingSource.DataSource = Databases.DefaultDatabase.GetInstance().Stations;
        }

        private void StationsListChangedEventHandler(object sender, ListChangedEventArgs e)
        {
            this.uxLabelStations.Text = string.Format("Станции: {0}", Databases.DefaultDatabase.GetInstance().Stations.Count);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = Properties.Resources.FileOpenFilter
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.ProcessFile(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format("Файлът {0} не може да бъде намерен!", path));
            }

            string extension = Path.GetExtension(path);

            IImportableFile document = Factories.InputFileFactory.Create(extension, Properties.Settings.Default.ValidateInputFile);
            try
            {
                document.Open(path, Databases.DefaultDatabase.GetInstance().Stations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }

            MessageBox.Show(string.Format("Добавени станции: {0}; Добавени измервания: {1}", Databases.DefaultDatabase.GetInstance().Stations.Count, Databases.DefaultDatabase.GetInstance().Stations.SelectMany(x => x.Observations).Count()), "Четене на файл:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.stationsBindingSource.ResetBindings(false);

            this.uxMenuItemSaveFile.Enabled = true;
            this.uxButtonCalculateIndexErrors.Enabled = true;
        }

        private void SaveFile(object sender, EventArgs e)
        {
            try
            {
                IExportableFile dpiFile = new DpiFile(Databases.DefaultDatabase.GetInstance().Stations);
                string output = dpiFile.Export();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = Properties.Resources.FileSaveFilter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, output, Encoding.Default);

                    MessageBox.Show("Файлът беше записан успешно на диска!", "Информация:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAbountMessage(object sender, EventArgs e)
        {
            try
            {
                StringBuilder output = new StringBuilder();

                output.AppendLine("DPI Converter");
                output.AppendLine();
                output.AppendLine("Програма за конвертиране на LandXML v1.2, Trimble JobXML и Sokkia SDR33 файлове в Dpi формат");
                output.AppendLine();
                output.AppendLine("Версия: 0.7.4");
                output.AppendLine();
                output.AppendLine("Автор: инж. Н. Гешков");
                output.AppendLine();
                output.AppendLine("www.SixEightOne.eu");

                MessageBox.Show(output.ToString(), "За програмата:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeFeatureCode(object sender, EventArgs e)
        {
            try
            {
                if (Databases.DefaultDatabase.GetInstance().Stations.Count == 0)
                {
                    throw new ArgumentException("Няма добавени станции!");
                }

                if (this.uxTextBoxOldCodeValue.Text == this.uxTextBoxNewCodeValue.Text)
                {
                    this.uxTextBoxOldCodeValue.BackColor = Color.Aqua;
                    this.uxTextBoxNewCodeValue.BackColor = Color.Aqua;

                    throw new ArgumentException("Полетата Стар код и Нов код не могат да бъдат еднакви!");
                }

                this.uxTextBoxOldCodeValue.BackColor = Color.Empty;
                this.uxTextBoxNewCodeValue.BackColor = Color.Empty;

                int changedFeatureCodes = Databases.DefaultDatabase.GetInstance().ChangeFeatureCode(this.uxTextBoxOldCodeValue.Text, this.uxTextBoxNewCodeValue.Text);

                this.stationsBindingSource.ResetBindings(false);

                this.uxDataGridViewObservations.Invalidate();

                MessageBox.Show(string.Format("Редактирани кодове: {0}", changedFeatureCodes), "Информация:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSettingsPresenter(object sender, EventArgs e)
        {
            try
            {
                SettingsPresenter settingsPresenter = new SettingsPresenter();
                settingsPresenter.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CalculateVerticalAngleMisclosureButtonClickedEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (Databases.DefaultDatabase.GetInstance().Stations.Count > 0)
                {
                    Databases.DefaultDatabase.GetInstance().Stations.ElementAt(this.uxListBoxStations.SelectedIndex).ResetVerticalAngleMisclosure();
                    Databases.DefaultDatabase.GetInstance().Stations.ElementAt(this.uxListBoxStations.SelectedIndex).CalculateVerticalAngleMisclosure();

                    this.stationsBindingSource.ResetBindings(false);

                    this.uxDataGridViewObservations.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObservationsDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs error)
        {
            MessageBox.Show(error.Context.ToString(), "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DeleteSelectedObservationsButtonClickedEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (Databases.DefaultDatabase.GetInstance().Stations.Count == 0)
                {
                    return;
                }

                if (this.uxDataGridViewObservations.SelectedRows.Count == 0)
                {
                    return;
                }

                string confirmMessage = string.Format(
                    "{0} {1}! Искате ли да продължите?",
                    this.uxDataGridViewObservations.SelectedRows.Count,
                    this.uxDataGridViewObservations.SelectedRows.Count > 1 ? "измервания ще бъдат изтрити" : "измерване ще бъде изтрито");
                var confirmResult = MessageBox.Show(confirmMessage, "Внимание:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow selectedRow in this.uxDataGridViewObservations.SelectedRows)
                    {
                        this.uxDataGridViewObservations.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewObservationButtonClickedEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (Databases.DefaultDatabase.GetInstance().Stations.Count == 0)
                {
                    return;
                }

                Observation newObservation = new Observation(string.Empty, "9999", 0, 100, 100, 100, "New");

                Databases.DefaultDatabase.GetInstance().Stations.ElementAt(this.uxListBoxStations.SelectedIndex).Observations.Add(newObservation);

                this.uxDataGridViewObservations.CurrentCell = this.uxDataGridViewObservations.Rows[this.uxDataGridViewObservations.Rows.Count - 1].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndObservationCellEditEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (this.uxDataGridViewObservations.SelectedCells.Count < 2)
            {
                return;
            }

            string confirmMessage = string.Format("Стойностите на {0} клетки ще бъдат променени! Искате ли да продължите?", this.uxDataGridViewObservations.SelectedCells.Count);
            var confirmResult = MessageBox.Show(confirmMessage, "Внимание:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var lastSelectedCell = this.uxDataGridViewObservations.Rows[e.RowIndex].Cells[e.ColumnIndex];

                foreach (DataGridViewTextBoxCell cell in this.uxDataGridViewObservations.SelectedCells)
                {
                    cell.Value = lastSelectedCell.Value;
                }
            }
        }

        private void OpenNewSerialPortTerminalButtonClickedEventHandler(object sender, EventArgs e)
        {
            try
            {
                var serialPortTerminalPresenter = new SerialPortTerminal.MainPresenter();
                serialPortTerminalPresenter.ShowDialog();

                if (!string.IsNullOrWhiteSpace(serialPortTerminalPresenter.FileName) && File.Exists(serialPortTerminalPresenter.FileName))
                {
                    this.ProcessFile(serialPortTerminalPresenter.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}