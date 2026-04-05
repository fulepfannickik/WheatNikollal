using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wheat
{
    public partial class ChartForm : Form
    {
        public ChartForm(Dictionary<string, double> data)
        {
            InitializeComponent();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);

            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Outside";
            series.IsValueShownAsLabel = true;
        
            
            series.BorderWidth = 1;
            series.BorderColor = System.Drawing.Color.Black;
            series.LabelBorderWidth = 1;
            series.LabelBorderColor = System.Drawing.Color.Black;
            series.Label = "#VALX;#VAL";
          
            series["PieLineColor"] = "Black";

            chart.Series.Add(series);

            foreach (var item in data)
            {
                int rounded = (int)(Math.Round(item.Value / 100.0) * 100);
                series.Points.AddXY(item.Key, rounded);
            }

          
            Title title = new Title();
            title.Text = "Átlagos búzatermelés (ezer tonna)";
            chart.Titles.Add(title);

            
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            chart.Legends.Add(legend);

            this.Text = "Kördiagram";
            this.FormBorderStyle = FormBorderStyle.Sizable;

            this.Controls.Clear();
            this.Controls.Add(chart);
        }
    }
}