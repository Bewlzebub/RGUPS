using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form8 : Form
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string currentTable = "";

        public Form8()
        {
            InitializeComponent();
            InitializeForm8();
        }

        private void InitializeForm8()
        {
            // Настройка ComboBox для выбора таблицы
            cmbTableName.SelectedIndexChanged += CmbTableName_SelectedIndexChanged;

            // Настройка кнопок
            btnSearch.Click += BtnSearch_Click;
            btnClearFilter.Click += BtnClearFilter_Click;
            btnAddCondition.Click += BtnAddCondition_Click;
            btnRemoveCondition.Click += BtnRemoveCondition_Click;

            // Заполнение операторов
            cmbOperator.SelectedIndex = 0;

            // Загрузка первой таблицы по умолчанию
            if (cmbTableName.Items.Count > 0)
                cmbTableName.SelectedIndex = 0;
        }

        private void CmbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTable = cmbTableName.SelectedItem.ToString();
            LoadTableData();
            LoadFieldsForCurrentTable();
        }

        private void LoadTableData()
        {
            try
            {
                string query = GetSelectQuery(currentTable);
                SqlCommand cmd = new SqlCommand(query, DBConnection.Instance().Connection);

                dataAdapter.SelectCommand = cmd;
                ds.Tables.Clear();
                dataAdapter.Fill(ds, currentTable);
                dataGridView1.DataSource = ds.Tables[currentTable].DefaultView;

                lblStatus.Text = $"✅ Загружено: {currentTable} ({dataGridView1.Rows.Count} записей)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                lblStatus.Text = "❌ Ошибка загрузки данных";
            }
        }

        private string GetSelectQuery(string tableName)
        {
            switch (tableName)
            {
                case "Студенты":
                    return "SELECT * FROM Студенты";
                case "Преподаватели":
                    return "SELECT * FROM Предполагатели";
                case "Кафедры":
                    return "SELECT * FROM Кафедры";
                case "Дисциплины":
                    return "SELECT * FROM Дисциплины";
                case "Ведомости":
                    return "SELECT * FROM Ведомости";
                default:
                    return "SELECT * FROM Предполагатели";
            }
        }

        private void LoadFieldsForCurrentTable()
        {
            cmbFieldName.Items.Clear();

            try
            {
                string query = GetSelectQuery(currentTable);
                SqlCommand cmd = new SqlCommand(query, DBConnection.Instance().Connection);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                DataTable schema = reader.GetSchemaTable();
                reader.Close();

                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    cmbFieldName.Items.Add(columnName);
                }

                if (cmbFieldName.Items.Count > 0)
                    cmbFieldName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки полей: {ex.Message}");
            }
        }

        private void BtnAddCondition_Click(object sender, EventArgs e)
        {
            if (cmbFieldName.SelectedItem == null)
            {
                MessageBox.Show("Выберите поле для поиска!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSearchValue.Text) && cmbOperator.SelectedItem.ToString() != "≠")
            {
                MessageBox.Show("Введите значение для поиска!");
                return;
            }

            string field = cmbFieldName.SelectedItem.ToString();
            string operatorText = cmbOperator.SelectedItem.ToString();
            string value = txtSearchValue.Text;

            string condition = BuildCondition(field, operatorText, value);
            lstConditions.Items.Add(condition);

            // Очистка полей для следующего условия
            txtSearchValue.Clear();
            cmbOperator.SelectedIndex = 0;
            if (cmbFieldName.Items.Count > 0)
                cmbFieldName.SelectedIndex = 0;
        }

        private string BuildCondition(string field, string operatorText, string value)
        {
            switch (operatorText)
            {
                case "=":
                    return $"{field} = '{value}'";
                case "≠":
                    return $"{field} != '{value}'";
                case ">":
                    return $"{field} > '{value}'";
                case "<":
                    return $"{field} < '{value}'";
                case "≥":
                    return $"{field} >= '{value}'";
                case "≤":
                    return $"{field} <= '{value}'";
                case "содержит":
                    return $"{field} LIKE '%{value}%'";
                case "начинается с":
                    return $"{field} LIKE '{value}%'";
                case "заканчивается на":
                    return $"{field} LIKE '%{value}'";
                default:
                    return $"{field} = '{value}'";
            }
        }

        private void BtnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (lstConditions.SelectedIndex != -1)
            {
                lstConditions.Items.RemoveAt(lstConditions.SelectedIndex);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentTable))
                {
                    MessageBox.Show("Выберите таблицу для поиска!");
                    return;
                }

                string query = GetSelectQuery(currentTable);

                if (lstConditions.Items.Count > 0)
                {
                    query += " WHERE ";
                    for (int i = 0; i < lstConditions.Items.Count; i++)
                    {
                        if (i > 0) query += " AND ";
                        query += lstConditions.Items[i].ToString();
                    }
                }

                SqlCommand cmd = new SqlCommand(query, DBConnection.Instance().Connection);

                dataAdapter.SelectCommand = cmd;
                DataTable resultTable = new DataTable();
                dataAdapter.Fill(resultTable);
                dataGridView1.DataSource = resultTable;

                lblStatus.Text = $"🔍 Найдено: {resultTable.Rows.Count} записей";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}");
                lblStatus.Text = "❌ Ошибка выполнения поиска";
            }
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            lstConditions.Items.Clear();
            LoadTableData();
            lblStatus.Text = "✅ Фильтр очищен";
        }
    }
}