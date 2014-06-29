namespace ADC
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_Gamma = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_N = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_P0 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label_IdelQuant = new System.Windows.Forms.Label();
			this.label_Maximum = new System.Windows.Forms.Label();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox_Gamma);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_N);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox_P0);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(215, 217);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 139);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(200, 32);
			this.button3.TabIndex = 8;
			this.button3.Text = "1 алгоритм";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(9, 179);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 32);
			this.button2.TabIndex = 7;
			this.button2.Text = "2 алгоритм";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Gamma";
			// 
			// textBox_Gamma
			// 
			this.textBox_Gamma.Location = new System.Drawing.Point(66, 75);
			this.textBox_Gamma.Name = "textBox_Gamma";
			this.textBox_Gamma.Size = new System.Drawing.Size(143, 20);
			this.textBox_Gamma.TabIndex = 5;
			this.textBox_Gamma.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(15, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "N";
			// 
			// textBox_N
			// 
			this.textBox_N.Location = new System.Drawing.Point(66, 49);
			this.textBox_N.Name = "textBox_N";
			this.textBox_N.Size = new System.Drawing.Size(143, 20);
			this.textBox_N.TabIndex = 3;
			this.textBox_N.Text = "2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "P0";
			// 
			// textBox_P0
			// 
			this.textBox_P0.Location = new System.Drawing.Point(66, 23);
			this.textBox_P0.Name = "textBox_P0";
			this.textBox_P0.Size = new System.Drawing.Size(143, 20);
			this.textBox_P0.TabIndex = 1;
			this.textBox_P0.Text = "2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "шаги";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
			this.dataGridView1.Location = new System.Drawing.Point(0, 293);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(872, 209);
			this.dataGridView1.TabIndex = 1;
			// 
			// label_IdelQuant
			// 
			this.label_IdelQuant.AutoSize = true;
			this.label_IdelQuant.Location = new System.Drawing.Point(18, 245);
			this.label_IdelQuant.Name = "label_IdelQuant";
			this.label_IdelQuant.Size = new System.Drawing.Size(100, 13);
			this.label_IdelQuant.TabIndex = 2;
			this.label_IdelQuant.Text = "Идеальный квант:";
			this.label_IdelQuant.Visible = false;
			// 
			// label_Maximum
			// 
			this.label_Maximum.AutoSize = true;
			this.label_Maximum.Location = new System.Drawing.Point(18, 232);
			this.label_Maximum.Name = "label_Maximum";
			this.label_Maximum.Size = new System.Drawing.Size(64, 13);
			this.label_Maximum.TabIndex = 3;
			this.label_Maximum.Text = "Максимум:";
			this.label_Maximum.Visible = false;
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.zedGraphControl1.Location = new System.Drawing.Point(244, 12);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(616, 265);
			this.zedGraphControl1.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(872, 502);
			this.Controls.Add(this.zedGraphControl1);
			this.Controls.Add(this.label_Maximum);
			this.Controls.Add(this.label_IdelQuant);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(732, 508);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_Gamma;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_N;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_P0;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label_IdelQuant;
		private System.Windows.Forms.Label label_Maximum;
		private ZedGraph.ZedGraphControl zedGraphControl1;
	}
}

