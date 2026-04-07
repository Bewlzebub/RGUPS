using System.Windows.Forms;

namespace lab5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.GroupBox groupBoxAuth;
        private System.Windows.Forms.RadioButton radioWindowsAuth;
        private System.Windows.Forms.RadioButton radioSQLServer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.groupBoxAuth = new System.Windows.Forms.GroupBox();
            this.radioWindowsAuth = new System.Windows.Forms.RadioButton();
            this.radioSQLServer = new System.Windows.Forms.RadioButton();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Администрирование";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServerName
            // 
            this.lblServerName.Location = new System.Drawing.Point(20, 55);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(100, 23);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Имя сервера:";
            this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(130, 55);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(200, 20);
            this.txtServerName.TabIndex = 2;
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Location = new System.Drawing.Point(20, 85);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(100, 23);
            this.lblDatabaseName.TabIndex = 3;
            this.lblDatabaseName.Text = "Имя базы данных:";
            this.lblDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(130, 85);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(200, 20);
            this.txtDatabaseName.TabIndex = 4;
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Controls.Add(this.radioWindowsAuth);
            this.groupBoxAuth.Controls.Add(this.radioSQLServer);
            this.groupBoxAuth.Controls.Add(this.lblUser);
            this.groupBoxAuth.Controls.Add(this.txtUser);
            this.groupBoxAuth.Controls.Add(this.lblPassword);
            this.groupBoxAuth.Controls.Add(this.txtPassword);
            this.groupBoxAuth.Location = new System.Drawing.Point(20, 115);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Size = new System.Drawing.Size(340, 150);
            this.groupBoxAuth.TabIndex = 5;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "Администрирование";
            // 
            // radioWindowsAuth
            // 
            this.radioWindowsAuth.Location = new System.Drawing.Point(20, 25);
            this.radioWindowsAuth.Name = "radioWindowsAuth";
            this.radioWindowsAuth.Size = new System.Drawing.Size(200, 24);
            this.radioWindowsAuth.TabIndex = 0;
            this.radioWindowsAuth.Text = "Аутентификация Windows";
            this.radioWindowsAuth.CheckedChanged += new System.EventHandler(this.radioWindowsAuth_CheckedChanged);
            // 
            // radioSQLServer
            // 
            this.radioSQLServer.Location = new System.Drawing.Point(20, 55);
            this.radioSQLServer.Name = "radioSQLServer";
            this.radioSQLServer.Size = new System.Drawing.Size(200, 24);
            this.radioSQLServer.TabIndex = 1;
            this.radioSQLServer.Text = "Аутентификация SQL Server";
            this.radioSQLServer.CheckedChanged += new System.EventHandler(this.radioSQLServer_CheckedChanged);
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(40, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(80, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Пользователь:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(130, 85);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(180, 20);
            this.txtUser.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(40, 115);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 115);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightGreen;
            this.btnLoad.Location = new System.Drawing.Point(150, 280);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 331);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.groupBoxAuth);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в подсистему";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}