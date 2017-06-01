namespace Paint
{
    partial class ConfigsForm
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
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxOpacity = new System.Windows.Forms.TextBox();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(26, 202);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(109, 36);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(174, 202);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 36);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWidth.Location = new System.Drawing.Point(47, 28);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(44, 17);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeight.Location = new System.Drawing.Point(47, 66);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(49, 17);
            this.labelHeight.TabIndex = 0;
            this.labelHeight.Text = "Height";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpacity.Location = new System.Drawing.Point(47, 107);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(56, 17);
            this.labelOpacity.TabIndex = 0;
            this.labelOpacity.Text = "Opacity";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(117, 28);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(133, 20);
            this.textBoxWidth.TabIndex = 1;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(117, 66);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(133, 20);
            this.textBoxHeight.TabIndex = 2;
            // 
            // textBoxOpacity
            // 
            this.textBoxOpacity.Location = new System.Drawing.Point(117, 107);
            this.textBoxOpacity.Name = "textBoxOpacity";
            this.textBoxOpacity.Size = new System.Drawing.Size(133, 20);
            this.textBoxOpacity.TabIndex = 3;
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(101, 146);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(109, 36);
            this.buttonBackground.TabIndex = 4;
            this.buttonBackground.Text = "Choose background color";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // ConfigsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 290);
            this.Controls.Add(this.textBoxOpacity);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigsForm";
            this.Text = "Configs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxOpacity;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}