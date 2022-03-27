using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    internal class RowAdder
    {
        private DataGridView _target;
        private string[] _headers;

        public RowAdder(DataGridView target)
        {
            _target = target;
            _headers = new string[]
            {
                "Товар",
                "Цена",
                "Количество",
                "Стоимость",
            };
        }

        public void Work()
        {
            _target.Rows.Clear();
            AddRowIfNoColumns();
            for (int i = 0; i < _headers.Length; i++)
            {
                _target.Rows.Add();
                _target.Rows[i].HeaderCell.Value = _headers[i];
            }
        }

        private void AddRowIfNoColumns()
        {
            if (_target.Columns.Count == 0)
            {
                _target.Columns.Add("1", "1");
            }
        }
    }
}
