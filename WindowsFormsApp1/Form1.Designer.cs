namespace Lab_4
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_LeftBorder = new System.Windows.Forms.TextBox();
            this.tb_RightBorder = new System.Windows.Forms.TextBox();
            this.tb_Step = new System.Windows.Forms.TextBox();
            this.tb_PolPow = new System.Windows.Forms.TextBox();
            this.tb_X = new System.Windows.Forms.TextBox();
            this.tb_Y = new System.Windows.Forms.TextBox();
            this.but_Enter = new System.Windows.Forms.Button();
            this.but_Calc = new System.Windows.Forms.Button();
            this.but_Build = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(4, 107);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(870, 589);
            this.zedGraphControl1.TabIndex = 19;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(881, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "Левая граница";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(882, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 30);
            this.label2.TabIndex = 21;
            this.label2.Text = "Правая граница";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(886, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 30);
            this.label3.TabIndex = 22;
            this.label3.Text = "Кол-во точек";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(886, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 30);
            this.label4.TabIndex = 23;
            this.label4.Text = "Степень полинома";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(913, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 30);
            this.label5.TabIndex = 24;
            this.label5.Text = "Х";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(903, 500);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 31);
            this.label6.TabIndex = 25;
            this.label6.Text = "Y(x)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tb_LeftBorder
            // 
            this.tb_LeftBorder.Location = new System.Drawing.Point(1073, 107);
            this.tb_LeftBorder.Name = "tb_LeftBorder";
            this.tb_LeftBorder.Size = new System.Drawing.Size(108, 26);
            this.tb_LeftBorder.TabIndex = 26;
            // 
            // tb_RightBorder
            // 
            this.tb_RightBorder.Location = new System.Drawing.Point(1090, 158);
            this.tb_RightBorder.Name = "tb_RightBorder";
            this.tb_RightBorder.Size = new System.Drawing.Size(100, 26);
            this.tb_RightBorder.TabIndex = 27;
            // 
            // tb_Step
            // 
            this.tb_Step.Location = new System.Drawing.Point(1062, 222);
            this.tb_Step.Name = "tb_Step";
            this.tb_Step.Size = new System.Drawing.Size(100, 26);
            this.tb_Step.TabIndex = 28;
            // 
            // tb_PolPow
            // 
            this.tb_PolPow.Location = new System.Drawing.Point(1139, 283);
            this.tb_PolPow.Name = "tb_PolPow";
            this.tb_PolPow.Size = new System.Drawing.Size(100, 26);
            this.tb_PolPow.TabIndex = 29;
            // 
            // tb_X
            // 
            this.tb_X.Location = new System.Drawing.Point(950, 455);
            this.tb_X.Name = "tb_X";
            this.tb_X.Size = new System.Drawing.Size(134, 26);
            this.tb_X.TabIndex = 30;
            this.tb_X.TextChanged += new System.EventHandler(this.tb_X_TextChanged);
            // 
            // tb_Y
            // 
            this.tb_Y.Location = new System.Drawing.Point(986, 500);
            this.tb_Y.Name = "tb_Y";
            this.tb_Y.ReadOnly = true;
            this.tb_Y.Size = new System.Drawing.Size(237, 26);
            this.tb_Y.TabIndex = 31;
            this.tb_Y.TextChanged += new System.EventHandler(this.tb_Y_TextChanged);
            // 
            // but_Enter
            // 
            this.but_Enter.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.but_Enter.Location = new System.Drawing.Point(891, 348);
            this.but_Enter.Name = "but_Enter";
            this.but_Enter.Size = new System.Drawing.Size(197, 87);
            this.but_Enter.TabIndex = 32;
            this.but_Enter.Text = "Ввести";
            this.but_Enter.UseVisualStyleBackColor = true;
            this.but_Enter.Click += new System.EventHandler(this.but_Enter_Click_1);
            // 
            // but_Calc
            // 
            this.but_Calc.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.but_Calc.Location = new System.Drawing.Point(891, 610);
            this.but_Calc.Name = "but_Calc";
            this.but_Calc.Size = new System.Drawing.Size(384, 67);
            this.but_Calc.TabIndex = 33;
            this.but_Calc.Text = "Вычислить значение ф-ции";
            this.but_Calc.UseVisualStyleBackColor = true;
            this.but_Calc.Click += new System.EventHandler(this.but_Calc_Click);
            // 
            // but_Build
            // 
            this.but_Build.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.but_Build.Location = new System.Drawing.Point(1102, 348);
            this.but_Build.Name = "but_Build";
            this.but_Build.Size = new System.Drawing.Size(181, 87);
            this.but_Build.TabIndex = 34;
            this.but_Build.Text = "Построить";
            this.but_Build.UseVisualStyleBackColor = true;
            this.but_Build.Click += new System.EventHandler(this.but_Build_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(891, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(384, 56);
            this.button1.TabIndex = 35;
            this.button1.Text = "Открыть файл с точками";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(4, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(940, 82);
            this.label7.TabIndex = 36;
            this.label7.Text = "x*Sin(x)+Exp(-x)*x^2*Cos(x)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1295, 763);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.but_Build);
            this.Controls.Add(this.but_Calc);
            this.Controls.Add(this.but_Enter);
            this.Controls.Add(this.tb_Y);
            this.Controls.Add(this.tb_X);
            this.Controls.Add(this.tb_PolPow);
            this.Controls.Add(this.tb_Step);
            this.Controls.Add(this.tb_RightBorder);
            this.Controls.Add(this.tb_LeftBorder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_LeftBorder;
        private System.Windows.Forms.TextBox tb_RightBorder;
        private System.Windows.Forms.TextBox tb_Step;
        private System.Windows.Forms.TextBox tb_PolPow;
        private System.Windows.Forms.TextBox tb_X;
        private System.Windows.Forms.TextBox tb_Y;
        private System.Windows.Forms.Button but_Enter;
        private System.Windows.Forms.Button but_Calc;
        private System.Windows.Forms.Button but_Build;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}

