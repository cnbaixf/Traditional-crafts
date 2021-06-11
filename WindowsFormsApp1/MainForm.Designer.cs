
namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myButton9 = new ControlLibrary.MyButton();
            this.myButton8 = new ControlLibrary.MyButton();
            this.myButton1 = new ControlLibrary.MyButton();
            this.myButton2 = new ControlLibrary.MyButton();
            this.myButton3 = new ControlLibrary.MyButton();
            this.myButton4 = new ControlLibrary.MyButton();
            this.myButton5 = new ControlLibrary.MyButton();
            this.myButton6 = new ControlLibrary.MyButton();
            this.myButton7 = new ControlLibrary.MyButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(184, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 224);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.myButton1);
            this.flowLayoutPanel1.Controls.Add(this.myButton2);
            this.flowLayoutPanel1.Controls.Add(this.myButton3);
            this.flowLayoutPanel1.Controls.Add(this.myButton4);
            this.flowLayoutPanel1.Controls.Add(this.myButton5);
            this.flowLayoutPanel1.Controls.Add(this.myButton6);
            this.flowLayoutPanel1.Controls.Add(this.myButton7);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(796, 34);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(103, 224);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(305, 144);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 230);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(365, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 100);
            this.panel2.TabIndex = 6;
            // 
            // myButton9
            // 
            this.myButton9.BorderColor = System.Drawing.Color.DarkRed;
            this.myButton9.FocusedBackColor = System.Drawing.Color.ForestGreen;
            this.myButton9.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton9.HighLightBackColor = System.Drawing.Color.Red;
            this.myButton9.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton9.Image = null;
            this.myButton9.Location = new System.Drawing.Point(824, 234);
            this.myButton9.Name = "myButton9";
            this.myButton9.Size = new System.Drawing.Size(100, 28);
            this.myButton9.TabIndex = 8;
            this.myButton9.Text = "myButton9";
            this.myButton9.UseVisualStyleBackColor = true;
            // 
            // myButton8
            // 
            this.myButton8.BorderColor = System.Drawing.Color.Black;
            this.myButton8.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton8.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton8.FocusedBorderWidth = 0;
            this.myButton8.HeightLightBorderWidth = 0;
            this.myButton8.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton8.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton8.Image = null;
            this.myButton8.Location = new System.Drawing.Point(1097, 1);
            this.myButton8.Name = "myButton8";
            this.myButton8.Size = new System.Drawing.Size(32, 33);
            this.myButton8.TabIndex = 7;
            this.myButton8.Text = "×";
            this.myButton8.UseVisualStyleBackColor = true;
            this.myButton8.Click += new System.EventHandler(this.myButton8_Click);
            // 
            // myButton1
            // 
            this.myButton1.BorderColor = System.Drawing.Color.Black;
            this.myButton1.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton1.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton1.FocusedBorderWidth = 0;
            this.myButton1.HeightLightBorderWidth = 0;
            this.myButton1.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton1.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton1.Image = null;
            this.myButton1.Location = new System.Drawing.Point(3, 3);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(100, 28);
            this.myButton1.TabIndex = 7;
            this.myButton1.Text = "Animation";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.BorderColor = System.Drawing.Color.Black;
            this.myButton2.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton2.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton2.FocusedBorderWidth = 0;
            this.myButton2.HeightLightBorderWidth = 0;
            this.myButton2.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton2.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton2.Image = null;
            this.myButton2.Location = new System.Drawing.Point(109, 3);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(100, 28);
            this.myButton2.TabIndex = 8;
            this.myButton2.Text = "Movie";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton3
            // 
            this.myButton3.BorderColor = System.Drawing.Color.Black;
            this.myButton3.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton3.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton3.FocusedBorderWidth = 0;
            this.myButton3.HeightLightBorderWidth = 0;
            this.myButton3.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton3.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton3.Image = null;
            this.myButton3.Location = new System.Drawing.Point(215, 3);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(100, 28);
            this.myButton3.TabIndex = 9;
            this.myButton3.Text = "Comic";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.myButton4.BorderColor = System.Drawing.Color.Black;
            this.myButton4.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton4.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton4.FocusedBorderWidth = 0;
            this.myButton4.HeightLightBorderWidth = 0;
            this.myButton4.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton4.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton4.Image = null;
            this.myButton4.Location = new System.Drawing.Point(321, 3);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(100, 28);
            this.myButton4.TabIndex = 10;
            this.myButton4.Text = "Picture";
            this.myButton4.UseVisualStyleBackColor = false;
            // 
            // myButton5
            // 
            this.myButton5.BorderColor = System.Drawing.Color.Black;
            this.myButton5.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton5.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton5.FocusedBorderWidth = 0;
            this.myButton5.HeightLightBorderWidth = 0;
            this.myButton5.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton5.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton5.Image = null;
            this.myButton5.Location = new System.Drawing.Point(427, 3);
            this.myButton5.Name = "myButton5";
            this.myButton5.Size = new System.Drawing.Size(100, 28);
            this.myButton5.TabIndex = 11;
            this.myButton5.Text = "Novel";
            this.myButton5.UseVisualStyleBackColor = true;
            // 
            // myButton6
            // 
            this.myButton6.BorderColor = System.Drawing.Color.Black;
            this.myButton6.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton6.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton6.FocusedBorderWidth = 0;
            this.myButton6.HeightLightBorderWidth = 0;
            this.myButton6.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton6.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton6.Image = null;
            this.myButton6.Location = new System.Drawing.Point(533, 3);
            this.myButton6.Name = "myButton6";
            this.myButton6.Size = new System.Drawing.Size(100, 28);
            this.myButton6.TabIndex = 12;
            this.myButton6.Text = "Music";
            this.myButton6.UseVisualStyleBackColor = true;
            // 
            // myButton7
            // 
            this.myButton7.BorderColor = System.Drawing.Color.Black;
            this.myButton7.FocusedBackColor = System.Drawing.Color.Transparent;
            this.myButton7.FocusedBorderColor = System.Drawing.Color.Black;
            this.myButton7.FocusedBorderWidth = 0;
            this.myButton7.HeightLightBorderWidth = 0;
            this.myButton7.HighLightBackColor = System.Drawing.Color.Transparent;
            this.myButton7.HighLightBorderColor = System.Drawing.Color.Black;
            this.myButton7.Image = null;
            this.myButton7.Location = new System.Drawing.Point(639, 3);
            this.myButton7.Name = "myButton7";
            this.myButton7.Size = new System.Drawing.Size(100, 28);
            this.myButton7.TabIndex = 13;
            this.myButton7.Text = "Game";
            this.myButton7.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1129, 599);
            this.Controls.Add(this.myButton9);
            this.Controls.Add(this.myButton8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.MyButton myButton1;
        private ControlLibrary.MyButton myButton2;
        private ControlLibrary.MyButton myButton3;
        private ControlLibrary.MyButton myButton4;
        private ControlLibrary.MyButton myButton5;
        private ControlLibrary.MyButton myButton6;
        private ControlLibrary.MyButton myButton7;
        private ControlLibrary.MyButton myButton8;
        private ControlLibrary.MyButton myButton9;
    }
}

