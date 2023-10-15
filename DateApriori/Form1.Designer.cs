﻿namespace DateApriori
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            importDataButton = new Button();
            calculateL1Button = new Button();
            minimumThresholdInputField = new TextBox();
            minimumThresholdLabel = new Label();
            SuspendLayout();
            // 
            // importDataButton
            // 
            importDataButton.Location = new Point(12, 12);
            importDataButton.Name = "importDataButton";
            importDataButton.Size = new Size(102, 44);
            importDataButton.TabIndex = 0;
            importDataButton.Text = "Import Data";
            importDataButton.UseVisualStyleBackColor = true;
            importDataButton.Click += ImportDataButton_Click;
            // 
            // calculateL1Button
            // 
            calculateL1Button.Location = new Point(12, 62);
            calculateL1Button.Name = "calculateL1Button";
            calculateL1Button.Size = new Size(102, 47);
            calculateL1Button.TabIndex = 1;
            calculateL1Button.Text = "Calculate L1";
            calculateL1Button.UseVisualStyleBackColor = true;
            calculateL1Button.Click += CalculateL1;
            // 
            // minimumThresholdInputField
            // 
            minimumThresholdInputField.Location = new Point(276, 16);
            minimumThresholdInputField.Name = "minimumThresholdInputField";
            minimumThresholdInputField.Size = new Size(125, 27);
            minimumThresholdInputField.TabIndex = 2;
            // 
            // minimumThresholdLabel
            // 
            minimumThresholdLabel.AutoSize = true;
            minimumThresholdLabel.Location = new Point(129, 19);
            minimumThresholdLabel.Name = "minimumThresholdLabel";
            minimumThresholdLabel.Size = new Size(141, 20);
            minimumThresholdLabel.TabIndex = 3;
            minimumThresholdLabel.Text = "Minimum Threshold";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(minimumThresholdLabel);
            Controls.Add(minimumThresholdInputField);
            Controls.Add(calculateL1Button);
            Controls.Add(importDataButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importDataButton;
        private Button calculateL1Button;
        private TextBox minimumThresholdInputField;
        private Label minimumThresholdLabel;
    }
}