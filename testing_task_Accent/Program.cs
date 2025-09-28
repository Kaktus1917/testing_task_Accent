using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing_task_Accent
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Проверка наличия настроект
            var setting = new SaveSystem();
            setting.loadSetting();
            if (!setting.checkSetting()) 
            {Application.Run(new SettingSQL(setting));
            }else
            {Application.Run(new MainScreen(setting));}
        }
    }
}
