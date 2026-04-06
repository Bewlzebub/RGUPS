using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab3
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.DataGridViewColumn Col;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "universityDB_DormanchukDataSet.Студенты". При необходимости она может быть перемещена или удалена.
            this.студентыTableAdapter.Fill(this.universityDB_DormanchukDataSet.Студенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "universityDB_DormanchukDataSet.Кафедры". При необходимости она может быть перемещена или удалена.
            this.кафедрыTableAdapter.Fill(this.universityDB_DormanchukDataSet.Кафедры);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            кафедрыTableAdapter.Update(universityDB_DormanchukDataSet.Кафедры);
            студентыTableAdapter.Update(universityDB_DormanchukDataSet.Студенты);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите столбец для сортировки!", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите направление сортировки (по возрастанию или по убыванию)!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (listBox1.SelectedIndex)
            {
                case 0: Col = dataGridView1.Columns[0]; break;
                case 1: Col = dataGridView1.Columns[1]; break;
                case 2: Col = dataGridView1.Columns[2]; break;
                case 3: Col = dataGridView1.Columns[3]; break;
                case 4: Col = dataGridView1.Columns[4]; break;
                case 5: Col = dataGridView1.Columns[5]; break;
                case 6: Col = dataGridView1.Columns[6]; break;
                case 7: Col = dataGridView1.Columns[7]; break;
                case 8: Col = dataGridView1.Columns[8]; break;
            }
            if (radioButton1.Checked)
                dataGridView1.Sort(Col, ListSortDirection.Ascending);

            if (radioButton2.Checked)
                dataGridView1.Sort(Col, ListSortDirection.Descending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string poisk = textBox9.Text;

            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;

            bool found = false;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow) continue;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        string cellValue = dataGridView1.Rows[i].Cells[j].Value.ToString();

                        if (cellValue.IndexOf(poisk, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                            found = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show($"Значение \"{poisk}\" не найдено!", "Результат поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow) continue;
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[i].Visible = true;
            }

            textBox9.Text = "";
            dataGridView1.ClearSelection();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }

            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string poisk = textBox9.Text.Trim();
            DataTable dt = universityDB_DormanchukDataSet.Кафедры;
            DataView dv = new DataView(dt);

            if (string.IsNullOrEmpty(poisk))
            {
                dv.RowFilter = "";
            }
            else
            {
                string filter = "";
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        if (filter != "") filter += " OR ";
                        filter += $"[{col.ColumnName}] LIKE '%{poisk.Replace("'", "''")}%'";
                    }
                }
                dv.RowFilter = filter;
            }

            dataGridView1.DataSource = dv;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow) continue;

                bool found = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString()
                            .IndexOf(poisk, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = found ? Color.LightGreen : Color.White;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Сохранение таблицы "Кафедры"
            SaveTableToFile(dataGridView1, "Кафедры");

            // Сохранение таблицы "Студенты"


            MessageBox.Show("Таблица: Кафедры сохранена!", "Результат",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            SaveTableToFile(dataGridView2, "Студенты");

            MessageBox.Show("Таблица: Студенты сохранена!", "Результат",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void SaveTableToFile(DataGridView grid, string tableName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = $"Сохранить таблицу '{tableName}'";
            saveFileDialog.FileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr != DialogResult.OK) return;

            try
            {
                using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create))
                using (StreamWriter fnew = new StreamWriter(file, Encoding.UTF8))
                {
                    int rowCount = grid.Rows.Count;
                    if (grid.AllowUserToAddRows && rowCount > 0 && grid.Rows[rowCount - 1].IsNewRow)
                    {
                        rowCount--;
                    }

                    fnew.WriteLine(rowCount);
                    fnew.WriteLine(grid.Columns.Count);

                    for (int j = 0; j < grid.Columns.Count; j++)
                    {
                        fnew.Write(grid.Columns[j].HeaderText);
                        if (j < grid.Columns.Count - 1)
                            fnew.Write(";");
                    }
                    fnew.WriteLine();

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        if (grid.Rows[i].IsNewRow) continue;

                        for (int j = 0; j < grid.Columns.Count; j++)
                        {
                            if (grid.Rows[i].Cells[j].Value != null)
                            {
                                string value = grid.Rows[i].Cells[j].Value.ToString();
                                if (value.Contains(";"))
                                {
                                    value = "\"" + value + "\"";
                                }
                                fnew.Write(value);
                            }
                            if (j < grid.Columns.Count - 1)
                                fnew.Write(";");
                        }
                        fnew.WriteLine();
                    }
                }

                MessageBox.Show($"Таблица '{tableName}' сохранена успешно!", "Результат",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении таблицы '{tableName}': {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }
    }
}
