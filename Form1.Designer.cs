namespace COP4365_Project2
{
    partial class Form_Entry
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog_stocks = new OpenFileDialog();
            button_loadStocks = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            SuspendLayout();
            // 
            // openFileDialog_stocks
            // 
            openFileDialog_stocks.Filter = "All Stocks|*.*|Day Stocks|*Day*|Week Stocks|*Week*|Month Stocks|*Month*";
            openFileDialog_stocks.InitialDirectory = "C:\\Users\\dvier\\source\\repos\\Stock Data";
            openFileDialog_stocks.Multiselect = true;
            openFileDialog_stocks.FileOk += openFileDialog_stocks_FileOk;
            // 
            // button_loadStocks
            // 
            button_loadStocks.Anchor = AnchorStyles.None;
            button_loadStocks.Location = new Point(438, 11);
            button_loadStocks.Name = "button_loadStocks";
            button_loadStocks.Size = new Size(130, 70);
            button_loadStocks.TabIndex = 0;
            button_loadStocks.Text = "Load Stocks";
            button_loadStocks.UseVisualStyleBackColor = true;
            button_loadStocks.Click += button_loadStocks_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(17, 54);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 7;
            label2.Text = "End Time";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(11, 17);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 6;
            label1.Text = "Start Time";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.None;
            dateTimePickerEnd.Location = new Point(108, 49);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(300, 31);
            dateTimePickerEnd.TabIndex = 5;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.None;
            dateTimePickerStart.Location = new Point(108, 12);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(300, 31);
            dateTimePickerStart.TabIndex = 4;
            dateTimePickerStart.Value = new DateTime(2023, 2, 12, 21, 40, 0, 0);
            // 
            // Form_Entry
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 92);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(button_loadStocks);
            MinimumSize = new Size(599, 148);
            Name = "Form_Entry";
            Text = "Entry Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog_stocks;
        private Button button_loadStocks;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
    }
}