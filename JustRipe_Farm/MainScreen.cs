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
using System.Configuration;

namespace JustRipe_Farm
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Hide();
            stocksPanel.Hide();
            machinesPanel.Hide();
            labourerPanel.Show();
            shopPanel.Hide();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Hide();
            stocksPanel.Hide();
            machinesPanel.Hide();
            labourerPanel.Show();
            shopPanel.Hide();
        }

        private void newJobButton_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Show();
            stocksPanel.Hide();
            machinesPanel.Hide();
            labourerPanel.Hide();
            shopPanel.Hide();
        }

        private void stocksButton_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Hide();
            stocksPanel.Show();
            machinesPanel.Hide();
            labourerPanel.Hide();
            shopPanel.Hide();
        }

        private void labourerButton_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Show();
            newJobPanel.Hide();
            stocksPanel.Hide();
            machinesPanel.Hide();
            labourerPanel.Hide();
            shopPanel.Hide();
        }

        private void machinesButton_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Hide();
            stocksPanel.Hide();
            machinesPanel.Show();
            labourerPanel.Hide();
            shopPanel.Hide();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            mainScrnPanel.Hide();
            newJobPanel.Hide();
            stocksPanel.Hide();
            machinesPanel.Hide();
            labourerPanel.Hide();
            shopPanel.Show();
        }

        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Labourer labr = new Labourer();
            labr.Name = "Adam";
            labr.Age = 30;
            labr.Gender = "male";

            LabourerHandler labHnd = new LabourerHandler();
            int recordCnt = labHnd.addNewLabourer(dbConn.getConn(), labr);
            MessageBox.Show(recordCnt + " record has been inserted !!");
        }

        private void clrButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            genderComboBox.Text = "";
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user=dbcli;database=demojustripedb;port=3306;password=dbcli123");
        private void AddButton_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO labourer(name, age, gender) VALUES('"+nameTextBox.Text+ "','" + ageTextBox.Text + "','" + genderComboBox.Text + "')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Record has been inserted");
                }
                else 
                {
                    MessageBox.Show("Record has not been inserted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void mainScrnPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;user=dbcli;database=demojustripedb;port=3306;password=dbcli123");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM labourer", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "labourer");
                dataGridView1.DataSource = ds.Tables["labourer"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
