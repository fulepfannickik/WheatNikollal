using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wheat
{
    public partial class BarChartForm : Form
    {
        public BarChartForm(Dictionary<string, int> categories)
        {
            InitializeComponent();
            ShowChart(categories);
        }

        private void ShowChart(Dictionary<string, int> categories)
        {
            BarChart.Series.Clear();
            BarChart.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            BarChart.ChartAreas.Add(area);

            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            Series s = new Series();
            s.ChartType = SeriesChartType.Bar;
            s.Name = "Kategóriák gyakorisága";
            s.Color = Color.LightPink;
            
           

            foreach (var item in categories)
            {
                s.Points.AddXY(item.Key, item.Value);
            }

            BarChart.Series.Add(s);
        }
    }
}
