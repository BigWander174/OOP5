using System.Windows.Forms;
namespace WindowsFormsApp1.Model
{
    internal class ColumnAdder
    {
        public DataGridView _target;

        public ColumnAdder(DataGridView dataGridView)
        {
            _target = dataGridView;
        }

        public void Set(int count)
        {
            if (count != 0)
            {
                _target.ColumnCount = 1;
                for (int i = 1; i < count; i++)
                {
                    var newColumnIndex = i + 1;
                    _target.Columns.Add(newColumnIndex.ToString(), newColumnIndex.ToString());
                }
            }
        }
    }
}
