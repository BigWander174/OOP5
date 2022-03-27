using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private RowAdder _rowAdder;
        private ColumnAdder _columnAdder;
        private Filler _filler;
        private Diagram _diagram;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _rowAdder = new RowAdder(data);
            _rowAdder.Work();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var numerics = (NumericUpDown)sender;
            var count = (int) numerics.Value;

            _columnAdder = new ColumnAdder(data);
            _columnAdder.Set(count);
        }

        private void data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var view = (DataGridView)sender;
            int lastRow = view.Rows.Count - 1;
            if (e.RowIndex != lastRow)
            {
                UpdateTable(e);
                UpdateDiagram();
            }
        }

        private void UpdateTable(DataGridViewCellEventArgs e)
        {
            _filler = new Filler(data);
            _filler.Update(e);
        }

        private void UpdateDiagram()
        {
            _diagram = new Diagram(data, Chart1);
            _diagram.Update();
        }
    }
}
