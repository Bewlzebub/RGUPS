using DotNetEnv;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UniversityClient
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter dataAdapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConnectionString();
            LoadAllData();
        }

        // ==================== ЗАГРУЗКА ПОДКЛЮЧЕНИЯ ====================
        private void LoadConnectionString()
        {
            try
            {
                string envPath = Path.Combine(Application.StartupPath, ".env");
                if (File.Exists(envPath))
                {
                    Env.Load(envPath);
                    string server = Env.GetString("DB_SERVER");
                    string database = Env.GetString("DB_NAME");
                    string user = Env.GetString("DB_USER");
                    string password = Env.GetString("DB_PASSWORD");
                    string trustCert = Env.GetString("TRUST_CERTIFICATE");
                    connectionString = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate={trustCert};Connect Timeout=30;";
                }
                else
                {
                    connectionString = "Server=127.0.0.1,1433;Database=Database;User Id=sa;Password=qwerty123;TrustServerCertificate=True;Connect Timeout=30;";
                }

                statusLabel.Text = "Статус: Готов к работе";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка подключения";
            }
        }

        // ==================== ЗАГРУЗКА ВСЕХ ТАБЛИЦ ====================
        private void LoadAllData()
        {
            LoadTable("Кафедры", dataGridView1);
            LoadTable("Студенты", dataGridView2);
            LoadTable("Преподаватели", dataGridView3);
        }

        private void LoadTable(string tableName, DataGridView gridView)
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
                    gridView.DataSource = dt;
                    gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gridView.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы {tableName}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAllData()
        {
            LoadAllData();
            statusLabel.Text = "Статус: Данные обновлены";
        }

        // ==================== SELECT ЗАПРОС (Выполнить SQL) ====================
        private void btnExecuteSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtSqlQuery.Text.Trim();
                if (string.IsNullOrEmpty(query))
                {
                    MessageBox.Show("Введите SQL запрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    sqlCommand = new SqlCommand(query, conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    string result = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result += reader.GetName(i) + "\t";
                    }
                    result += "\n" + new string('-', 50) + "\n";

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result += reader[i].ToString() + "\t";
                        }
                        result += "\n";
                    }
                    reader.Close();

                    txtResult.Text = result;
                    statusLabel.Text = "Статус: SELECT выполнен успешно";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения SELECT: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка SELECT";
            }
        }

        // ==================== INSERT ЗАПРОС ====================
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string faculty = txtFaculty.Text.Trim();
                string head = txtHead.Text.Trim();
                string room = txtRoom.Text.Trim();
                string building = txtBuilding.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string count = txtCount.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(faculty))
                {
                    MessageBox.Show("Заполните обязательные поля (Название и Факультет)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Кафедры (название, факультет, фио_заведующего, номер_комнаты, номер_корпуса, телефон, кол_во_преподавателей) 
                                     VALUES (@name, @faculty, @head, @room, @building, @phone, @count)";

                    sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@faculty", faculty);
                    sqlCommand.Parameters.AddWithValue("@head", string.IsNullOrEmpty(head) ? "" : head);
                    sqlCommand.Parameters.AddWithValue("@room", string.IsNullOrEmpty(room) ? 0 : int.Parse(room));
                    sqlCommand.Parameters.AddWithValue("@building", string.IsNullOrEmpty(building) ? 0 : int.Parse(building));
                    sqlCommand.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? "" : phone);
                    sqlCommand.Parameters.AddWithValue("@count", string.IsNullOrEmpty(count) ? 0 : int.Parse(count));

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"INSERT выполнен! Добавлено строк: {rowsAffected}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAllData();
                    ClearInsertFields();
                    statusLabel.Text = $"Статус: INSERT выполнен, добавлено {rowsAffected} строк";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка INSERT: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка INSERT";
            }
        }

        // ==================== UPDATE ЗАПРОС ====================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Кафедры SET номер_комнаты = номер_комнаты + 100";
                    sqlCommand = new SqlCommand(query, conn);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"UPDATE выполнен! Обновлено строк: {rowsAffected}\n(К номерам аудиторий прибавлено 100)", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAllData();
                    statusLabel.Text = $"Статус: UPDATE выполнен, обновлено {rowsAffected} строк";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка UPDATE: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка UPDATE";
            }
        }

        // ==================== DELETE ЗАПРОС ====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string deleteValue = txtDeleteValue.Text.Trim();
            if (string.IsNullOrEmpty(deleteValue))
            {
                MessageBox.Show("Введите значение для удаления (слово для поиска в названии)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Удалить все кафедры, содержащие слово '{deleteValue}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Кафедры WHERE название LIKE @value";
                    sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.Parameters.AddWithValue("@value", $"%{deleteValue}%");
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"DELETE выполнен! Удалено строк: {rowsAffected}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAllData();
                    txtDeleteValue.Text = "";
                    statusLabel.Text = $"Статус: DELETE выполнен, удалено {rowsAffected} строк";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка DELETE: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка DELETE";
            }
        }

        // ==================== CREATE TABLE ====================
        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            string tableName = txtTableName.Text.Trim();
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Введите название таблицы!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $@"CREATE TABLE [{tableName}] (
                                        Id INT IDENTITY(1,1) PRIMARY KEY,
                                        Name NVARCHAR(100) NOT NULL,
                                        CreatedDate DATETIME DEFAULT GETDATE()
                                    )";
                    sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"Таблица '{tableName}' успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTable(tableName, dataGridView3);
                    txtTableName.Text = "";
                    statusLabel.Text = $"Статус: CREATE TABLE выполнен, создана таблица {tableName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка CREATE TABLE: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка CREATE TABLE";
            }
        }

        // ==================== DROP TABLE ====================
        private void btnDropTable_Click(object sender, EventArgs e)
        {
            string tableName = txtDropTableName.Text.Trim();
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Введите название таблицы для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Удалить таблицу '{tableName}'? Это действие необратимо!", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"DROP TABLE [{tableName}]";
                    sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"Таблица '{tableName}' удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDropTableName.Text = "";
                    statusLabel.Text = $"Статус: DROP TABLE выполнен, удалена таблица {tableName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка DROP TABLE: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка DROP TABLE";
            }
        }

        // ==================== COUNT (ExecuteScalar) ====================
        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Кафедры";
                    sqlCommand = new SqlCommand(query, conn);
                    int count = (int)sqlCommand.ExecuteScalar();

                    query = "SELECT COUNT(*) FROM Студенты";
                    sqlCommand = new SqlCommand(query, conn);
                    int studentsCount = (int)sqlCommand.ExecuteScalar();

                    query = "SELECT COUNT(*) FROM Преподаватели";
                    sqlCommand = new SqlCommand(query, conn);
                    int teachersCount = (int)sqlCommand.ExecuteScalar();

                    lblCountResult.Text = $"📊 Статистика:\n" +
                                          $"Кафедры: {count}\n" +
                                          $"Студенты: {studentsCount}\n" +
                                          $"Преподаватели: {teachersCount}";
                    statusLabel.Text = "Статус: COUNT выполнен";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка COUNT: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Статус: Ошибка COUNT";
            }
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================
        private void ClearInsertFields()
        {
            txtName.Text = "";
            txtFaculty.Text = "";
            txtHead.Text = "";
            txtRoom.Text = "";
            txtBuilding.Text = "";
            txtPhone.Text = "";
            txtCount.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsertFields();
            txtSqlQuery.Text = "";
            txtResult.Text = "";
            txtDeleteValue.Text = "";
            txtTableName.Text = "";
            txtDropTableName.Text = "";
            statusLabel.Text = "Статус: Поля очищены";
        }
    }
}