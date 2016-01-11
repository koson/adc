namespace adc3
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.n_label = new System.Windows.Forms.Label();
            this.n_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.a_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.p0_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.s_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.r_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.q_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.n_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p0_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.q_numericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(715, 328);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Location = new System.Drawing.Point(12, 9);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(88, 13);
            this.n_label.TabIndex = 1;
            this.n_label.Text = "Разрядность(n):";
            // 
            // n_numericUpDown
            // 
            this.n_numericUpDown.Location = new System.Drawing.Point(158, 7);
            this.n_numericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.n_numericUpDown.Name = "n_numericUpDown";
            this.n_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.n_numericUpDown.TabIndex = 2;
            this.n_numericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // a_numericUpDown
            // 
            this.a_numericUpDown.Location = new System.Drawing.Point(158, 33);
            this.a_numericUpDown.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.a_numericUpDown.Name = "a_numericUpDown";
            this.a_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.a_numericUpDown.TabIndex = 4;
            this.a_numericUpDown.Value = new decimal(new int[] {
            67,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Положение концевиков(a):";
            // 
            // p0_numericUpDown
            // 
            this.p0_numericUpDown.DecimalPlaces = 2;
            this.p0_numericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.p0_numericUpDown.Location = new System.Drawing.Point(158, 59);
            this.p0_numericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.p0_numericUpDown.Minimum = new decimal(new int[] {
            276447231,
            23283,
            0,
            -2147483648});
            this.p0_numericUpDown.Name = "p0_numericUpDown";
            this.p0_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.p0_numericUpDown.TabIndex = 6;
            this.p0_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Шаг квантования(P0):";
            // 
            // s_numericUpDown
            // 
            this.s_numericUpDown.DecimalPlaces = 2;
            this.s_numericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.s_numericUpDown.Location = new System.Drawing.Point(158, 85);
            this.s_numericUpDown.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.s_numericUpDown.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.s_numericUpDown.Name = "s_numericUpDown";
            this.s_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.s_numericUpDown.TabIndex = 9;
            this.s_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sфп:";
            // 
            // r_numericUpDown
            // 
            this.r_numericUpDown.DecimalPlaces = 2;
            this.r_numericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.r_numericUpDown.Location = new System.Drawing.Point(158, 111);
            this.r_numericUpDown.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.r_numericUpDown.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.r_numericUpDown.Name = "r_numericUpDown";
            this.r_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.r_numericUpDown.TabIndex = 10;
            this.r_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rос:";
            // 
            // q_numericUpDown
            // 
            this.q_numericUpDown.DecimalPlaces = 2;
            this.q_numericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.q_numericUpDown.Location = new System.Drawing.Point(235, 137);
            this.q_numericUpDown.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.q_numericUpDown.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.q_numericUpDown.Name = "q_numericUpDown";
            this.q_numericUpDown.Size = new System.Drawing.Size(86, 20);
            this.q_numericUpDown.TabIndex = 12;
            this.q_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Коэффициент энергетических потерь(Qi):";
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(480, 12);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(176, 123);
            this.start_button.TabIndex = 13;
            this.start_button.Text = "Старт";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 163);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 360);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zedGraphControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "График";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Лог";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(715, 328);
            this.zedGraphControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 519);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.q_numericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.r_numericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.s_numericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.p0_numericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.a_numericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.n_numericUpDown);
            this.Controls.Add(this.n_label);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.n_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p0_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.q_numericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.NumericUpDown n_numericUpDown;
        private System.Windows.Forms.NumericUpDown a_numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown p0_numericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown s_numericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown r_numericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown q_numericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}

