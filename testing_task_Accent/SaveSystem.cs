using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Xml;
using System.Diagnostics;
namespace testing_task_Accent
{
    public class SaveSystem
    {
        //приватные значения
        private string _pathToFileSetting = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "config.json");
        private string _serverSQL;
        private string _nameDB;
        private string _nameUser;
        private string _passwordUser;

        //Приватные методы
        private void readFileSetting() 
        {
            if (File.Exists(_pathToFileSetting)) 
            {
                string json = File.ReadAllText(_pathToFileSetting);
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                _serverSQL = data.ContainsKey("ServerSQL") ? data["ServerSQL"] : "";
                _nameDB = data.ContainsKey("NameDB") ? data["NameDB"] : "";
                _nameUser = data.ContainsKey("NameUser") ? data["NameUser"] : "";
                _passwordUser = data.ContainsKey("PasswordUser") ? data["PasswordUser"] : "";

                Debug.WriteLine($"Файл есть, данные в файле: ServerSQL={_serverSQL}, NameDB={_nameDB}, NameUser={_nameUser}, PasswordUser={_passwordUser}");
            } 
            else{ File.WriteAllText(_pathToFileSetting, "{}"); }
        }

        private void changeFileSetting(string serverSQL, string nameDB, string nameUser, string passwordUser) 
        {
            if (File.Exists(_pathToFileSetting))
            {
                var settingJSON = new Dictionary<string, string> 
                {
                    { "ServerSQL", serverSQL },
                    { "NameDB", nameDB },
                    { "NameUser", nameUser },
                    { "PasswordUser", passwordUser }
                };

                var json = JsonSerializer.Serialize(settingJSON, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_pathToFileSetting, json);

                readFileSetting();
            }
            else { MessageBox.Show("Файл настроект не доступен", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //Публичные методы
        public void loadSetting() 
        {
            readFileSetting();
        }

        public void saveSetting(string InputServerSQL, string InputNameDB, string InputNameUser, string InputPasswordUser) 
        {
            changeFileSetting(InputServerSQL, InputNameDB, InputNameUser, InputPasswordUser);
        }

        public bool checkSetting() 
        {
            return (_serverSQL != null && _nameDB != null && _nameUser != null && _passwordUser != null);
        }

        //Сеттеры
        public string ServerSQL 
        {
            get => _serverSQL;
            set => _serverSQL = value;
        }

        public string NameDB 
        {
            get => _nameDB;
            set => _nameDB = value;
        }

        public string NameUser 
        {
            get => _nameUser;
            set => _nameUser = value;
        }

        public string PasswordUser 
        {
            get => _passwordUser;
            set => _passwordUser = value;
        }
    }
}
