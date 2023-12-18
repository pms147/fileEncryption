namespace WindowsFormsApp1
{
    partial class DecryptForm
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
            this.decryptButton = new System.Windows.Forms.Button();
            this.ChooseFileButton = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.Label();
            this.ChooseKeyButton = new System.Windows.Forms.Button();
            this.KeyPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // decryptButton
            // 
            this.decryptButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.decryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.decryptButton.Location = new System.Drawing.Point(50, 150);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(700, 50);
            this.decryptButton.TabIndex = 1;
            this.decryptButton.Text = "Giải Mã";
            this.decryptButton.UseVisualStyleBackColor = false;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.AutoSize = true;
            this.ChooseFileButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ChooseFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.ChooseFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChooseFileButton.Location = new System.Drawing.Point(50, 12);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(700, 50);
            this.ChooseFileButton.TabIndex = 3;
            this.ChooseFileButton.Text = "Chọn File Giải Mã";
            this.ChooseFileButton.UseVisualStyleBackColor = false;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFile);
            // 
            // FilePath
            // 
            this.FilePath.AutoSize = true;
            this.FilePath.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FilePath.Location = new System.Drawing.Point(45, 231);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(160, 29);
            this.FilePath.TabIndex = 4;
            this.FilePath.Text = "File mã hóa: ";
            this.FilePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChooseKeyButton
            // 
            this.ChooseKeyButton.AutoSize = true;
            this.ChooseKeyButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ChooseKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.ChooseKeyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChooseKeyButton.Location = new System.Drawing.Point(50, 82);
            this.ChooseKeyButton.Name = "ChooseKeyButton";
            this.ChooseKeyButton.Size = new System.Drawing.Size(700, 50);
            this.ChooseKeyButton.TabIndex = 5;
            this.ChooseKeyButton.Text = "Chọn File Kprivate";
            this.ChooseKeyButton.UseVisualStyleBackColor = false;
            this.ChooseKeyButton.Click += new System.EventHandler(this.ChooseKey);
            // 
            // KeyPath
            // 
            this.KeyPath.AutoSize = true;
            this.KeyPath.BackColor = System.Drawing.SystemColors.ControlDark;
            this.KeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.KeyPath.Location = new System.Drawing.Point(45, 282);
            this.KeyPath.Name = "KeyPath";
            this.KeyPath.Size = new System.Drawing.Size(168, 29);
            this.KeyPath.TabIndex = 6;
            this.KeyPath.Text = "File Kprivate: ";
            this.KeyPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.KeyPath);
            this.Controls.Add(this.ChooseKeyButton);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.ChooseFileButton);
            this.Controls.Add(this.decryptButton);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.Button ChooseKeyButton;
        private System.Windows.Forms.Label KeyPath;
    }
}