using System;
using System.Collections.Generic;
using System.Linq;
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

            chart.Series.Add(series);

            
            foreach (var item in data)
            {
                int rounded = (int)(Math.Round(item.Value / 100.0) * 100);
                series.Points.AddXY(item.Key, rounded);
            }

            
            chart.Titles.Add("Országok termelési átlaga");

            
            chart.Legends.Add(new Legend());

            this.Controls.Add(chart);
        }
    }
}