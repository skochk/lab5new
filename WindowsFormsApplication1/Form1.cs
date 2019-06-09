using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadTable("default");
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void loadTable(string param)
        {
            string myConnection = "server=web113.default-host.net;Port=3306;uid=daleth_max;pwd=huE96m5VHbC3;database=daleth_warehouse";
            MySqlConnection myConnect = new MySqlConnection(myConnection);

            string selectQuery = "";

            try
            {
                myConnect.Open();

                if (param == "Перший") {
                    selectQuery =
                    "SELECT lesson_times, lesson_Monday, lesson_Tuesday, lesson_Wednesday, lesson_Thursday, lesson_Friday FROM daleth_warehouse.info_system WHERE study_week = 1;";
                }
                if (param == "Другий") {
                    selectQuery =
                    "SELECT lesson_times, lesson_Monday, lesson_Tuesday, lesson_Wednesday, lesson_Thursday, lesson_Friday FROM daleth_warehouse.info_system WHERE study_week = 2;";
                }

                if (param == "default")
                {
                    selectQuery =
                    "SELECT lesson_times, lesson_Monday, lesson_Tuesday, lesson_Wednesday, lesson_Thursday, lesson_Friday FROM daleth_warehouse.info_system WHERE study_week = 2;";
                }

                MySqlCommand command = new MySqlCommand(selectQuery, myConnect);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                dataAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();

                dataAdapter.Fill(dTable);

                BindingSource bSource = new BindingSource();

                bSource.DataSource = dTable;
                dataGridViewLesson.DataSource = bSource;
                dataAdapter.Update(dTable);

                //dataGridViewLesson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //dataGridViewLesson.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridViewLesson.Columns[0].HeaderText = "Часи занять";
                dataGridViewLesson.Columns[0].Width = 100;
                dataGridViewLesson.Columns[1].HeaderText = "Понеділок";
                dataGridViewLesson.Columns[1].Width = 250;
                dataGridViewLesson.Columns[2].HeaderText = "Вівторок";
                dataGridViewLesson.Columns[2].Width = 250;
                dataGridViewLesson.Columns[3].HeaderText = "Середа";
                dataGridViewLesson.Columns[3].Width = 250;
                dataGridViewLesson.Columns[4].HeaderText = "Четвер";
                dataGridViewLesson.Columns[4].Width = 250;
                dataGridViewLesson.Columns[5].HeaderText = "П'ятниця";
                dataGridViewLesson.Columns[5].Width = 250;

                dataGridViewLesson.Rows[1].Height = 40;


                myConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadMessage(string param)
        {
            string myConnection = "server=web113.default-host.net;Port=3306;uid=daleth_max;pwd=huE96m5VHbC3;database=daleth_warehouse";
            MySqlConnection myConnect = new MySqlConnection(myConnection);

            string selectQuery = "";

            try
            {
                myConnect.Open();

                if (param == "Перший")
                {
                    selectQuery =
                    "SELECT lesson_Monday FROM daleth_warehouse.info_system WHERE study_week = 3;";
                }
                if (param == "Другий")
                {
                    selectQuery =
                    "SELECT lesson_Monday FROM daleth_warehouse.info_system WHERE study_week = 4;";
                }

                MySqlCommand command = new MySqlCommand(selectQuery, myConnect);
                
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    MessageBox.Show(dr["lesson_Monday"].ToString());
                }

                myConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewLesson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void toolStripComboBox1Changed(object sender, EventArgs e)
        {
            loadTable(this.toolStripComboBox1.Text);
            //MessageBox.Show(this.toolStripComboBox1.Text);
        }

        private void оголошенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMessage(this.toolStripComboBox1.Text);
        }

        private void тижденьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
