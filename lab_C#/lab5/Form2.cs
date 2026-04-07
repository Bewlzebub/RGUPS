using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form2 : Form
    {
        private string connectionString;
        private SqlDataAdapter dataAdapter;

        public Form2(string connString)
        {
            InitializeComponent();
            connectionString = connString;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadAllTablesIntoTabControl();
        }

        private void LoadAllTablesIntoTabControl()
        {
            try
            {
                DataTable schemaTables = GetTableSchema();

                if (schemaTables.Rows.Count == 0)
                {
                    MessageBox.Show("В базе данных не найдено таблиц!", "Предупреждение",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tabControl1.TabPages.Clear();

                foreach (DataRow row in schemaTables.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();

                    TabPage tabPage = new TabPage(tableName);

                    DataGridView dataGridView = new DataGridView();
                    dataGridView.Dock = DockStyle.Fill;
                    dataGridView.ReadOnly = true;
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.AllowUserToAddRows = false;
                    dataGridView.BackgroundColor = System.Drawing.Color.White;

                    tabPage.Controls.Add(dataGridView);
                    tabControl1.TabPages.Add(tabPage);

                    LoadTableData(tableName, dataGridView);
                }

                statusLabel.Text = $"Загружено таблиц: {schemaTables.Rows.Count}";
                LoadStatsForCurrentTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблиц: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ошибка загрузки таблиц";
            }
        }

        private DataTable GetTableSchema()
        {
            DataTable schemaTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TABLE_NAME 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_TYPE = 'BASE TABLE' 
                    ORDER BY TABLE_NAME";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(schemaTable);
            }

            return schemaTable;
        }

        private void LoadTableData(string tableName, DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM [{tableName}]";
                    dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGridView.DataSource = dt;
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.ReadOnly = true;
                    dataGridView.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы '{tableName}': {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatsForCurrentTab();
        }

        private void LoadStatsForCurrentTab()
        {
            if (tabControl1.SelectedTab == null) return;

            string tableName = tabControl1.SelectedTab.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string statsText = "";

                    // COUNT
                    string countQuery = $"SELECT COUNT(*) FROM [{tableName}]";
                    SqlCommand countCmd = new SqlCommand(countQuery, conn);
                    int rowCount = (int)countCmd.ExecuteScalar();
                    statsText += $"📌 Количество записей (COUNT): {rowCount}\r\n\r\n";

                    // Получаем столбцы
                    DataTable columnsSchema = GetColumnSchema(tableName, conn);
                    bool hasNumericColumns = false;

                    foreach (DataRow colRow in columnsSchema.Rows)
                    {
                        string columnName = colRow["COLUMN_NAME"].ToString();
                        string dataType = colRow["DATA_TYPE"].ToString().ToLower();

                        if (IsNumericType(dataType))
                        {
                            hasNumericColumns = true;
                            statsText += $"📊 Столбец: {columnName}\r\n";
                            statsText += new string('─', 40) + "\r\n";

                            try
                            {
                                object maxResult = ExecuteScalar(conn, $"SELECT MAX([{columnName}]) FROM [{tableName}]");
                                statsText += $"   MAX: {FormatValue(maxResult)}\r\n";

                                object minResult = ExecuteScalar(conn, $"SELECT MIN([{columnName}]) FROM [{tableName}]");
                                statsText += $"   MIN: {FormatValue(minResult)}\r\n";

                                object avgResult = ExecuteScalar(conn, $"SELECT AVG(CAST([{columnName}] AS FLOAT)) FROM [{tableName}]");
                                statsText += $"   AVG: {FormatValue(avgResult)}\r\n";
                            }
                            catch (Exception ex)
                            {
                                statsText += $"   Ошибка: {ex.Message}\r\n";
                            }
                            statsText += "\r\n";
                        }
                    }

                    if (!hasNumericColumns)
                    {
                        statsText += "⚠️ В таблице нет числовых столбцов для MIN/MAX/AVG.\r\n";
                        statsText += "Доступна только статистика COUNT (количество записей).";
                    }

                    txtStats.Text = statsText;
                }
            }
            catch (Exception ex)
            {
                txtStats.Text = $"Ошибка получения статистики: {ex.Message}";
            }
        }

        private object ExecuteScalar(SqlConnection conn, string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : result;
        }

        private DataTable GetColumnSchema(string tableName, SqlConnection conn)
        {
            DataTable schema = new DataTable();
            string query = @"
                SELECT COLUMN_NAME, DATA_TYPE 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @tableName
                ORDER BY ORDINAL_POSITION";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tableName", tableName);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(schema);

            return schema;
        }

        private bool IsNumericType(string dataType)
        {
            string[] numericTypes = { "int", "bigint", "smallint", "tinyint", "decimal", "numeric",
                                       "float", "real", "money", "smallmoney", "bit" };
            foreach (string type in numericTypes)
            {
                if (dataType.Contains(type))
                    return true;
            }
            return false;
        }

        private string FormatValue(object value)
        {
            if (value == null) return "NULL";
            if (value is double || value is float || value is decimal)
            {
                return Math.Round(Convert.ToDouble(value), 2).ToString();
            }
            return value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllTablesIntoTabControl();
            MessageBox.Show("Данные обновлены!", "Обновление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}