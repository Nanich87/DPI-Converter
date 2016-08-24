namespace DpiConverter.Forms
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using DpiConverter.Properties;

    public partial class SettingsPresenter : Form
    {
        public SettingsPresenter()
        {
            this.InitializeComponent();

            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(this.EnableSaveButton);

            this.inputFileValidationCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "ValidateInputFile", true, DataSourceUpdateMode.OnPropertyChanged);
            this.exportBacksightObservationsCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "ExportBacksightObservations", true, DataSourceUpdateMode.OnPropertyChanged);
            this.exportTraverseObservationsCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "ExportTraverseObservations", true, DataSourceUpdateMode.OnPropertyChanged);
            this.exportSideshotObservationsCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "ExportSideshotObservations", true, DataSourceUpdateMode.OnPropertyChanged);
            this.addPointOffsetCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "AddOffsetToSideshotPoints", true, DataSourceUpdateMode.OnPropertyChanged);
            this.pointOffsetTextBox.DataBindings.Add("Text", Properties.Settings.Default, "SideshotPointNumberOffset", true, DataSourceUpdateMode.OnPropertyChanged);
            this.usePredefinedCodesCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "UsePredefinedPointCodes", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddOffsetToSideshotPointsState(object sender, EventArgs e)
        {
            this.pointOffsetTextBox.ReadOnly = this.addPointOffsetCheckBox.Checked ? false : true;
        }

        private void EnableSaveButton(object sender, PropertyChangedEventArgs e)
        {
            this.saveSettingsButton.Enabled = true;
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            this.saveSettingsButton.Enabled = false;
        }
    }
}
