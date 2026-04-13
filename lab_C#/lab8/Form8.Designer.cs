namespace lab6
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxConditions = new System.Windows.Forms.GroupBox();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.lstConditions = new System.Windows.Forms.ListBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFieldName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(400, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 Поиск и фильтрация данных";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelFooter.Controls.Add(this.lblStatus);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 460);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1100, 35);
            this.panelFooter.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(450, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(180, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "✅ Готов к поиску. Выберите таблицу";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelFilter.Controls.Add(this.groupBoxFilter);
            this.panelFilter.Controls.Add(this.groupBoxConditions);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFilter.Location = new System.Drawing.Point(750, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(350, 400);
            this.panelFilter.TabIndex = 3;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.btnClearFilter);
            this.groupBoxFilter.Controls.Add(this.btnSearch);
            this.groupBoxFilter.Controls.Add(this.cmbTableName);
            this.groupBoxFilter.Controls.Add(this.label9);
            this.groupBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilter.Location = new System.Drawing.Point(10, 15);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(330, 120);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "📊 Выбор таблицы";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.Location = new System.Drawing.Point(170, 80);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(140, 30);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.Text = "❌ Очистить фильтр";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(20, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Выполнить поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbTableName
            // 
            this.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTableName.Items.AddRange(new object[] {
            "Студенты",
            "Преподаватели",
            "Кафедры",
            "Дисциплины",
            "Ведомости"});
            this.cmbTableName.Location = new System.Drawing.Point(20, 45);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(290, 25);
            this.cmbTableName.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(20, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Выберите таблицу:";
            // 
            // groupBoxConditions
            // 
            this.groupBoxConditions.Controls.Add(this.btnRemoveCondition);
            this.groupBoxConditions.Controls.Add(this.lstConditions);
            this.groupBoxConditions.Controls.Add(this.btnAddCondition);
            this.groupBoxConditions.Controls.Add(this.txtSearchValue);
            this.groupBoxConditions.Controls.Add(this.label3);
            this.groupBoxConditions.Controls.Add(this.cmbOperator);
            this.groupBoxConditions.Controls.Add(this.label2);
            this.groupBoxConditions.Controls.Add(this.cmbFieldName);
            this.groupBoxConditions.Controls.Add(this.label1);
            this.groupBoxConditions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxConditions.Location = new System.Drawing.Point(10, 145);
            this.groupBoxConditions.Name = "groupBoxConditions";
            this.groupBoxConditions.Size = new System.Drawing.Size(330, 240);
            this.groupBoxConditions.TabIndex = 1;
            this.groupBoxConditions.TabStop = false;
            this.groupBoxConditions.Text = "🔧 Условия фильтрации";
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnRemoveCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCondition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveCondition.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCondition.Location = new System.Drawing.Point(255, 170);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(55, 64);
            this.btnRemoveCondition.TabIndex = 8;
            this.btnRemoveCondition.Text = "❌\r\nУдалить";
            this.btnRemoveCondition.UseVisualStyleBackColor = false;
            // 
            // lstConditions
            // 
            this.lstConditions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstConditions.FormattingEnabled = true;
            this.lstConditions.ItemHeight = 15;
            this.lstConditions.Location = new System.Drawing.Point(20, 170);
            this.lstConditions.Name = "lstConditions";
            this.lstConditions.Size = new System.Drawing.Size(230, 64);
            this.lstConditions.TabIndex = 7;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAddCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCondition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCondition.ForeColor = System.Drawing.Color.White;
            this.btnAddCondition.Location = new System.Drawing.Point(20, 130);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(290, 30);
            this.btnAddCondition.TabIndex = 6;
            this.btnAddCondition.Text = "➕ Добавить условие";
            this.btnAddCondition.UseVisualStyleBackColor = false;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchValue.Location = new System.Drawing.Point(20, 98);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(290, 23);
            this.txtSearchValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Значение:";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbOperator.Items.AddRange(new object[] {
            "=",
            "≠",
            ">",
            "<",
            "≥",
            "≤",
            "содержит",
            "начинается с",
            "заканчивается на"});
            this.cmbOperator.Location = new System.Drawing.Point(170, 48);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(140, 23);
            this.cmbOperator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(170, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Оператор:";
            // 
            // cmbFieldName
            // 
            this.cmbFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFieldName.Location = new System.Drawing.Point(20, 48);
            this.cmbFieldName.Name = "cmbFieldName";
            this.cmbFieldName.Size = new System.Drawing.Size(140, 23);
            this.cmbFieldName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поле для поиска:";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 495);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск и фильтрация данных";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxConditions.ResumeLayout(false);
            this.groupBoxConditions.PerformLayout();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbTableName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxConditions;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.ListBox lstConditions;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFieldName;
        private System.Windows.Forms.Label label1;
    }
}