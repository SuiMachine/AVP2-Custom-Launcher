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
			this.label4 = new System.Windows.Forms.Label();
			this.T_CommandLine = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.CB_LithFix_Borderless = new System.Windows.Forms.CheckBox();
			this.C_LithFix_ENABLED = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.num_LithFix_FPSCAP = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_LithFix_FPSCAP)).BeginInit();
			this.SuspendLayout();
			// 
			// B_ManualEdit
			// 
			this.B_ManualEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.B_ManualEdit.Location = new System.Drawing.Point(3, 311);
			this.B_ManualEdit.Name = "B_ManualEdit";
			this.B_ManualEdit.Size = new System.Drawing.Size(388, 231);
			this.B_ManualEdit.TabIndex = 0;
			this.B_ManualEdit.Text = "";
			this.B_ManualEdit.TextChanged += new System.EventHandler(this.B_ManualEdit_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.C_32color);
			this.panel1.Controls.Add(this.C_Windowed);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.TB_FOV);
			this.panel1.Controls.Add(this.C_EnableAspectRatioMemoryWrite);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.T_ResolutionY);
			this.panel1.Controls.Add(this.T_ResolutionX);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(188, 144);
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
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(3, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Resolution:";
			// 
			// B_SaveAndClose
			// 
			this.B_SaveAndClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.B_SaveAndClose.Location = new System.Drawing.Point(98, 3);
			this.B_SaveAndClose.Name = "B_SaveAndClose";
			this.B_SaveAndClose.Size = new System.Drawing.Size(93, 23);
			this.B_SaveAndClose.TabIndex = 2;
			this.B_SaveAndClose.Text = "Save and Close";
			this.B_SaveAndClose.UseVisualStyleBackColor = true;
			this.B_SaveAndClose.Click += new System.EventHandler(this.B_SaveAndClose_Click);
			// 
			// B_Cancel
			// 
			this.B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.B_Cancel.Location = new System.Drawing.Point(197, 3);
			this.B_Cancel.Name = "B_Cancel";
			this.B_Cancel.Size = new System.Drawing.Size(93, 23);
			this.B_Cancel.TabIndex = 3;
			this.B_Cancel.Text = "Cancel";
			this.B_Cancel.UseVisualStyleBackColor = true;
			this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.C_DisableHardwareCursor);
			this.panel2.Controls.Add(this.C_DisableSound);
			this.panel2.Controls.Add(this.C_DisableMusic);
			this.panel2.Controls.Add(this.C_DisableLogos);
			this.panel2.Controls.Add(this.C_DisableTripleBuffering);
			this.panel2.Controls.Add(this.C_DisableJoystick);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(197, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(188, 144);
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
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(155, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Command-line parameters:";
			// 
			// T_CommandLine
			// 
			this.T_CommandLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.T_CommandLine.Location = new System.Drawing.Point(3, 22);
			this.T_CommandLine.Name = "T_CommandLine";
			this.T_CommandLine.Size = new System.Drawing.Size(382, 20);
			this.T_CommandLine.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.B_ManualEdit, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 581);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(388, 150);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.T_CommandLine, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 159);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(388, 46);
			this.tableLayoutPanel3.TabIndex = 11;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.B_Cancel, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.B_SaveAndClose, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 548);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(388, 30);
			this.tableLayoutPanel4.TabIndex = 12;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 211);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(388, 94);
			this.tableLayoutPanel5.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(188, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "LithFix by HeyJake (if installed):";
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.Controls.Add(this.CB_LithFix_Borderless, 1, 0);
			this.tableLayoutPanel6.Controls.Add(this.C_LithFix_ENABLED, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.panel3, 0, 1);
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 27);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 2;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(382, 64);
			this.tableLayoutPanel6.TabIndex = 3;
			// 
			// CB_LithFix_Borderless
			// 
			this.CB_LithFix_Borderless.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.CB_LithFix_Borderless.AutoSize = true;
			this.CB_LithFix_Borderless.Location = new System.Drawing.Point(194, 3);
			this.CB_LithFix_Borderless.Name = "CB_LithFix_Borderless";
			this.CB_LithFix_Borderless.Size = new System.Drawing.Size(149, 17);
			this.CB_LithFix_Borderless.TabIndex = 1;
			this.CB_LithFix_Borderless.Text = "Enable borderless window";
			this.CB_LithFix_Borderless.UseVisualStyleBackColor = true;
			// 
			// C_LithFix_ENABLED
			// 
			this.C_LithFix_ENABLED.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.C_LithFix_ENABLED.AutoSize = true;
			this.C_LithFix_ENABLED.Location = new System.Drawing.Point(3, 3);
			this.C_LithFix_ENABLED.Name = "C_LithFix_ENABLED";
			this.C_LithFix_ENABLED.Size = new System.Drawing.Size(142, 17);
			this.C_LithFix_ENABLED.TabIndex = 0;
			this.C_LithFix_ENABLED.Text = "Enable (add \"-rez lithfix\")";
			this.C_LithFix_ENABLED.UseVisualStyleBackColor = true;
			this.C_LithFix_ENABLED.CheckedChanged += new System.EventHandler(this.CB_LithFix_ENABLED_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.num_LithFix_FPSCAP);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Location = new System.Drawing.Point(3, 27);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(185, 34);
			this.panel3.TabIndex = 2;
			// 
			// num_LithFix_FPSCAP
			// 
			this.num_LithFix_FPSCAP.Location = new System.Drawing.Point(92, 6);
			this.num_LithFix_FPSCAP.Name = "num_LithFix_FPSCAP";
			this.num_LithFix_FPSCAP.Size = new System.Drawing.Size(86, 20);
			this.num_LithFix_FPSCAP.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Max framerate:";
			// 
			// GameSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 581);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(410, 620);
			this.Name = "GameSettings";
			this.Text = "Game Settings";
			this.Load += new System.EventHandler(this.GameSettings_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_LithFix_FPSCAP)).EndInit();
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
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox T_CommandLine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox CB_LithFix_Borderless;
        private System.Windows.Forms.CheckBox C_LithFix_ENABLED;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown num_LithFix_FPSCAP;
        private System.Windows.Forms.Label label6;
    }
}