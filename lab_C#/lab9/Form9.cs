using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace lab6
{
    public partial class Form9 : Form
    {
        private System.Data.DataTable studentsTable;

        public Form9()
        {
            InitializeComponent();
            LoadStudentsData();
        }

        private void LoadStudentsData()
        {
            try
            {
                studentsTable = new System.Data.DataTable();

                // Исправленный запрос - только существующие столбцы
                string query = @"SELECT 
                                    код_студента,
                                    фамилия,
                                    имя,
                                    отчество,
                                    кафедра,
                                    год_рождения
                                FROM Студенты";

                DBConnection db = DBConnection.Instance();

                // Проверяем, открыто ли подключение
                if (db.Connection.State != ConnectionState.Open)
                {
                    db.Open();
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection);
                adapter.Fill(studentsTable);

                dataGridView1.DataSource = studentsTable;

                // Настройка внешнего вида DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.BackgroundColor = System.Drawing.Color.White;
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.GridColor = System.Drawing.Color.FromArgb(200, 200, 200);
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Переименовываем заголовки столбцов
                if (dataGridView1.Columns["код_студента"] != null)
                    dataGridView1.Columns["код_студента"].HeaderText = "Код студента";
                if (dataGridView1.Columns["фамилия"] != null)
                    dataGridView1.Columns["фамилия"].HeaderText = "Фамилия";
                if (dataGridView1.Columns["имя"] != null)
                    dataGridView1.Columns["имя"].HeaderText = "Имя";
                if (dataGridView1.Columns["отчество"] != null)
                    dataGridView1.Columns["отчество"].HeaderText = "Отчество";
                if (dataGridView1.Columns["кафедра"] != null)
                    dataGridView1.Columns["кафедра"].HeaderText = "Кафедра";
                if (dataGridView1.Columns["год_рождения"] != null)
                    dataGridView1.Columns["год_рождения"].HeaderText = "Год рождения";

                label1.Text = $"Таблица Студенты (всего: {studentsTable.Rows.Count} записей)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ExportToWord();
            }
            else if (radioButton2.Checked)
            {
                ExportToExcel();
            }
            else if (radioButton3.Checked)
            {
                ExportChartToExcel();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тип отчета!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportToWord()
        {
            try
            {
                if (studentsTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта!", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Word.Application wrdapp = new Word.Application();
                wrdapp.Visible = true;
                object oMissing = System.Reflection.Missing.Value;

                Word.Document wrddoc = wrdapp.Documents.Add();

                // Добавление рисунка (если файл существует)
                string filename = @"D:\2.jpg";
                if (File.Exists(filename))
                {
                    Word.InlineShape newPicture = wrddoc.InlineShapes.AddPicture(filename);
                    newPicture.Height = 200;
                    newPicture.Width = 200;
                    Word.Paragraph paraPic = wrddoc.Paragraphs.Add();
                    paraPic.Range.Text = "\n";
                }

                // Заголовок
                Word.Range rng = wrddoc.Range(0, 0);
                rng.Text = label1.Text;

                // Форматирование заголовка
                wrddoc.Paragraphs[1].Range.Font.Bold = 20;
                wrddoc.Paragraphs[1].Range.Font.Size = 18;
                wrddoc.Paragraphs[1].Range.Font.Name = "Times New Roman";
                wrddoc.Paragraphs[1].Range.Font.ColorIndex = Word.WdColorIndex.wdDarkBlue;
                wrddoc.Paragraphs[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // Пустые абзацы
                wrddoc.Paragraphs.Add();
                wrddoc.Paragraphs.Add();

                // Создание таблицы
                Word.Paragraph tablePara = wrddoc.Paragraphs.Add();
                Word.Range tableRange = tablePara.Range;
                Word.Table newTable = wrddoc.Tables.Add(tableRange, studentsTable.Rows.Count + 1, studentsTable.Columns.Count, ref oMissing, ref oMissing);

                newTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                newTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                // Заполнение заголовков
                for (int j = 0; j < studentsTable.Columns.Count; j++)
                {
                    newTable.Cell(1, j + 1).Range.Text = studentsTable.Columns[j].ColumnName;
                    newTable.Cell(1, j + 1).Range.Font.Bold = 20;
                    newTable.Cell(1, j + 1).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                }

                // Заполнение данных
                for (int i = 0; i < studentsTable.Rows.Count; i++)
                {
                    for (int j = 0; j < studentsTable.Columns.Count; j++)
                    {
                        if (studentsTable.Rows[i][j] != DBNull.Value)
                        {
                            newTable.Cell(i + 2, j + 1).Range.Text = studentsTable.Rows[i][j].ToString();
                        }
                    }
                }

                newTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

                MessageBox.Show("Отчет в Word успешно создан!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета в Word: {ex.Message}\n\nУбедитесь, что установлен Microsoft Word", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel()
        {
            try
            {
                if (studentsTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта!", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application expapp = new Excel.Application();
                expapp.Visible = true;

                Excel.Workbook expbook = expapp.Workbooks.Add();
                Excel.Worksheet worksheet = expapp.Worksheets[1];
                worksheet.Name = "Студенты";

                // Заголовок
                worksheet.Cells[1, 1] = label1.Text;
                worksheet.Cells[1, 1].Font.Bold = 20;
                worksheet.Cells[1, 1].Font.Size = 18;
                worksheet.Cells[1, 1].Font.Name = "Times New Roman";
                worksheet.Cells[1, 1].Font.Color = Excel.XlRgbColor.rgbDarkBlue;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Объединение ячеек для заголовка
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, studentsTable.Columns.Count]];
                titleRange.Merge();

                // Заголовки столбцов
                for (int j = 0; j < studentsTable.Columns.Count; j++)
                {
                    worksheet.Cells[2, j + 1] = studentsTable.Columns[j].ColumnName;
                    worksheet.Cells[2, j + 1].Font.Bold = 20;
                    worksheet.Cells[2, j + 1].Interior.Color = Excel.XlRgbColor.rgbLightGray;
                }

                // Данные
                for (int i = 0; i < studentsTable.Rows.Count; i++)
                {
                    for (int j = 0; j < studentsTable.Columns.Count; j++)
                    {
                        if (studentsTable.Rows[i][j] != DBNull.Value)
                        {
                            worksheet.Cells[i + 3, j + 1] = studentsTable.Rows[i][j].ToString();
                        }
                    }
                }

                // Форматирование диапазона с данными
                Excel.Range dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[studentsTable.Rows.Count + 2, studentsTable.Columns.Count]];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.EntireColumn.AutoFit();
                dataRange.EntireRow.AutoFit();

                MessageBox.Show("Отчет в Excel успешно создан!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета в Excel: {ex.Message}\n\nУбедитесь, что установлен Microsoft Excel", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportChartToExcel()
        {
            try
            {
                if (studentsTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта!", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application expapp = new Excel.Application();
                expapp.Visible = true;

                Excel.Workbook expbook = expapp.Workbooks.Add();
                Excel.Worksheet worksheet = expapp.Worksheets[1];
                worksheet.Name = "Диаграмма студентов";

                // Заголовок
                worksheet.Cells[1, 1] = "Анализ данных студентов";
                worksheet.Cells[1, 1].Font.Bold = 20;
                worksheet.Cells[1, 1].Font.Size = 16;
                worksheet.Cells[1, 1].Font.Name = "Times New Roman";

                Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]];
                titleRange.Merge();

                // Заголовки для диаграммы
                worksheet.Cells[3, 1] = "Фамилия Имя";
                worksheet.Cells[3, 2] = "Год рождения";

                worksheet.Cells[3, 1].Font.Bold = 20;
                worksheet.Cells[3, 2].Font.Bold = 20;
                worksheet.Cells[3, 1].Interior.Color = Excel.XlRgbColor.rgbLightGray;
                worksheet.Cells[3, 2].Interior.Color = Excel.XlRgbColor.rgbLightGray;

                // Данные для диаграммы (берем первые 10 записей)
                int row = 4;
                for (int i = 0; i < studentsTable.Rows.Count && i < 10; i++)
                {
                    string fullName = studentsTable.Rows[i]["фамилия"]?.ToString() + " " +
                                     studentsTable.Rows[i]["имя"]?.ToString();
                    worksheet.Cells[row, 1] = fullName;
                    worksheet.Cells[row, 2] = studentsTable.Rows[i]["год_рождения"];
                    row++;
                }

                // Создание диаграммы
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(100, 150, 500, 350);
                Excel.Chart chart = myChart.Chart;

                // Настройка диапазона для диаграммы
                Excel.Range chartRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[row - 1, 2]];
                chart.SetSourceData(chartRange);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Годы рождения студентов";
                chart.ChartTitle.Font.Size = 14;
                chart.ChartTitle.Font.Bold = true;

                // Настройка осей
                Excel.Axis xAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.HasTitle = true;
                xAxis.AxisTitle.Text = "Студенты";
                xAxis.AxisTitle.Font.Size = 12;

                Excel.Axis yAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                yAxis.HasTitle = true;
                yAxis.AxisTitle.Text = "Год рождения";
                yAxis.AxisTitle.Font.Size = 12;

                chart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                worksheet.Columns.AutoFit();

                MessageBox.Show("Диаграмма в Excel успешно создана!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании диаграммы: {ex.Message}\n\nУбедитесь, что установлен Microsoft Excel", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}