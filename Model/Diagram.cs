using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System;
using System.Drawing;

namespace WindowsFormsApp1.Model
{
    internal class Diagram
    {
        private DataGridView _dataGridView;
        private Chart _target;

        public Diagram(DataGridView dataGridView, Chart chart)
        {
            _dataGridView = dataGridView;
            _target = chart;
        }
        
        public void Update()
        {
            Fill(out double[] values, out string[] names);
            Draw(values, names);
        }

        private void Fill(out double[] values, out string[] _titles)
        {
            values = new double[_dataGridView.Columns.Count];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToDouble(_dataGridView[i, 3].Value);
            }

            _titles = new string[_dataGridView.Columns.Count];
            for (int i = 0; i < values.Length; i++)
            {
                if (Convert.ToString(_dataGridView[i, 0].Value) != null)
                {
                    _titles[i] = Convert.ToString(_dataGridView[i, 0].Value);
                }

                else
                {
                    _titles[i] = "";
                } 
            }
        }

        private void Draw(double[] values, string[] names)
        {
            _target.Series.Clear();
            _target.Titles.Clear();
            _target.Titles.Add("Доли продаж по товарам");
            _target.Titles[0].Font = new Font("Utopia", 16);

            _target.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });

            _target.Series[0].Points.DataBindXY(names, values);
        }
    }
}
