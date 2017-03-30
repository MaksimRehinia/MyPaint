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
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.buttonClean = new System.Windows.Forms.Button();
            this.textBoxPenWidth = new System.Windows.Forms.TextBox();
            this.labelPenWidth = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(147, 51);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(724, 337);
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
            this.checkedListBox.Location = new System.Drawing.Point(1, 51);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.ScrollAlwaysVisible = true;
            this.checkedListBox.Size = new System.Drawing.Size(140, 154);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.Click += new System.EventHandler(this.checkedListBox1_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColor.Location = new System.Drawing.Point(268, 9);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(100, 31);
            this.buttonColor.TabIndex = 3;
            this.buttonColor.Text = "Change color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(1, 220);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.ReadOnly = true;
            this.textBoxNote.Size = new System.Drawing.Size(118, 60);
            this.textBoxNote.TabIndex = 5;
            this.textBoxNote.Text = "Note: Press \"Letf Shift\"\r\n while drawing to\r\n create straight line,\r\n circle, squ" +
    "are.";
            // 
            // buttonClean
            // 
            this.buttonClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClean.Location = new System.Drawing.Point(147, 9);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(100, 31);
            this.buttonClean.TabIndex = 6;
            this.buttonClean.Text = "Clean field";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // textBoxPenWidth
            // 
            this.textBoxPenWidth.Location = new System.Drawing.Point(10, 25);
            this.textBoxPenWidth.Name = "textBoxPenWidth";
            this.textBoxPenWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxPenWidth.TabIndex = 7;
            this.textBoxPenWidth.Text = "2";
            this.textBoxPenWidth.TextChanged += new System.EventHandler(this.textBoxPenWidth_TextChanged);
            // 
            // labelPenWidth
            // 
            this.labelPenWidth.AutoSize = true;
            this.labelPenWidth.Location = new System.Drawing.Point(14, 9);
            this.labelPenWidth.Name = "labelPenWidth";
            this.labelPenWidth.Size = new System.Drawing.Size(96, 13);
            this.labelPenWidth.TabIndex = 8;
            this.labelPenWidth.Text = "Change pen width:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(390, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 31);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save picture";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(511, 9);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 31);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load picture";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 394);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPenWidth);
            this.Controls.Add(this.textBoxPenWidth);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.buttonColor);
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
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.TextBox textBoxPenWidth;
        private System.Windows.Forms.Label labelPenWidth;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

