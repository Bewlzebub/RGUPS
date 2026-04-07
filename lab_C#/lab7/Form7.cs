using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab6
{
    public partial class Form7 : Form
    {
        SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        BindingManagerBase bindingManager;

        string Sql;
        SqlCommand myCommand;

        public Form7()
        {
            InitializeComponent();

            textBox1.ReadOnly = true;
            textBox1.TabStop = false; 
            textBox1.BackColor = System.Drawing.Color.LightGray; 

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataAdapter1.SelectCommand = new SqlCommand("SELECT * FROM Кафедры", DBConnection.Instance().Connection);
                ds1.Clear();
                dataAdapter1.Fill(ds1, "Кафедры");

                textBox1.DataBindings.Clear();
                textBox2.DataBindings.Clear();
                textBox3.DataBindings.Clear();
                textBox4.DataBindings.Clear();
                textBox5.DataBindings.Clear();
                textBox6.DataBindings.Clear();
                textBox7.DataBindings.Clear();
                textBox8.DataBindings.Clear();

                textBox1.DataBindings.Add(new Binding("Text", ds1, "Кафедры.код_кафедры"));
                textBox2.DataBindings.Add(new Binding("Text", ds1, "Кафедры.название"));
                textBox3.DataBindings.Add(new Binding("Text", ds1, "Кафедры.факультет"));
                textBox4.DataBindings.Add(new Binding("Text", ds1, "Кафедры.фио_заведующего"));
                textBox5.DataBindings.Add(new Binding("Text", ds1, "Кафедры.номер_комнаты"));
                textBox6.DataBindings.Add(new Binding("Text", ds1, "Кафедры.номер_корпуса"));
                textBox7.DataBindings.Add(new Binding("Text", ds1, "Кафедры.телефон"));
                textBox8.DataBindings.Add(new Binding("Text", ds1, "Кафедры.кол_во_преподавателей"));

                bindingManager = this.BindingContext[ds1, "Кафедры"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        // Следующая запись
        private void button1_Click(object sender, EventArgs e)
        {
            if (bindingManager != null)
            {
                if (bindingManager.Position < bindingManager.Count - 1)
                {
                    bindingManager.Position++;
                }
                else
                {
                    MessageBox.Show("Вы достигли последней записи!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Предыдущая запись
        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingManager != null)
            {
                if (bindingManager.Position > 0)
                {
                    bindingManager.Position--;
                }
                else
                {
                    MessageBox.Show("Вы находитесь на первой записи!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Первая запись
        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingManager != null && bindingManager.Count > 0)
            {
                bindingManager.Position = 0;
                MessageBox.Show("Переход к первой записи", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Последняя запись
        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingManager != null && bindingManager.Count > 0)
            {
                bindingManager.Position = bindingManager.Count - 1;
                MessageBox.Show("Переход к последней записи", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Обновить
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                MessageBox.Show("Данные успешно обновлены!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Новая запись
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox8.DataBindings.Clear();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            textBox2.Focus();

            MessageBox.Show("Введите данные для новой записи.\nКод кафедры будет присвоен автоматически.",
                "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Добавить запись
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Поле 'название' не может быть пустым!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                Sql = @"INSERT INTO Кафедры (название, факультет, фио_заведующего, 
                        номер_комнаты, номер_корпуса, телефон, кол_во_преподавателей) 
                        VALUES (@название, @факультет, @фио_заведующего, 
                        @номер_комнаты, @номер_корпуса, @телефон, @кол_во_преподавателей);
                        SELECT SCOPE_IDENTITY();"; 

                myCommand = new SqlCommand(Sql, DBConnection.Instance().Connection);
                myCommand.Parameters.AddWithValue("@название", textBox2.Text);
                myCommand.Parameters.AddWithValue("@факультет", textBox3.Text);
                myCommand.Parameters.AddWithValue("@фио_заведующего", textBox4.Text);
                myCommand.Parameters.AddWithValue("@номер_комнаты", textBox5.Text);
                myCommand.Parameters.AddWithValue("@номер_корпуса", textBox6.Text);
                myCommand.Parameters.AddWithValue("@телефон", textBox7.Text);
                myCommand.Parameters.AddWithValue("@кол_во_преподавателей", textBox8.Text);

                int newId = Convert.ToInt32(myCommand.ExecuteScalar());

                ds1.Clear();
                dataAdapter1.Fill(ds1, "Кафедры");

                MessageBox.Show($"Запись успешно добавлена! Новый код кафедры: {newId}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                bindingManager.Position = bindingManager.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удалить запись
        private void button8_Click(object sender, EventArgs e)
        {
            if (bindingManager == null || bindingManager.Count == 0)
            {
                MessageBox.Show("Нет записей для удаления!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Sql = "DELETE FROM Кафедры WHERE код_кафедры = @код_кафедры";
                    myCommand = new SqlCommand(Sql, DBConnection.Instance().Connection);
                    myCommand.Parameters.AddWithValue("@код_кафедры", textBox1.Text);

                    myCommand.ExecuteNonQuery();

                    ds1.Clear();
                    dataAdapter1.Fill(ds1, "Кафедры");

                    MessageBox.Show("Запись успешно удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}