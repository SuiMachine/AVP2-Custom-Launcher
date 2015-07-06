namespace AVP_CustomLauncher
{
    partial class ConfigChoice
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Low = new System.Windows.Forms.Button();
            this.B_Medium = new System.Windows.Forms.Button();
            this.B_High = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "The Custom Launcher have not detected an existing autoexec.cfg.\r\nPlease choose a " +
    "preset for a new config:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.B_Low, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_High, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.B_Medium, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 271);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // B_Low
            // 
            this.B_Low.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.B_Low.Location = new System.Drawing.Point(172, 4);
            this.B_Low.Name = "B_Low";
            this.B_Low.Size = new System.Drawing.Size(133, 43);
            this.B_Low.TabIndex = 0;
            this.B_Low.Text = "Low Detail";
            this.B_Low.UseVisualStyleBackColor = true;
            this.B_Low.Click += new System.EventHandler(this.B_Low_Click);
            // 
            // B_Medium
            // 
            this.B_Medium.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.B_Medium.Location = new System.Drawing.Point(172, 92);
            this.B_Medium.Name = "B_Medium";
            this.B_Medium.Size = new System.Drawing.Size(133, 43);
            this.B_Medium.TabIndex = 1;
            this.B_Medium.Text = "Medium Detail";
            this.B_Medium.UseVisualStyleBackColor = true;
            this.B_Medium.Click += new System.EventHandler(this.B_Medium_Click);
            // 
            // B_High
            // 
            this.B_High.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.B_High.Location = new System.Drawing.Point(172, 180);
            this.B_High.Name = "B_High";
            this.B_High.Size = new System.Drawing.Size(133, 43);
            this.B_High.TabIndex = 2;
            this.B_High.Text = "High Detail";
            this.B_High.UseVisualStyleBackColor = true;
            this.B_High.Click += new System.EventHandler(this.B_High_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Low detail will provide the best game performance at the sacrifice of visual qual" +
    "ity.\r\nRecommended System Specs: Pentium 3 450MHz, 128MB RAM, 16MB VRAM.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Medium detail will provide a good trade-off between game performance and visual q" +
    "uality.\r\nRecommended System Specs: Pentium 3 700MHz, 128MB RAM, 32MB VRAM.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "High detail will provide high visual quality, but game performance may suffer on " +
    "slower systems.\r\nRecommended System Specs: Pentium 3 700MHz, 256MB RAM, 32MB VRA" +
    "M.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConfigChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 307);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "ConfigChoice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Config Choice";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Low;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_High;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_Medium;
    }
}