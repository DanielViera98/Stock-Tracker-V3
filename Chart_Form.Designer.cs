namespace COP4365_Project2
{
    partial class Chart_Form
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
            System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation rectangleAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45077D, "13.600000381469727,15.104999542236328,13.350000381469727,14.779999732971191");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45107D, "14.869999885559082,17.989999771118164,14.609999656677246,17.940000534057617");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45138D, "17.860000610351562,19.079999923706055,16.190000534057617,16.75");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45142D, "16.540000915527344,16.540000915527344,15.699999809265137,15.84000015258789");
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart_stocks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            comboBox_selectProperty = new ComboBox();
            button_UpdateChart = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)chart_stocks).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // chart_stocks
            // 
            rectangleAnnotation1.AnchorDataPointName = "cStocks\\r0";
            rectangleAnnotation1.AnchorY = 15D;
            rectangleAnnotation1.BackColor = Color.Transparent;
            rectangleAnnotation1.Height = 6D;
            rectangleAnnotation1.IsSizeAlwaysRelative = false;
            rectangleAnnotation1.LineWidth = 5;
            rectangleAnnotation1.Name = "RectangleAnnotation1";
            rectangleAnnotation1.ShadowColor = Color.Transparent;
            rectangleAnnotation1.Text = "RectangleAnnotation1";
            rectangleAnnotation1.Width = 1D;
            chart_stocks.Annotations.Add(rectangleAnnotation1);
            chart_stocks.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chart_stocks.BorderSkin.BorderWidth = 4;
            chartArea1.Name = "ChartAreaCandles";
            chartArea2.Name = "ChartAreaVolumes";
            chart_stocks.ChartAreas.Add(chartArea1);
            chart_stocks.ChartAreas.Add(chartArea2);
            chart_stocks.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chart_stocks.Legends.Add(legend1);
            chart_stocks.Location = new Point(0, 0);
            chart_stocks.Name = "chart_stocks";
            series1.BackSecondaryColor = Color.Black;
            series1.BorderColor = Color.Black;
            series1.ChartArea = "ChartAreaCandles";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "cStocks";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High, Low, Open, Close";
            series1.YValuesPerPoint = 4;
            series2.BorderColor = Color.Black;
            series2.ChartArea = "ChartAreaVolumes";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "cVolumes";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            chart_stocks.Series.Add(series1);
            chart_stocks.Series.Add(series2);
            chart_stocks.Size = new Size(899, 363);
            chart_stocks.TabIndex = 0;
            chart_stocks.Text = "chart1";
            // 
            // panel1
            // 
            panel1.Controls.Add(chart_stocks);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(899, 363);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button_UpdateChart);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dateTimePickerEnd);
            panel2.Controls.Add(dateTimePickerStart);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 363);
            panel2.MaximumSize = new Size(899, 109);
            panel2.MinimumSize = new Size(615, 87);
            panel2.Name = "panel2";
            panel2.Size = new Size(899, 109);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(comboBox_selectProperty);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(599, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 109);
            panel3.TabIndex = 7;
            // 
            // comboBox_selectProperty
            // 
            comboBox_selectProperty.Anchor = AnchorStyles.None;
            comboBox_selectProperty.FormattingEnabled = true;
            comboBox_selectProperty.Location = new Point(59, 11);
            comboBox_selectProperty.Name = "comboBox_selectProperty";
            comboBox_selectProperty.Size = new Size(182, 33);
            comboBox_selectProperty.TabIndex = 6;
            comboBox_selectProperty.Text = "Select a Property";
            comboBox_selectProperty.SelectedIndexChanged += showProperty_Select;
            // 
            // button_UpdateChart
            // 
            button_UpdateChart.Anchor = AnchorStyles.None;
            button_UpdateChart.Location = new Point(40, 21);
            button_UpdateChart.Name = "button_UpdateChart";
            button_UpdateChart.Size = new Size(130, 69);
            button_UpdateChart.TabIndex = 4;
            button_UpdateChart.Text = "Update Chart";
            button_UpdateChart.UseVisualStyleBackColor = true;
            button_UpdateChart.Click += button_UpdateChart_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(196, 63);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 3;
            label2.Text = "End Time";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(196, 26);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 2;
            label1.Text = "Start Time";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.None;
            dateTimePickerEnd.Location = new Point(293, 58);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(300, 31);
            dateTimePickerEnd.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.None;
            dateTimePickerStart.Location = new Point(293, 21);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(300, 31);
            dateTimePickerStart.TabIndex = 0;
            // 
            // Chart_Form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 472);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(615, 0);
            Name = "Chart_Form";
            Text = "Chart_Form";
            ((System.ComponentModel.ISupportInitialize)chart_stocks).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stocks;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Button button_UpdateChart;
        private Label label2;
        private Panel panel3;
        private ComboBox comboBox_selectProperty;
    }
}