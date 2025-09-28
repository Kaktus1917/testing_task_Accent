using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace testing_task_Accent
{
    public partial class SettingSQL : Form
    {
        private SaveSystem setting;
        public SettingSQL(SaveSystem Loadsetting)
        {
            InitializeComponent();
            setting = Loadsetting;

            ServerDBtb.Text = setting.ServerSQL;
            NameDBtb.Text = setting.NameDB;
            NameUsertb.Text = setting.NameUser;
            PasswordUsertb.Text = setting.PasswordUser;
        }

        private void buttonSaveSettingConnecSQL_Click(object sender, EventArgs e)
        {
            //Проверка ввода данных
            string serverSQL; string nameDB; string userName; string passwordUser;
            serverSQL = ServerDBtb.Text;
            nameDB = NameDBtb.Text;
            userName = NameUsertb.Text;
            passwordUser = PasswordUsertb.Text;

            if (string.IsNullOrWhiteSpace(serverSQL) || string.IsNullOrWhiteSpace(nameDB) ||
                string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passwordUser)) 
            {
                MessageBox.Show("Все поля должны быть заполнены","Ошибка ввода данных",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(serverSQL, "^[a-zA-Z0-9_]+$") || !Regex.IsMatch(nameDB, "^[a-zA-Z0-9_]+$") ||
                !Regex.IsMatch(userName, "^[a-zA-Z0-9_]+$") || !Regex.IsMatch(passwordUser, "^[a-zA-Z0-9_]+$")) 
            {
                MessageBox.Show("Введите данные латинскими буквами и без спец.символов", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Сохранение данных сервера и польщователя
            setting.saveSetting(serverSQL,nameDB,userName,passwordUser);


            //Переход на главную форму
            MainScreen main = new MainScreen(setting);
            main.Show();
            this.Hide();
        }
    }
}
