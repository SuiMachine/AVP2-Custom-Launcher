namespace AVP_CustomLauncher
{
    partial class GameSettings
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
            this.B_ManualEdit = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.C_32color = new System.Windows.Forms.CheckBox();
            this.C_Windowed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_FOV = new System.Windows.Forms.TextBox();
            this.C_EnableAspectRatioMemoryWrite = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.T_ResolutionY = new System.Windows.Forms.TextBox();
            this.T_ResolutionX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_SaveAndClose = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.C_DisableHardwareCursor = new System.Windows.Forms.CheckBox();
            this.C_DisableSound = new System.Windows.Forms.CheckBox();
            this.C_DisableMusic = new System.Windows.Forms.CheckBox();
            this.C_DisableLogos = new System.Windows.Forms.CheckBox();
            this.C_DisableTripleBuffering = new System.Windows.Forms.CheckBox();
            this.C_DisableJoystick = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.T_CommandLine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_ManualEdit
            // 
            this.B_ManualEdit.Location = new System.Drawing.Point(12, 226);
            this.B_ManualEdit.Name = "B_ManualEdit";
            this.B_ManualEdit.Size = new System.Drawing.Size(368, 276);
            this.B_ManualEdit.TabIndex = 0;
            this.B_ManualEdit.Text = "";
            this.B_ManualEdit.TextChanged += new System.EventHandler(this.B_ManualEdit_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.C_32color);
            this.panel1.Controls.Add(this.C_Windowed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TB_FOV);
            this.panel1.Controls.Add(this.C_EnableAspectRatioMemoryWrite);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.T_ResolutionY);
            this.panel1.Controls.Add(this.T_ResolutionX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 148);
            this.panel1.TabIndex = 1;
            // 
            // C_32color
            // 
            this.C_32color.AutoSize = true;
            this.C_32color.Location = new System.Drawing.Point(6, 45);
            this.C_32color.Name = "C_32color";
            this.C_32color.Size = new System.Drawing.Size(111, 17);
            this.C_32color.TabIndex = 8;
            this.C_32color.Text = "32-bit Color Depth";
            this.C_32color.UseVisualStyleBackColor = true;
            this.C_32color.CheckedChanged += new System.EventHandler(this.C_32color_CheckedChanged);
            // 
            // C_Windowed
            // 
            this.C_Windowed.AutoSize = true;
            this.C_Windowed.Location = new System.Drawing.Point(6, 67);
            this.C_Windowed.Name = "C_Windowed";
            this.C_Windowed.Size = new System.Drawing.Size(107, 17);
            this.C_Windowed.TabIndex = 7;
            this.C_Windowed.Text = "Windowed Mode";
            this.C_Windowed.UseVisualStyleBackColor = true;
            this.C_Windowed.CheckedChanged += new System.EventHandler(this.C_Windowed_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "FOV";
            // 
            // TB_FOV
            // 
            this.TB_FOV.Enabled = false;
            this.TB_FOV.Location = new System.Drawing.Point(38, 116);
            this.TB_FOV.Name = "TB_FOV";
            this.TB_FOV.Size = new System.Drawing.Size(66, 20);
            this.TB_FOV.TabIndex = 5;
            this.TB_FOV.TextChanged += new System.EventHandler(this.TB_FOV_TextChanged);
            // 
            // C_EnableAspectRatioMemoryWrite
            // 
            this.C_EnableAspectRatioMemoryWrite.AutoSize = true;
            this.C_EnableAspectRatioMemoryWrite.Location = new System.Drawing.Point(6, 90);
            this.C_EnableAspectRatioMemoryWrite.Name = "C_EnableAspectRatioMemoryWrite";
            this.C_EnableAspectRatioMemoryWrite.Size = new System.Drawing.Size(139, 17);
            this.C_EnableAspectRatioMemoryWrite.TabIndex = 4;
            this.C_EnableAspectRatioMemoryWrite.Text = "Enable Aspect Ratio Fix";
            this.C_EnableAspectRatioMemoryWrite.UseVisualStyleBackColor = true;
            this.C_EnableAspectRatioMemoryWrite.CheckedChanged += new System.EventHandler(this.C_EnableAspectRatioMemoryWrite_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "x";
            // 
            // T_ResolutionY
            // 
            this.T_ResolutionY.Location = new System.Drawing.Point(99, 17);
            this.T_ResolutionY.Name = "T_ResolutionY";
            this.T_ResolutionY.Size = new System.Drawing.Size(73, 20);
            this.T_ResolutionY.TabIndex = 2;
            this.T_ResolutionY.TextChanged += new System.EventHandler(this.T_ResolutionY_TextChanged);
            // 
            // T_ResolutionX
            // 
            this.T_ResolutionX.Location = new System.Drawing.Point(3, 17);
            this.T_ResolutionX.Name = "T_ResolutionX";
            this.T_ResolutionX.Size = new System.Drawing.Size(73, 20);
            this.T_ResolutionX.TabIndex = 1;
            this.T_ResolutionX.TextChanged += new System.EventHandler(this.T_ResolutionX_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution:";
            // 
            // B_SaveAndClose
            // 
            this.B_SaveAndClose.Location = new System.Drawing.Point(100, 508);
            this.B_SaveAndClose.Name = "B_SaveAndClose";
            this.B_SaveAndClose.Size = new System.Drawing.Size(93, 23);
            this.B_SaveAndClose.TabIndex = 2;
            this.B_SaveAndClose.Text = "Save and Close";
            this.B_SaveAndClose.UseVisualStyleBackColor = true;
            this.B_SaveAndClose.Click += new System.EventHandler(this.B_SaveAndClose_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(199, 508);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(93, 23);
            this.B_Cancel.TabIndex = 3;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.C_DisableHardwareCursor);
            this.panel2.Controls.Add(this.C_DisableSound);
            this.panel2.Controls.Add(this.C_DisableMusic);
            this.panel2.Controls.Add(this.C_DisableLogos);
            this.panel2.Controls.Add(this.C_DisableTripleBuffering);
            this.panel2.Controls.Add(this.C_DisableJoystick);
            this.panel2.Location = new System.Drawing.Point(199, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 148);
            this.panel2.TabIndex = 9;
            // 
            // C_DisableHardwareCursor
            // 
            this.C_DisableHardwareCursor.AutoSize = true;
            this.C_DisableHardwareCursor.Location = new System.Drawing.Point(3, 120);
            this.C_DisableHardwareCursor.Name = "C_DisableHardwareCursor";
            this.C_DisableHardwareCursor.Size = new System.Drawing.Size(143, 17);
            this.C_DisableHardwareCursor.TabIndex = 9;
            this.C_DisableHardwareCursor.Text = "Disable Hardware Cursor";
            this.C_DisableHardwareCursor.UseVisualStyleBackColor = true;
            this.C_DisableHardwareCursor.CheckedChanged += new System.EventHandler(this.C_DisableHardwareCursor_CheckedChanged);
            // 
            // C_DisableSound
            // 
            this.C_DisableSound.AutoSize = true;
            this.C_DisableSound.Location = new System.Drawing.Point(3, 5);
            this.C_DisableSound.Name = "C_DisableSound";
            this.C_DisableSound.Size = new System.Drawing.Size(95, 17);
            this.C_DisableSound.TabIndex = 8;
            this.C_DisableSound.Text = "Disable Sound";
            this.C_DisableSound.UseVisualStyleBackColor = true;
            this.C_DisableSound.CheckedChanged += new System.EventHandler(this.C_DisableSound_CheckedChanged);
            // 
            // C_DisableMusic
            // 
            this.C_DisableMusic.AutoSize = true;
            this.C_DisableMusic.Location = new System.Drawing.Point(3, 28);
            this.C_DisableMusic.Name = "C_DisableMusic";
            this.C_DisableMusic.Size = new System.Drawing.Size(92, 17);
            this.C_DisableMusic.TabIndex = 7;
            this.C_DisableMusic.Text = "Disable Music";
            this.C_DisableMusic.UseVisualStyleBackColor = true;
            this.C_DisableMusic.CheckedChanged += new System.EventHandler(this.C_DisableMusic_CheckedChanged);
            // 
            // C_DisableLogos
            // 
            this.C_DisableLogos.AutoSize = true;
            this.C_DisableLogos.Location = new System.Drawing.Point(3, 51);
            this.C_DisableLogos.Name = "C_DisableLogos";
            this.C_DisableLogos.Size = new System.Drawing.Size(93, 17);
            this.C_DisableLogos.TabIndex = 6;
            this.C_DisableLogos.Text = "Disable Logos";
            this.C_DisableLogos.UseVisualStyleBackColor = true;
            this.C_DisableLogos.CheckedChanged += new System.EventHandler(this.C_DisableLogos_CheckedChanged);
            // 
            // C_DisableTripleBuffering
            // 
            this.C_DisableTripleBuffering.AutoSize = true;
            this.C_DisableTripleBuffering.Location = new System.Drawing.Point(3, 74);
            this.C_DisableTripleBuffering.Name = "C_DisableTripleBuffering";
            this.C_DisableTripleBuffering.Size = new System.Drawing.Size(135, 17);
            this.C_DisableTripleBuffering.TabIndex = 5;
            this.C_DisableTripleBuffering.Text = "Disable Triple Buffering";
            this.C_DisableTripleBuffering.UseVisualStyleBackColor = true;
            this.C_DisableTripleBuffering.CheckedChanged += new System.EventHandler(this.C_DisableTripleBuffering_CheckedChanged);
            // 
            // C_DisableJoystick
            // 
            this.C_DisableJoystick.AutoSize = true;
            this.C_DisableJoystick.Location = new System.Drawing.Point(3, 97);
            this.C_DisableJoystick.Name = "C_DisableJoystick";
            this.C_DisableJoystick.Size = new System.Drawing.Size(102, 17);
            this.C_DisableJoystick.TabIndex = 4;
            this.C_DisableJoystick.Text = "Disable Joystick";
            this.C_DisableJoystick.UseVisualStyleBackColor = true;
            this.C_DisableJoystick.CheckedChanged += new System.EventHandler(this.C_DisableJoystick_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.T_CommandLine);
            this.panel3.Location = new System.Drawing.Point(12, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 54);
            this.panel3.TabIndex = 10;
            // 
            // T_CommandLine
            // 
            this.T_CommandLine.Location = new System.Drawing.Point(4, 25);
            this.T_CommandLine.Name = "T_CommandLine";
            this.T_CommandLine.Size = new System.Drawing.Size(356, 20);
            this.T_CommandLine.TabIndex = 0;
            this.T_CommandLine.TextChanged += new System.EventHandler(this.T_CommandLine_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Command-line parameters:";
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 543);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_SaveAndClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.B_ManualEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GraphicsSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox B_ManualEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox T_ResolutionY;
        private System.Windows.Forms.TextBox T_ResolutionX;
        private System.Windows.Forms.CheckBox C_EnableAspectRatioMemoryWrite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_FOV;
        private System.Windows.Forms.CheckBox C_Windowed;
        private System.Windows.Forms.CheckBox C_32color;
        private System.Windows.Forms.Button B_SaveAndClose;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox C_DisableHardwareCursor;
        private System.Windows.Forms.CheckBox C_DisableSound;
        private System.Windows.Forms.CheckBox C_DisableMusic;
        private System.Windows.Forms.CheckBox C_DisableLogos;
        private System.Windows.Forms.CheckBox C_DisableTripleBuffering;
        private System.Windows.Forms.CheckBox C_DisableJoystick;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox T_CommandLine;
    }
}