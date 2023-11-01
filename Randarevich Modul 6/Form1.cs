using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Randarevich_Modul_6
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Учебная практика по программированию\Рандаревич Отчет по практике Модуль 6\Books.accdb";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Books where Название книги '%" + textBox1.Text + "%'";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update Books set Статус аренды='Арендована' where ID=" + dataGridView1.SelectedCells[0].Value.ToString(); // замените "Статус аренды" и "Арендована" на соответствующие значения в вашей базе данных
                command.CommandText = query;
                command.ExecuteNonQuery();

                MessageBox.Show("Статус аренды обновлен!");

                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Books"; 
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
    }
}
