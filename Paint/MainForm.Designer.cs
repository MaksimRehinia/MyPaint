namespace Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {           
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.button_Color = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonClean = new System.Windows.Forms.Button();
            this.textBoxPenWidth = new System.Windows.Forms.TextBox();
            this.labelPenWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(127, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(579, 337);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Line",
            "Oval",
            "Rectangle"});
            this.checkedListBox.Location = new System.Drawing.Point(1, 134);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(120, 79);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.Click += new System.EventHandler(this.checkedListBox1_Click);
            // 
            // button_Color
            // 
            this.button_Color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Color.Location = new System.Drawing.Point(12, 61);
            this.button_Color.Name = "button_Color";
            this.button_Color.Size = new System.Drawing.Size(98, 30);
            this.button_Color.TabIndex = 3;
            this.button_Color.Text = "Change color";
            this.button_Color.UseVisualStyleBackColor = true;
            this.button_Color.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 219);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(118, 60);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Note: Press \"Letf Shift\"\r\n while drawing to\r\n create straight line,\r\n circle, squ" +
    "are.";
            // 
            // buttonClean
            // 
            this.buttonClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClean.Location = new System.Drawing.Point(12, 97);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(98, 31);
            this.buttonClean.TabIndex = 6;
            this.buttonClean.Text = "Clean field";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // textBoxPenWidth
            // 
            this.textBoxPenWidth.Location = new System.Drawing.Point(12, 35);
            this.textBoxPenWidth.Name = "textBoxPenWidth";
            this.textBoxPenWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxPenWidth.TabIndex = 7;
            this.textBoxPenWidth.Text = "2";
            this.textBoxPenWidth.TextChanged += new System.EventHandler(this.textBoxPenWidth_TextChanged);
            // 
            // labelPenWidth
            // 
            this.labelPenWidth.AutoSize = true;
            this.labelPenWidth.Location = new System.Drawing.Point(14, 19);
            this.labelPenWidth.Name = "labelPenWidth";
            this.labelPenWidth.Size = new System.Drawing.Size(96, 13);
            this.labelPenWidth.TabIndex = 8;
            this.labelPenWidth.Text = "Change pen width:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 361);
            this.Controls.Add(this.labelPenWidth);
            this.Controls.Add(this.textBoxPenWidth);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Color);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "MyPaint";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button button_Color;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.TextBox textBoxPenWidth;
        private System.Windows.Forms.Label labelPenWidth;
    }
}

