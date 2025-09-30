using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing_task_Accent.Properties;

namespace testing_task_Accent
{
    public partial class MainScreen : Form
    {
        private ManagerSQL managerSQL;
        private SaveSystem setting;

        private bool _isUpdating = false;
        private List<CheckBox> myChecks; //лист чекбоксов

        private int _indexSelectComboBox1;
        private int _indexSelectComboBox2;
        public MainScreen(SaveSystem loadedSetting)
        {
            InitializeComponent();
            managerSQL = new ManagerSQL();
            setting = loadedSetting;
            managerSQL.connectDB(setting);

            //Заполняем Grid и форматируем 
            dataGridView1.DataSource = managerSQL.selectViewTable();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView1.CellFormatting += formattingCellDataGrid;
            //Выключения полей для избежания не верного ввода данных
            panelFilterName.Enabled = false;
            panelFilterStatus.Enabled = false;
            panelFilterDeps.Enabled = false;
            panelFilterPosts.Enabled = false;
            //Стандартные параметры в фильтрацию и сортировку
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;

            //Заполняем комбо для фильтрации
            statusCombo.DataSource = managerSQL.selectStatusTableColumnName();
            statusCombo.DisplayMember = "Name";
            departCombo.DataSource = managerSQL.selectDepsTableColumnName();
            departCombo.DisplayMember = "Name";
            postCombo.DataSource = managerSQL.selectPostTableColumnName();
            postCombo.DisplayMember = "Name";

            //Добавляем чекбоксы
            myChecks = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6};
            //Подписываем на событие
            for (int i = 0; i < myChecks.Count; i++)
            {
                var cb = myChecks[i];
                cb.CheckedChanged += checkedChangedCheckBox;
                cb.Text = dataGridView1.Columns[i].HeaderText;
            }
        }

        private void formattingCellDataGrid(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            if (row.Cells["Статус"].Value != null &&
                row.Cells["Статус"].Value.Equals("Уволен"))
            {
                row.DefaultCellStyle.BackColor = Color.Gray;
                row.DefaultCellStyle.ForeColor = Color.LightGray;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            }
        }

        private void checkedChangedCheckBox(object sender, EventArgs e)
        {
            if (_isUpdating) return;

            var changed = sender as CheckBox;
            if (changed == null) return;

            if (changed.Checked)
            {
                _isUpdating = true;
                foreach (var cb in myChecks)
                {
                    if (!ReferenceEquals(cb, changed))
                        cb.Checked = false;
                }
                _isUpdating = false;
            }
        }

        private void Settingbtn_Click(object sender, EventArgs e)
        {
            SettingSQL settingScreen = new SettingSQL(setting);
            settingScreen.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            { case 0:
                    panelFilterName.Enabled = true;
                    panelFilterStatus.Enabled = false;
                    panelFilterDeps.Enabled = false;
                    panelFilterPosts.Enabled = false;
                    break;
              case 1:
                    panelFilterName.Enabled = false;
                    panelFilterStatus.Enabled = true;
                    panelFilterDeps.Enabled = false;
                    panelFilterPosts.Enabled = false;
                    break;
              case 2:
                    panelFilterName.Enabled = false;
                    panelFilterStatus.Enabled = false;
                    panelFilterDeps.Enabled = true;
                    panelFilterPosts.Enabled = false;
                    break;
              case 3:
                    panelFilterName.Enabled = false;
                    panelFilterStatus.Enabled = false;
                    panelFilterDeps.Enabled = false;
                    panelFilterPosts.Enabled = true;
                    break;
              case 4:
                    panelFilterName.Enabled= true;
                    panelFilterStatus.Enabled= true;
                    panelFilterDeps.Enabled= true;
                    panelFilterPosts.Enabled= true;
                    break;
            }

            _indexSelectComboBox1 = comboBox1.SelectedIndex;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _indexSelectComboBox2 = comboBox2.SelectedIndex;
        }

        private void ApplySearchbtn_Click(object sender, EventArgs e)
        {
            string fullName = null; 
            string status = null; 
            string depo = null; 
            string post = null; 
            string dir = null; 
            string sortColumn = null;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fullName = nameEmployee.Text;
                    break;
                case 1:
                    status = statusCombo.Text;
                    break;
                case 2:
                    depo = departCombo.Text;
                    break;
                case 3:
                    post = postCombo.Text;
                    break;
                case 4:
                    fullName = nameEmployee.Text;
                    status = statusCombo.Text;
                    depo = departCombo.Text;
                    post = postCombo.Text;
                    break;
            }

            switch (comboBox2.SelectedIndex) 
            {
                case 0:
                    dir = "asc";
                    break; 
                case 1:
                    dir = "desc";
                    break;
                case 2:
                    dir = null;
                    break;
            }

            foreach (var ch in myChecks)
            {
                if (ch.Checked) 
                {
                    sortColumn = ch.Text;
                }
            }

            dataGridView1.DataSource = managerSQL.selectSortAndFilterViewTable(fullName, status, depo, post, dir, sortColumn);
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void BuildGraphbtn_Click(object sender, EventArgs e)
        {
            GraphicsScreen graphics = new GraphicsScreen(managerSQL);
            graphics.Show();
        }

        private void nameEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'А' && e.KeyChar <= 'Я') ||
                (e.KeyChar >= 'а' && e.KeyChar <= 'я')))
            {
                e.Handled = true;
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
