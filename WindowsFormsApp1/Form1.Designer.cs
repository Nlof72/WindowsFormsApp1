
namespace WindowsFormsApp1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LifeLevInp = new System.Windows.Forms.NumericUpDown();
            this.PopulationInp = new System.Windows.Forms.NumericUpDown();
            this.CandidatesInp = new System.Windows.Forms.NumericUpDown();
            this.ConditionsInp = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.CurrentLifeInp = new System.Windows.Forms.NumericUpDown();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RedOutput = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LifeLevInp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationInp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandidatesInp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionsInp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLifeInp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // LifeLevInp
            // 
            this.LifeLevInp.Location = new System.Drawing.Point(11, 52);
            this.LifeLevInp.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LifeLevInp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LifeLevInp.Name = "LifeLevInp";
            this.LifeLevInp.Size = new System.Drawing.Size(120, 22);
            this.LifeLevInp.TabIndex = 0;
            this.LifeLevInp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // PopulationInp
            // 
            this.PopulationInp.Location = new System.Drawing.Point(193, 52);
            this.PopulationInp.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.PopulationInp.Name = "PopulationInp";
            this.PopulationInp.Size = new System.Drawing.Size(120, 22);
            this.PopulationInp.TabIndex = 1;
            this.PopulationInp.ThousandsSeparator = true;
            this.PopulationInp.Value = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            // 
            // CandidatesInp
            // 
            this.CandidatesInp.Location = new System.Drawing.Point(361, 52);
            this.CandidatesInp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CandidatesInp.Name = "CandidatesInp";
            this.CandidatesInp.Size = new System.Drawing.Size(120, 22);
            this.CandidatesInp.TabIndex = 2;
            this.CandidatesInp.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ConditionsInp
            // 
            this.ConditionsInp.Location = new System.Drawing.Point(519, 53);
            this.ConditionsInp.Name = "ConditionsInp";
            this.ConditionsInp.Size = new System.Drawing.Size(120, 22);
            this.ConditionsInp.TabIndex = 4;
            this.ConditionsInp.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Желаемый ур. жизни";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Население";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Кандидаты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Требуемая явка";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CurrentLifeInp);
            this.panel1.Controls.Add(this.ConditionsInp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LifeLevInp);
            this.panel1.Controls.Add(this.PopulationInp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CandidatesInp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 100);
            this.panel1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(677, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Текущий уровень жизни";
            // 
            // CurrentLifeInp
            // 
            this.CurrentLifeInp.Location = new System.Drawing.Point(680, 52);
            this.CurrentLifeInp.Name = "CurrentLifeInp";
            this.CurrentLifeInp.Size = new System.Drawing.Size(120, 22);
            this.CurrentLifeInp.TabIndex = 10;
            this.CurrentLifeInp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, 107);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(800, 291);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // RedOutput
            // 
            this.RedOutput.Location = new System.Drawing.Point(162, 416);
            this.RedOutput.Name = "RedOutput";
            this.RedOutput.Size = new System.Drawing.Size(216, 22);
            this.RedOutput.TabIndex = 12;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(499, 415);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 13;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 455);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.RedOutput);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LifeLevInp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationInp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandidatesInp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionsInp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLifeInp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown LifeLevInp;
        private System.Windows.Forms.NumericUpDown PopulationInp;
        private System.Windows.Forms.NumericUpDown CandidatesInp;
        private System.Windows.Forms.NumericUpDown ConditionsInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox RedOutput;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown CurrentLifeInp;
    }
}

