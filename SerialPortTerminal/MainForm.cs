namespace SerialPortTerminal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using SerialPortTerminal.LogMessage;
    using SerialPortTerminal.Properties;

    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        private Color[] logMessageTypeColor = 
        {
            Color.Blue,
            Color.Green,
            Color.Black,
            Color.Orange,
            Color.Red
        };

        private bool isKeyHandled = false;
        private Settings settings = Settings.Default;
        private string fileName;

        public MainForm()
        {
            this.InitializeComponent();

            this.serialPort = new SerialPort();
            this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.SerialPortDataReceived);
            this.serialPort.PinChanged += new SerialPinChangedEventHandler(this.SerialPortPinChanged);

            this.settings.Reload();

            this.InitializeControlValues();
            this.EnableControls();

            this.fileName = string.Empty;
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        private DataMode CurrentDataMode
        {
            get
            {
                if (this.dataModeOptionHex.Checked)
                {
                    return DataMode.Hex;
                }

                return DataMode.Text;
            }

            set
            {
                if (value == DataMode.Text)
                {
                    this.dataModeOptionText.Checked = true;
                }
                else
                {
                    this.dataModeOptionHex.Checked = true;
                }
            }
        }

        private void SerialPortPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            this.UpdatePinState();
        }

        private void UpdatePinState()
        {
            this.Invoke(new ThreadStart(() =>
                {
                    this.optionCD.Checked = this.serialPort.CDHolding;
                    this.optionCts.Checked = this.serialPort.CtsHolding;
                    this.optionDsr.Checked = this.serialPort.DsrHolding;
                }));
        }

        private void SaveSettings()
        {
            this.settings.BaudRate = int.Parse(this.baudRateComboBox.Text);
            this.settings.DataBits = int.Parse(this.dataBitsComboBox.Text);
            this.settings.DataMode = this.CurrentDataMode;
            this.settings.Parity = (Parity)Enum.Parse(typeof(Parity), this.parityComboBox.Text);
            this.settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.stopBitsComboBox.Text);
            this.settings.PortName = this.portNamesComboBox.Text;
            this.settings.ClearOnOpen = this.optionClearOnOpen.Checked;
            this.settings.ClearWithDTR = this.optionClearWithDtr.Checked;
            this.settings.Save();
        }

        private void InitializeControlValues()
        {
            this.parityComboBox.Items.Clear();
            this.parityComboBox.Items.AddRange(Enum.GetNames(typeof(Parity)));

            this.stopBitsComboBox.Items.Clear();
            this.stopBitsComboBox.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            this.parityComboBox.Text = this.settings.Parity.ToString();
            this.stopBitsComboBox.Text = this.settings.StopBits.ToString();
            this.dataBitsComboBox.Text = this.settings.DataBits.ToString();
            this.parityComboBox.Text = this.settings.Parity.ToString();
            this.baudRateComboBox.Text = this.settings.BaudRate.ToString();

            this.CurrentDataMode = this.settings.DataMode;

            this.RefreshComPortList();

            this.optionClearOnOpen.Checked = this.settings.ClearOnOpen;
            this.optionClearWithDtr.Checked = this.settings.ClearWithDTR;

            if (this.portNamesComboBox.Items.Contains(this.settings.PortName))
            {
                this.portNamesComboBox.Text = this.settings.PortName;
            }
            else if (this.portNamesComboBox.Items.Count > 0)
            {
                this.portNamesComboBox.SelectedIndex = this.portNamesComboBox.Items.Count - 1;
            }
            else
            {
                MessageBox.Show(this, "Няма намерени COM портове", "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void EnableControls()
        {
            this.portSettingsGroupBox.Enabled = this.serialPort.IsOpen ? false : true;
            this.textBoxSendData.Enabled = this.buttonSendData.Enabled = this.serialPort.IsOpen;
            this.optionDtr.Enabled = this.optionRts.Enabled = this.serialPort.IsOpen;
            this.openComPortButton.Text = this.serialPort.IsOpen ? "Затвори порт" : "Отвори порт";
        }

        private void SendData()
        {
            if (this.CurrentDataMode == DataMode.Text)
            {
                this.serialPort.Write(this.textBoxSendData.Text);

                this.LogMessage(LogMessageType.Outgoing, string.Format("{0}\n", this.textBoxSendData.Text));
            }
            else
            {
                try
                {
                    byte[] data = Helpers.DataConversionHelper.HexStringToByteArray(this.textBoxSendData.Text);

                    this.serialPort.Write(data, 0, data.Length);

                    this.LogMessage(LogMessageType.Outgoing, string.Format("{0}\n", Helpers.DataConversionHelper.ByteArrayToHexString(data)));
                }
                catch (FormatException ex)
                {
                    this.LogMessage(LogMessageType.Error, ex.Message);
                }
            }

            this.textBoxSendData.SelectAll();
        }

        private void LogMessage(LogMessageType messageType, string messageText)
        {
            this.outputTerminal.Invoke(new EventHandler(delegate
            {
                this.outputTerminal.SelectedText = string.Empty;
                this.outputTerminal.SelectionFont = new Font(this.outputTerminal.SelectionFont, FontStyle.Bold);
                this.outputTerminal.SelectionColor = this.logMessageTypeColor[(int)messageType];
                this.outputTerminal.AppendText(messageText);
                this.outputTerminal.ScrollToCaret();
            }));
        }

        private void OptionTextCheckedChanged(object sender, EventArgs e)
        {
            if (this.dataModeOptionText.Checked)
            {
                this.CurrentDataMode = DataMode.Text;
            }
        }

        private void OptionHexCheckedChanged(object sender, EventArgs e)
        {
            if (this.dataModeOptionHex.Checked)
            {
                this.CurrentDataMode = DataMode.Hex;
            }
        }

        private void ValidateBaudRate(object sender, CancelEventArgs e)
        {
            int x;
            e.Cancel = !int.TryParse(this.baudRateComboBox.Text, out x);
        }

        private void ValidateDataBits(object sender, CancelEventArgs e)
        {
            int x;
            e.Cancel = !int.TryParse(this.dataBitsComboBox.Text, out x);
        }

        private void OpenPort(object sender, EventArgs e)
        {
            bool errors = false;

            if (this.serialPort.IsOpen)
            {
                this.serialPort.Close();
            }
            else
            {
                this.serialPort.BaudRate = int.Parse(this.baudRateComboBox.Text);
                this.serialPort.DataBits = int.Parse(this.dataBitsComboBox.Text);
                this.serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.stopBitsComboBox.Text);
                this.serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), this.parityComboBox.Text);
                this.serialPort.PortName = this.portNamesComboBox.Text;

                try
                {
                    this.serialPort.Open();
                }
                catch (UnauthorizedAccessException)
                {
                    errors = true;
                }
                catch (IOException)
                {
                    errors = true;
                }
                catch (ArgumentException)
                {
                    errors = true;
                }

                if (errors)
                {
                    MessageBox.Show(this, "Не може да отвори COM порт (вероятно портът е премахнат, вече се използва или е недостъпен)!", "Стоп!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    this.UpdatePinState();
                    this.optionDtr.Checked = this.serialPort.DtrEnable;
                    this.optionRts.Checked = this.serialPort.RtsEnable;
                }
            }

            this.EnableControls();

            if (this.serialPort.IsOpen)
            {
                this.textBoxSendData.Focus();

                if (this.optionClearOnOpen.Checked)
                {
                    this.ClearTerminalOutput();
                }
            }
        }

        private void SendDataButtonClick(object sender, EventArgs e)
        {
            this.SendData();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!this.serialPort.IsOpen)
            {
                return;
            }

            if (this.CurrentDataMode == DataMode.Text)
            {
                string data = this.serialPort.ReadExisting();
                this.LogMessage(LogMessageType.Incoming, data);
            }
            else
            {
                int bytes = this.serialPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                this.serialPort.Read(buffer, 0, bytes);
                this.LogMessage(LogMessageType.Incoming, Helpers.DataConversionHelper.ByteArrayToHexString(buffer));
            }
        }

        private void SendDataKeyDown(object sender, KeyEventArgs e)
        {
            if (this.isKeyHandled = e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.SendData();
            }
        }

        private void SendDataKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.isKeyHandled;
        }

        private void OptionDtrCheckedChanged(object sender, EventArgs e)
        {
            this.serialPort.DtrEnable = this.optionDtr.Checked;
            if (this.optionDtr.Checked && this.optionClearWithDtr.Checked)
            {
                this.ClearTerminalOutput();
            }
        }

        private void OptionRtsCheckedChanged(object sender, EventArgs e)
        {
            this.serialPort.RtsEnable = this.optionRts.Checked;
        }

        private void ClearTerminalButtonClick(object sender, EventArgs e)
        {
            this.ClearTerminalOutput();
        }

        private void ClearTerminalOutput()
        {
            this.outputTerminal.Clear();
        }

        private void CheckComPortsTimerTick(object sender, EventArgs e)
        {
            this.RefreshComPortList();
        }

        private void RefreshComPortList()
        {
            string selectedItem = this.RefreshComPortList(this.portNamesComboBox.Items.Cast<string>(), this.portNamesComboBox.SelectedItem as string, this.serialPort.IsOpen);

            if (!string.IsNullOrEmpty(selectedItem))
            {
                this.portNamesComboBox.Items.Clear();
                this.portNamesComboBox.Items.AddRange(this.GetOrderedPortNames());
                this.portNamesComboBox.SelectedItem = selectedItem;
            }
        }

        private string[] GetOrderedPortNames()
        {
            int number;
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out number) ? number : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> previousPortNames, string currentSelection, bool isPortOpen)
        {
            string selectedPort = null;
            string[] ports = SerialPort.GetPortNames();
            bool updated = previousPortNames.Except(ports).Count() > 0 || ports.Except(previousPortNames).Count() > 0;

            if (updated)
            {
                ports = this.GetOrderedPortNames();
                string newestPort = SerialPort.GetPortNames().Except(previousPortNames).OrderBy(a => a).LastOrDefault();

                if (isPortOpen)
                {
                    if (ports.Contains(currentSelection))
                    {
                        selectedPort = currentSelection;
                    }
                    else if (!string.IsNullOrEmpty(newestPort))
                    {
                        selectedPort = newestPort;
                    }
                    else
                    {
                        selectedPort = ports.LastOrDefault();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(newestPort))
                    {
                        selectedPort = newestPort;
                    }
                    else if (ports.Contains(currentSelection))
                    {
                        selectedPort = currentSelection;
                    }
                    else
                    {
                        selectedPort = ports.LastOrDefault();
                    }
                }
            }

            return selectedPort;
        }

        private void SaveFile(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "SDR файлове (*.sdr)|*.sdr";
                saveFileDialog.DefaultExt = ".sdr";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, this.outputTerminal.Text);
                    this.fileName = saveFileDialog.FileName;

                    MessageBox.Show("Файлът беше записан успешно на диска!", "Информация:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAboutMessageBox(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Serial Port Terminal");
            output.AppendLine();
            output.AppendLine("Версия: 1.0.1");
            output.AppendLine();
            output.AppendLine("Програмата служи за комуникация с устройства, свързани чрез сериен порт");
            output.AppendLine();
            output.AppendLine("Автор: SixEightOne.eu");

            MessageBox.Show(output.ToString(), "За програмата:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitApplicaton(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}