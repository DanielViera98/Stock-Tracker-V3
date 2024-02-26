using System.ComponentModel;
using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Windows.Forms.DataVisualization.Charting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System;
using COP4365_Project3;
using System.Diagnostics;

namespace COP4365_Project2
{
    public partial class Chart_Form : Form
    {
        BindingList<SmartStock> storedStocks;
        public Chart_Form(BindingList<SmartStock> list, DateTime start, DateTime end)
        {
            InitializeComponent();
            //store list in outer variable.
            storedStocks = list;

            //Get required info and call update_stocks.
            var series = chart_stocks.Series;
            var cStocks = series.First();
            var cVolumes = series.Last();
            update_stocks(cStocks, cVolumes, start, end);

            //Change volumes series name
            cVolumes.Name = list[0].Ticker + " " + list[0].Period + " Volumes";

            //Create a list of recognizers for the combobox
            List<Recognizer> Lr = new List<Recognizer>
            {
                new BullishRecognizer(),
                new BearishRecognizer(),
                new NeutralRecognizer(),
                new MarubozuRecognizer(),
                new DojiRecognizer(),
                new DragonflyDojiRecognizer(),
                new GravestoneDojiRecognizer(),
                new HammerRecognizer(),
                new InvertedHammerRecognizer(),
                new BullishEngulfingRecognizer(),
                new BearishEngulfingRecognizer(),
                new EngulfingRecognizer(),
                new BearishHaramiRecognizer(),
                new BullishHaramiRecognizer(),
                new PeakRecognizer(),
                new ValleyRecognizer()
            };
            //bind list to combobox
            comboBox_selectProperty.DataSource = Lr;

            //After setting the datasource, automatically selects first item. Reset to null.
            comboBox_selectProperty.SelectedItem = null;
            comboBox_selectProperty.Text = "Select a Property";
        }

        private void button_UpdateChart_Click(object sender, EventArgs e)
        {
            //grab start and end date. Throw error if start is after end.
            var startDate = dateTimePickerStart.Value;
            var endDate = dateTimePickerEnd.Value;
            if (startDate > endDate)
            {
                MessageBox.Show("From date cannot be after To date. ");
                return;
            }

            //Grab the required variables and call update_stocks
            var series = chart_stocks.Series;
            var cStocks = series.First();
            var cVolumes = series.Last();
            update_stocks(cStocks, cVolumes, startDate, endDate);
        }

        public void update_stocks(Series cStocks, Series cVolumes, DateTime start, DateTime end)
        {
            chart_stocks.Annotations.Clear();
            cStocks.Points.Clear();
            cVolumes.Points.Clear();

            //Select the dates corresponding to input from the storedList. Add that to the displayData
            BindingList<SmartStock> displayData = new BindingList<SmartStock>(storedStocks
                .Where(s => (s.Date < end) && (s.Date > start)).ToList());

            //Bind to displayData
            chart_stocks.DataSource = displayData;
            chart_stocks.DataBind();

            //Modify candlestick series with values from list. Format options.
            cStocks.Name = storedStocks[0].Ticker + " " + storedStocks[0].Period;
            chart_stocks.ChartAreas[0].AxisY.Minimum = Math.Floor(cStocks.Points.FindMinByValue("Y1").YValues[1]);

            //Sort both series by dates
            cStocks.Sort(0, "X");
            cVolumes.Sort(0, "X");
        }

        //Calls recognizer for annotations.         //TODO: CHECK IF MULTI-CANDLESTICK RECOGNIZERS WORK
        private void showProperty_Select(object sender, EventArgs e)
        {

            //Get the value of selectedItem.
            //When using "as", returns a null value on failure instead of an exception.
            Recognizer recognizer = comboBox_selectProperty.SelectedItem as Recognizer;

            //Checks if the chart is visible yet. If not, return. This prevents a null
            //exception later when attempting to set the height on a chart which isn't
            //shown yet.
            if (!chart_stocks.Visible) { return; }

            //get list of cStocks series points.
            var points = chart_stocks.Series.First().Points;

            //Use the recognizer to get a list of points to affect
            var temp = chart_stocks.DataSource as IEnumerable<SmartStock>;
            temp = temp.OrderBy(s => s.Date);

            //pointsIndex is of the form [[patternStartIndex, patternSize], ...]
            var pointsIndex = recognizer.recognize(temp.ToList());
            if (pointsIndex == null) { return; }

            //Clear existing annotations
            chart_stocks.Annotations.Clear();

            foreach (var p in pointsIndex)
            {
                var currentPoint = points[p[0]];

                // Create a RectangleAnnotation
                RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();

                //For testing with size and placement
                rectangleAnnotation.IsSizeAlwaysRelative = false;

                // Set the anchor data point
                if (p[1] == 1)
                    rectangleAnnotation.AnchorDataPoint = currentPoint;
                else if (p[1] == 2)
                {
                    //If a annotation covers two points, set the alignment and offset to make it fit
                    rectangleAnnotation.AnchorDataPoint = currentPoint;
                    rectangleAnnotation.AnchorAlignment = ContentAlignment.BottomLeft;
                    rectangleAnnotation.AnchorOffsetX = -1;
                }
                else
                    rectangleAnnotation.AnchorDataPoint = points[p[0]+1];   //Set to middle point
                
                //Set anchorY to High of first point
                rectangleAnnotation.AnchorY = currentPoint.YValues[0];

                //calculate width and height
                double width = p[1];
                double height = currentPoint.YValues[0] - currentPoint.YValues[1]; 

                //If more than one point in pattern, calculate the width and height of the pattern
                if (p[1] > 1)
                {
                    double maxHeight = Math.Max(currentPoint.YValues[0], points[p[0] + 1].YValues[0]);
                    double minHeight = Math.Min(currentPoint.YValues[1], points[p[0] + 1].YValues[1]);
                    if (p[1] == 3)
                    {
                        maxHeight = Math.Max(maxHeight, points[p[0] + 2].YValues[0]);
                        minHeight = Math.Min(minHeight, points[p[0] + 2].YValues[1]);
                    }
                    height = Math.Abs(maxHeight - minHeight);
                    rectangleAnnotation.AnchorY = maxHeight;    //Set anchor to max of pattern

                }
                // Set the width, height, and alignment of the rectangle
                rectangleAnnotation.Width = width;
                rectangleAnnotation.Height = height;
                


                // Set the color and line properties
                rectangleAnnotation.BackColor = Color.FromArgb(100, 255, 0, 0);
                rectangleAnnotation.LineColor = Color.Blue;
                rectangleAnnotation.LineWidth = 2;

                // Add the annotation to the chart
                chart_stocks.Annotations.Add(rectangleAnnotation);
            }
        }
    }
}
