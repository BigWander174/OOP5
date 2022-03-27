using System.Windows.Forms;
using System;

namespace WindowsFormsApp1.Model
{
    internal class Filler
    {
        private DataGridView _dataGridView;

        public Filler(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }

        public void Update(DataGridViewCellEventArgs e)
        {
            int lastRow = _dataGridView.Rows.Count - 1;

            if (e.RowIndex > 0 && e.RowIndex < 3)
            {
                var price = Convert.ToInt32(_dataGridView[e.ColumnIndex, 1].Value);
                var amount = Convert.ToInt32(_dataGridView[e.ColumnIndex, 2].Value);
                _dataGridView[e.ColumnIndex, lastRow].Value = price * amount;
            }
        }
    }
}
