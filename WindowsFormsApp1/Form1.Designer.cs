
namespace WindowsFormsApp1
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
            this.myButton1 = new ControlLibrary.MyButton1();
            this.myButton2 = new ControlLibrary.MyButton1();
            this.myButton21 = new ControlLibrary.MyButton2();
            this.SuspendLayout();
            // 
            // myButton1
            // 
            this.myButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton1.DefaultBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton1.DefaultBorderColor = System.Drawing.Color.Black;
            this.myButton1.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton1.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton1.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton1.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton1.Image = null;
            this.myButton1.Location = new System.Drawing.Point(253, 90);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(100, 28);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = false;
            // 
            // myButton2
            // 
            this.myButton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton2.DefaultBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton2.DefaultBorderColor = System.Drawing.Color.Black;
            this.myButton2.FocusedBackColor = System.Drawing.Color.Maroon;
            this.myButton2.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton2.HighLightBackColor = System.Drawing.Color.DarkRed;
            this.myButton2.HighLightBorderColor = System.Drawing.Color.Gainsboro;
            this.myButton2.Image = null;
            this.myButton2.Location = new System.Drawing.Point(311, 204);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(100, 28);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = false;
            // 
            // myButton21
            // 
            this.myButton21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton21.DefaultBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myButton21.DefaultBorderColor = System.Drawing.Color.Red;
            this.myButton21.DefaultBorderWidth = 5;
            this.myButton21.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton21.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton21.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton21.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton21.Image = null;
            this.myButton21.Location = new System.Drawing.Point(506, 128);
            this.myButton21.Name = "myButton21";
            this.myButton21.Size = new System.Drawing.Size(100, 28);
            this.myButton21.TabIndex = 2;
            this.myButton21.Text = "myButton21";
            this.myButton21.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.myButton21.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myButton21);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.MyButton1 myButton1;
        private ControlLibrary.MyButton1 myButton2;
        private ControlLibrary.MyButton2 myButton21;
    }
}