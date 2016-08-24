namespace DpiConverter.Presenters
{
    public partial class SettingsPresenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox inputFileValidationCheckBox;
        private System.Windows.Forms.CheckBox exportBacksightObservationsCheckBox;
        private System.Windows.Forms.CheckBox exportTraverseObservationsCheckBox;
        private System.Windows.Forms.CheckBox exportSideshotObservationsCheckBox;
        private System.Windows.Forms.Button closeFormButton;
        private System.Windows.Forms.TextBox pointOffsetTextBox;
        private System.Windows.Forms.CheckBox addPointOffsetCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.CheckBox usePredefinedCodesCheckBox;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addPointOffsetCheckBox = new System.Windows.Forms.CheckBox();
            this.pointOffsetTextBox = new System.Windows.Forms.TextBox();
            this.inputFileValidationCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exportBacksightObservationsCheckBox = new System.Windows.Forms.CheckBox();
            this.exportTraverseObservationsCheckBox = new System.Windows.Forms.CheckBox();
            this.exportSideshotObservationsCheckBox = new System.Windows.Forms.CheckBox();
            this.closeFormButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.usePredefinedCodesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usePredefinedCodesCheckBox);
            this.groupBox1.Controls.Add(this.addPointOffsetCheckBox);
            this.groupBox1.Controls.Add(this.pointOffsetTextBox);
            this.groupBox1.Controls.Add(this.inputFileValidationCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Четене на данни";
            // 
            // addPointOffsetCheckBox
            // 
            this.addPointOffsetCheckBox.AutoSize = true;
            this.addPointOffsetCheckBox.Location = new System.Drawing.Point(7, 44);
            this.addPointOffsetCheckBox.Name = "addPointOffsetCheckBox";
            this.addPointOffsetCheckBox.Size = new System.Drawing.Size(230, 17);
            this.addPointOffsetCheckBox.TabIndex = 3;
            this.addPointOffsetCheckBox.Text = "Офсет на номерата на подр. точки";
            this.addPointOffsetCheckBox.UseVisualStyleBackColor = true;
            this.addPointOffsetCheckBox.CheckedChanged += new System.EventHandler(this.AddOffsetToSideshotPointsState);
            // 
            // pointOffsetTextBox
            // 
            this.pointOffsetTextBox.Location = new System.Drawing.Point(223, 67);
            this.pointOffsetTextBox.Name = "pointOffsetTextBox";
            this.pointOffsetTextBox.ReadOnly = true;
            this.pointOffsetTextBox.Size = new System.Drawing.Size(79, 21);
            this.pointOffsetTextBox.TabIndex = 2;
            // 
            // inputFileValidationCheckBox
            // 
            this.inputFileValidationCheckBox.AutoSize = true;
            this.inputFileValidationCheckBox.Location = new System.Drawing.Point(7, 19);
            this.inputFileValidationCheckBox.Name = "inputFileValidationCheckBox";
            this.inputFileValidationCheckBox.Size = new System.Drawing.Size(209, 17);
            this.inputFileValidationCheckBox.TabIndex = 0;
            this.inputFileValidationCheckBox.Text = "Валидация на входните данни";
            this.inputFileValidationCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exportBacksightObservationsCheckBox);
            this.groupBox2.Controls.Add(this.exportTraverseObservationsCheckBox);
            this.groupBox2.Controls.Add(this.exportSideshotObservationsCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Запис на измервания";
            // 
            // exportBacksightObservationsCheckBox
            // 
            this.exportBacksightObservationsCheckBox.AutoSize = true;
            this.exportBacksightObservationsCheckBox.Location = new System.Drawing.Point(7, 19);
            this.exportBacksightObservationsCheckBox.Name = "exportBacksightObservationsCheckBox";
            this.exportBacksightObservationsCheckBox.Size = new System.Drawing.Size(166, 17);
            this.exportBacksightObservationsCheckBox.TabIndex = 1;
            this.exportBacksightObservationsCheckBox.Text = "Ориентация (Backsight)";
            this.exportBacksightObservationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportTraverseObservationsCheckBox
            // 
            this.exportTraverseObservationsCheckBox.AutoSize = true;
            this.exportTraverseObservationsCheckBox.Location = new System.Drawing.Point(7, 42);
            this.exportTraverseObservationsCheckBox.Name = "exportTraverseObservationsCheckBox";
            this.exportTraverseObservationsCheckBox.Size = new System.Drawing.Size(139, 17);
            this.exportTraverseObservationsCheckBox.TabIndex = 2;
            this.exportTraverseObservationsCheckBox.Text = "Полигон (Traverse)";
            this.exportTraverseObservationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportSideshotObservationsCheckBox
            // 
            this.exportSideshotObservationsCheckBox.AutoSize = true;
            this.exportSideshotObservationsCheckBox.Location = new System.Drawing.Point(7, 65);
            this.exportSideshotObservationsCheckBox.Name = "exportSideshotObservationsCheckBox";
            this.exportSideshotObservationsCheckBox.Size = new System.Drawing.Size(184, 17);
            this.exportSideshotObservationsCheckBox.TabIndex = 3;
            this.exportSideshotObservationsCheckBox.Text = "Подробни точки (Sideshot)";
            this.exportSideshotObservationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // closeFormButton
            // 
            this.closeFormButton.Location = new System.Drawing.Point(83, 327);
            this.closeFormButton.Name = "closeFormButton";
            this.closeFormButton.Size = new System.Drawing.Size(87, 23);
            this.closeFormButton.TabIndex = 5;
            this.closeFormButton.Text = "Затваряне";
            this.closeFormButton.UseVisualStyleBackColor = true;
            this.closeFormButton.Click += new System.EventHandler(this.CloseForm);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Enabled = false;
            this.saveSettingsButton.Location = new System.Drawing.Point(177, 327);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 6;
            this.saveSettingsButton.Text = "Запис";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.SaveSettings);
            // 
            // usePredefinedCodesCheckBox
            // 
            this.usePredefinedCodesCheckBox.AutoSize = true;
            this.usePredefinedCodesCheckBox.Location = new System.Drawing.Point(7, 94);
            this.usePredefinedCodesCheckBox.Name = "usePredefinedCodesCheckBox";
            this.usePredefinedCodesCheckBox.Size = new System.Drawing.Size(258, 17);
            this.usePredefinedCodesCheckBox.TabIndex = 4;
            this.usePredefinedCodesCheckBox.Text = "Използване на предефинирани кодове";
            this.usePredefinedCodesCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 362);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.closeFormButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 400);
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}