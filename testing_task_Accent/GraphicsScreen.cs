using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace testing_task_Accent
{
    public partial class GraphicsScreen : Form
    {
        ManagerSQL managerSQL;
        public GraphicsScreen(ManagerSQL loadManagerSQL)
        {
            InitializeComponent();
            managerSQL = loadManagerSQL;

            comboBox1.DataSource = managerSQL.selectStatusTableColumnName();
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;

            DataTable allStatuses = managerSQL.selectStatusTableColumnName();
            DataView view = new DataView(allStatuses);
            view.RowFilter = "Name IN ('Уволен', 'Стажировка')";
            comboBox2.DataSource = view;
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            chart1.ChartAreas.Add(new ChartArea("ChartArea1"));

            chart1.Legends.Add(new Legend("Legend1"));
            chart1.Legends[0].Docking = Docking.Top;

            Series series = new Series("Сотрудники");
            series.ChartType = SeriesChartType.Column; // столбцы
            series.IsValueShownAsLabel = true; // показывать значения на столбцах

            series.Points.AddXY(comboBox1.Text, managerSQL.countStatusPerson(comboBox1.Text));

            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;

            chart1.ChartAreas[0].AxisX.Title = "Статус";
            chart1.ChartAreas[0].AxisY.Title = "Количество сотрудников";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            // Добавляем область графика
            chart1.ChartAreas.Add(new ChartArea("ChartArea1"));

            // Добавляем легенду
            chart1.Legends.Add(new Legend("Legend1"));
            chart1.Legends[0].Docking = Docking.Top;

            // Создаём серию
            Series series = new Series("Сотрудники");
            series.ChartType = SeriesChartType.Column; // столбцы
            series.IsValueShownAsLabel = true; // показывать значения на столбцах

            // Добавляем точки из DataTable
            foreach (DataRow row in managerSQL.timePeriodPerson(comboBox2.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date).Rows)
            {
                string dateStr = Convert.ToDateTime(row["EventDate"]).ToString("yyyy-MM-dd");
                int count = Convert.ToInt32(row["EmployeeCount"]);
                series.Points.AddXY(dateStr, count);
            }

            // Добавляем серию на график
            chart1.Series.Add(series);

            // Настройка осей и чистого фона
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.Title = "Дата";
            chart1.ChartAreas[0].AxisY.Title = "Количество сотрудников";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // наклон подписей для дат
            chart1.ChartAreas[0].BackColor = Color.Transparent; // прозрачный фон
        }
    }
}
