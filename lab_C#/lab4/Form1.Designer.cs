namespace UniversityClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // DataGridView для трех таблиц
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;

        // GroupBox
        private System.Windows.Forms.GroupBox groupBoxTables;
        private System.Windows.Forms.GroupBox groupBoxInsert;
        private System.Windows.Forms.GroupBox groupBoxDelete;
        private System.Windows.Forms.GroupBox groupBoxDDL;
        private System.Windows.Forms.GroupBox groupBoxSelect;

        // Поля для INSERT
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFaculty;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCount;

        // Поля для DELETE
        private System.Windows.Forms.TextBox txtDeleteValue;
        private System.Windows.Forms.Label lblDeleteValue;

        // Поля для DDL
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtDropTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblDropTableName;

        // Поля для SELECT
        private System.Windows.Forms.TextBox txtSqlQuery;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblSqlQuery;
        private System.Windows.Forms.Label lblResult;

        // Кнопки
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnDropTable;
        private System.Windows.Forms.Button btnExecuteSelect;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;

        // Статус
        private System.Windows.Forms.Label lblCountResult;
        private System.Windows.Forms.Label statusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.groupBoxInsert = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.txtFaculty = new System.Windows.Forms.TextBox();
            this.lblHead = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBoxDelete = new System.Windows.Forms.GroupBox();
            this.lblDeleteValue = new System.Windows.Forms.Label();
            this.txtDeleteValue = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBoxDDL = new System.Windows.Forms.GroupBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.lblDropTableName = new System.Windows.Forms.Label();
            this.txtDropTableName = new System.Windows.Forms.TextBox();
            this.btnDropTable = new System.Windows.Forms.Button();
            this.groupBoxSelect = new System.Windows.Forms.GroupBox();
            this.lblSqlQuery = new System.Windows.Forms.Label();
            this.txtSqlQuery = new System.Windows.Forms.TextBox();
            this.btnExecuteSelect = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCountResult = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBoxTables.SuspendLayout();
            this.groupBoxInsert.SuspendLayout();
            this.groupBoxDelete.SuspendLayout();
            this.groupBoxDDL.SuspendLayout();
            this.groupBoxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(940, 168);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Location = new System.Drawing.Point(6, 193);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(940, 159);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Location = new System.Drawing.Point(6, 358);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(940, 168);
            this.dataGridView3.TabIndex = 2;
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.dataGridView1);
            this.groupBoxTables.Controls.Add(this.dataGridView2);
            this.groupBoxTables.Controls.Add(this.dataGridView3);
            this.groupBoxTables.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(960, 532);
            this.groupBoxTables.TabIndex = 0;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "📊 Таблицы базы данных";
            // 
            // groupBoxInsert
            // 
            this.groupBoxInsert.Controls.Add(this.lblName);
            this.groupBoxInsert.Controls.Add(this.txtName);
            this.groupBoxInsert.Controls.Add(this.lblFaculty);
            this.groupBoxInsert.Controls.Add(this.txtFaculty);
            this.groupBoxInsert.Controls.Add(this.lblHead);
            this.groupBoxInsert.Controls.Add(this.txtHead);
            this.groupBoxInsert.Controls.Add(this.lblRoom);
            this.groupBoxInsert.Controls.Add(this.txtRoom);
            this.groupBoxInsert.Controls.Add(this.lblBuilding);
            this.groupBoxInsert.Controls.Add(this.txtBuilding);
            this.groupBoxInsert.Controls.Add(this.lblPhone);
            this.groupBoxInsert.Controls.Add(this.txtPhone);
            this.groupBoxInsert.Controls.Add(this.lblCount);
            this.groupBoxInsert.Controls.Add(this.txtCount);
            this.groupBoxInsert.Controls.Add(this.btnInsert);
            this.groupBoxInsert.Location = new System.Drawing.Point(24, 550);
            this.groupBoxInsert.Name = "groupBoxInsert";
            this.groupBoxInsert.Size = new System.Drawing.Size(460, 180);
            this.groupBoxInsert.TabIndex = 1;
            this.groupBoxInsert.TabStop = false;
            this.groupBoxInsert.Text = "✏️ INSERT (Добавление кафедры)";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblFaculty
            // 
            this.lblFaculty.Location = new System.Drawing.Point(10, 50);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(80, 20);
            this.lblFaculty.TabIndex = 2;
            this.lblFaculty.Text = "Факультет:";
            // 
            // txtFaculty
            // 
            this.txtFaculty.Location = new System.Drawing.Point(100, 47);
            this.txtFaculty.Name = "txtFaculty";
            this.txtFaculty.Size = new System.Drawing.Size(150, 20);
            this.txtFaculty.TabIndex = 3;
            // 
            // lblHead
            // 
            this.lblHead.Location = new System.Drawing.Point(10, 75);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(80, 20);
            this.lblHead.TabIndex = 4;
            this.lblHead.Text = "Заведующий:";
            // 
            // txtHead
            // 
            this.txtHead.Location = new System.Drawing.Point(100, 72);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(150, 20);
            this.txtHead.TabIndex = 5;
            // 
            // lblRoom
            // 
            this.lblRoom.Location = new System.Drawing.Point(260, 25);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(90, 20);
            this.lblRoom.TabIndex = 6;
            this.lblRoom.Text = "Номер комнаты:";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(355, 22);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(80, 20);
            this.txtRoom.TabIndex = 7;
            // 
            // lblBuilding
            // 
            this.lblBuilding.Location = new System.Drawing.Point(260, 50);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(90, 20);
            this.lblBuilding.TabIndex = 8;
            this.lblBuilding.Text = "Номер корпуса:";
            // 
            // txtBuilding
            // 
            this.txtBuilding.Location = new System.Drawing.Point(355, 47);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(80, 20);
            this.txtBuilding.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(260, 75);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(90, 20);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(355, 72);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(80, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(10, 100);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(120, 20);
            this.lblCount.TabIndex = 12;
            this.lblCount.Text = "Кол-во преподавателей:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(135, 97);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(80, 20);
            this.txtCount.TabIndex = 13;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightGreen;
            this.btnInsert.Location = new System.Drawing.Point(260, 97);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 30);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "➕ ДОБАВИТЬ";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // groupBoxDelete
            // 
            this.groupBoxDelete.Controls.Add(this.lblDeleteValue);
            this.groupBoxDelete.Controls.Add(this.txtDeleteValue);
            this.groupBoxDelete.Controls.Add(this.btnDelete);
            this.groupBoxDelete.Location = new System.Drawing.Point(490, 550);
            this.groupBoxDelete.Name = "groupBoxDelete";
            this.groupBoxDelete.Size = new System.Drawing.Size(240, 80);
            this.groupBoxDelete.TabIndex = 2;
            this.groupBoxDelete.TabStop = false;
            this.groupBoxDelete.Text = "🗑️ DELETE (Удаление кафедр по слову в названии)";
            // 
            // lblDeleteValue
            // 
            this.lblDeleteValue.Location = new System.Drawing.Point(10, 25);
            this.lblDeleteValue.Name = "lblDeleteValue";
            this.lblDeleteValue.Size = new System.Drawing.Size(100, 20);
            this.lblDeleteValue.TabIndex = 0;
            this.lblDeleteValue.Text = "Слово для поиска:";
            // 
            // txtDeleteValue
            // 
            this.txtDeleteValue.Location = new System.Drawing.Point(120, 22);
            this.txtDeleteValue.Name = "txtDeleteValue";
            this.txtDeleteValue.Size = new System.Drawing.Size(100, 20);
            this.txtDeleteValue.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(120, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ УДАЛИТЬ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBoxDDL
            // 
            this.groupBoxDDL.Controls.Add(this.lblTableName);
            this.groupBoxDDL.Controls.Add(this.txtTableName);
            this.groupBoxDDL.Controls.Add(this.btnCreateTable);
            this.groupBoxDDL.Controls.Add(this.lblDropTableName);
            this.groupBoxDDL.Controls.Add(this.txtDropTableName);
            this.groupBoxDDL.Controls.Add(this.btnDropTable);
            this.groupBoxDDL.Location = new System.Drawing.Point(490, 650);
            this.groupBoxDDL.Name = "groupBoxDDL";
            this.groupBoxDDL.Size = new System.Drawing.Size(240, 117);
            this.groupBoxDDL.TabIndex = 3;
            this.groupBoxDDL.TabStop = false;
            this.groupBoxDDL.Text = "🗄️ DDL (CREATE TABLE / DROP TABLE)";
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(10, 20);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(100, 20);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Название таблицы:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(120, 17);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(100, 20);
            this.txtTableName.TabIndex = 1;
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(10, 45);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(100, 25);
            this.btnCreateTable.TabIndex = 2;
            this.btnCreateTable.Text = "📋 CREATE TABLE";
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // lblDropTableName
            // 
            this.lblDropTableName.Location = new System.Drawing.Point(10, 55);
            this.lblDropTableName.Name = "lblDropTableName";
            this.lblDropTableName.Size = new System.Drawing.Size(100, 20);
            this.lblDropTableName.TabIndex = 3;
            this.lblDropTableName.Text = "Удалить таблицу:";
            // 
            // txtDropTableName
            // 
            this.txtDropTableName.Location = new System.Drawing.Point(120, 52);
            this.txtDropTableName.Name = "txtDropTableName";
            this.txtDropTableName.Size = new System.Drawing.Size(100, 20);
            this.txtDropTableName.TabIndex = 4;
            // 
            // btnDropTable
            // 
            this.btnDropTable.Location = new System.Drawing.Point(10, 80);
            this.btnDropTable.Name = "btnDropTable";
            this.btnDropTable.Size = new System.Drawing.Size(100, 25);
            this.btnDropTable.TabIndex = 5;
            this.btnDropTable.Text = "🗑️ DROP TABLE";
            this.btnDropTable.Click += new System.EventHandler(this.btnDropTable_Click);
            // 
            // groupBoxSelect
            // 
            this.groupBoxSelect.Controls.Add(this.lblSqlQuery);
            this.groupBoxSelect.Controls.Add(this.txtSqlQuery);
            this.groupBoxSelect.Controls.Add(this.btnExecuteSelect);
            this.groupBoxSelect.Controls.Add(this.lblResult);
            this.groupBoxSelect.Controls.Add(this.txtResult);
            this.groupBoxSelect.Location = new System.Drawing.Point(24, 764);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Size = new System.Drawing.Size(940, 150);
            this.groupBoxSelect.TabIndex = 4;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "📝 SELECT (Выполнить SQL запрос)";
            // 
            // lblSqlQuery
            // 
            this.lblSqlQuery.Location = new System.Drawing.Point(10, 20);
            this.lblSqlQuery.Name = "lblSqlQuery";
            this.lblSqlQuery.Size = new System.Drawing.Size(80, 20);
            this.lblSqlQuery.TabIndex = 0;
            this.lblSqlQuery.Text = "SQL Запрос:";
            // 
            // txtSqlQuery
            // 
            this.txtSqlQuery.Location = new System.Drawing.Point(100, 17);
            this.txtSqlQuery.Name = "txtSqlQuery";
            this.txtSqlQuery.Size = new System.Drawing.Size(600, 20);
            this.txtSqlQuery.TabIndex = 1;
            this.txtSqlQuery.Text = "SELECT * FROM Кафедры";
            // 
            // btnExecuteSelect
            // 
            this.btnExecuteSelect.Location = new System.Drawing.Point(710, 15);
            this.btnExecuteSelect.Name = "btnExecuteSelect";
            this.btnExecuteSelect.Size = new System.Drawing.Size(100, 25);
            this.btnExecuteSelect.TabIndex = 2;
            this.btnExecuteSelect.Text = "▶️ ВЫПОЛНИТЬ";
            this.btnExecuteSelect.Click += new System.EventHandler(this.btnExecuteSelect_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(10, 50);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(80, 20);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Результат:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(100, 50);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(710, 80);
            this.txtResult.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.Location = new System.Drawing.Point(748, 550);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(200, 30);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "✏️ UPDATE (+100 к аудиториям)";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCount
            // 
            this.btnCount.BackColor = System.Drawing.Color.LightYellow;
            this.btnCount.Location = new System.Drawing.Point(745, 587);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(200, 30);
            this.btnCount.TabIndex = 6;
            this.btnCount.Text = "📊 COUNT (Подсчитать записи)";
            this.btnCount.UseVisualStyleBackColor = false;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(745, 694);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 30);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "🔄 ОБНОВИТЬ ДАННЫЕ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(745, 730);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 30);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "🧹 ОЧИСТИТЬ ПОЛЯ";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCountResult
            // 
            this.lblCountResult.BackColor = System.Drawing.Color.LightYellow;
            this.lblCountResult.Location = new System.Drawing.Point(745, 620);
            this.lblCountResult.Name = "lblCountResult";
            this.lblCountResult.Size = new System.Drawing.Size(200, 70);
            this.lblCountResult.TabIndex = 7;
            this.lblCountResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.LightGray;
            this.statusLabel.Location = new System.Drawing.Point(24, 930);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(940, 25);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "Статус: Готов";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(987, 959);
            this.Controls.Add(this.groupBoxTables);
            this.Controls.Add(this.groupBoxInsert);
            this.Controls.Add(this.groupBoxDelete);
            this.Controls.Add(this.groupBoxDDL);
            this.Controls.Add(this.groupBoxSelect);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.lblCountResult);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.statusLabel);
            this.Name = "Form1";
            this.Text = "🏫 University Client - Управление базой данных";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxInsert.ResumeLayout(false);
            this.groupBoxInsert.PerformLayout();
            this.groupBoxDelete.ResumeLayout(false);
            this.groupBoxDelete.PerformLayout();
            this.groupBoxDDL.ResumeLayout(false);
            this.groupBoxDDL.PerformLayout();
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxSelect.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}