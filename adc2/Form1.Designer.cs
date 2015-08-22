namespace adc2
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
			this._nNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label_n = new System.Windows.Forms.Label();
			this.label_u0 = new System.Windows.Forms.Label();
			this._u0NumericUpDown = new System.Windows.Forms.NumericUpDown();
			this._richTextBox = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
			this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this._kNumericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this._nNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._u0NumericUpDown)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._kNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// _nNumericUpDown
			// 
			this._nNumericUpDown.Location = new System.Drawing.Point(193, 7);
			this._nNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this._nNumericUpDown.Name = "_nNumericUpDown";
			this._nNumericUpDown.Size = new System.Drawing.Size(94, 20);
			this._nNumericUpDown.TabIndex = 0;
			this._nNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			// 
			// label_n
			// 
			this.label_n.AutoSize = true;
			this.label_n.Location = new System.Drawing.Point(12, 9);
			this.label_n.Name = "label_n";
			this.label_n.Size = new System.Drawing.Size(175, 13);
			this.label_n.TabIndex = 1;
			this.label_n.Text = "Число разрядов двоичного кода:";
			// 
			// label_u0
			// 
			this.label_u0.AutoSize = true;
			this.label_u0.Location = new System.Drawing.Point(12, 32);
			this.label_u0.Name = "label_u0";
			this.label_u0.Size = new System.Drawing.Size(97, 13);
			this.label_u0.TabIndex = 2;
			this.label_u0.Text = "Нулевой уровень:";
			// 
			// _u0NumericUpDown
			// 
			this._u0NumericUpDown.DecimalPlaces = 2;
			this._u0NumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this._u0NumericUpDown.Location = new System.Drawing.Point(193, 33);
			this._u0NumericUpDown.Name = "_u0NumericUpDown";
			this._u0NumericUpDown.Size = new System.Drawing.Size(94, 20);
			this._u0NumericUpDown.TabIndex = 3;
			this._u0NumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
			// 
			// _richTextBox
			// 
			this._richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._richTextBox.Location = new System.Drawing.Point(12, 365);
			this._richTextBox.Name = "_richTextBox";
			this._richTextBox.Size = new System.Drawing.Size(906, 131);
			this._richTextBox.TabIndex = 4;
			this._richTextBox.Text = "";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(583, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(335, 49);
			this.button1.TabIndex = 5;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.zedGraphControl3);
			this.panel1.Controls.Add(this.zedGraphControl2);
			this.panel1.Controls.Add(this.zedGraphControl1);
			this.panel1.Location = new System.Drawing.Point(15, 59);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(903, 291);
			this.panel1.TabIndex = 6;
			// 
			// zedGraphControl3
			// 
			this.zedGraphControl3.Location = new System.Drawing.Point(14, 547);
			this.zedGraphControl3.Name = "zedGraphControl3";
			this.zedGraphControl3.ScrollGrace = 0D;
			this.zedGraphControl3.ScrollMaxX = 0D;
			this.zedGraphControl3.ScrollMaxY = 0D;
			this.zedGraphControl3.ScrollMaxY2 = 0D;
			this.zedGraphControl3.ScrollMinX = 0D;
			this.zedGraphControl3.ScrollMinY = 0D;
			this.zedGraphControl3.ScrollMinY2 = 0D;
			this.zedGraphControl3.Size = new System.Drawing.Size(870, 267);
			this.zedGraphControl3.TabIndex = 2;
			// 
			// zedGraphControl2
			// 
			this.zedGraphControl2.Location = new System.Drawing.Point(14, 276);
			this.zedGraphControl2.Name = "zedGraphControl2";
			this.zedGraphControl2.ScrollGrace = 0D;
			this.zedGraphControl2.ScrollMaxX = 0D;
			this.zedGraphControl2.ScrollMaxY = 0D;
			this.zedGraphControl2.ScrollMaxY2 = 0D;
			this.zedGraphControl2.ScrollMinX = 0D;
			this.zedGraphControl2.ScrollMinY = 0D;
			this.zedGraphControl2.ScrollMinY2 = 0D;
			this.zedGraphControl2.Size = new System.Drawing.Size(870, 267);
			this.zedGraphControl2.TabIndex = 1;
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Location = new System.Drawing.Point(14, 3);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(870, 267);
			this.zedGraphControl1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(302, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Число интервалов гистограммы:";
			// 
			// _kNumericUpDown
			// 
			this._kNumericUpDown.Location = new System.Drawing.Point(483, 7);
			this._kNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this._kNumericUpDown.Name = "_kNumericUpDown";
			this._kNumericUpDown.Size = new System.Drawing.Size(94, 20);
			this._kNumericUpDown.TabIndex = 7;
			this._kNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(930, 508);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._kNumericUpDown);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this._richTextBox);
			this.Controls.Add(this._u0NumericUpDown);
			this.Controls.Add(this.label_u0);
			this.Controls.Add(this.label_n);
			this.Controls.Add(this._nNumericUpDown);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this._nNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._u0NumericUpDown)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._kNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _nNumericUpDown;
        private System.Windows.Forms.Label label_n;
		private System.Windows.Forms.Label label_u0;
		private System.Windows.Forms.NumericUpDown _u0NumericUpDown;
		private System.Windows.Forms.RichTextBox _richTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private ZedGraph.ZedGraphControl zedGraphControl2;
		private ZedGraph.ZedGraphControl zedGraphControl1;
		private ZedGraph.ZedGraphControl zedGraphControl3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _kNumericUpDown;
	}
}

