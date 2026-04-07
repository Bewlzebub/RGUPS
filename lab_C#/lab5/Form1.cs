using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServerName.Text = "(local)";
            txtDatabaseName.Text = "UniversityDB_Dormanchuk";
            radioSQLServer.Checked = true;
            UpdateAuthFields();
        }

        private void UpdateAuthFields()
        {
            if (radioWindowsAuth.Checked)
            {
                lblUser.Enabled = false;
                txtUser.Enabled = false;
                lblPassword.Enabled = false;
                txtPassword.Enabled = false;
                txtUser.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                lblUser.Enabled = true;
                txtUser.Enabled = true;
                lblPassword.Enabled = true;
                txtPassword.Enabled = true;
                txtUser.Text = "sa";
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void radioWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthFields();
        }

        private void radioSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthFields();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Проверка заполнения полей
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("Введите имя сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Введите имя базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDatabaseName.Focus();
                return;
            }

            string connectionString;

            if (radioWindowsAuth.Checked)
            {
                connectionString = $"Server={txtServerName.Text};Database={txtDatabaseName.Text};Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30;";
            }
            else
            {
                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    MessageBox.Show("Введите имя пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                connectionString = $"Server={txtServerName.Text};Database={txtDatabaseName.Text};User Id={txtUser.Text};Password={txtPassword.Text};TrustServerCertificate=True;Connect Timeout=30;";
            }

            // Проверка подключения
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Подключение к базе данных успешно установлено!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Открываем главную форму
                    Form2 mainForm = new Form2(connectionString);
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных!\n\n{ex.Message}",
                                "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}