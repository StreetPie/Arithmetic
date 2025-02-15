using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Delered
    }
    public partial class учитель : Form
    {
        ApplicationDbContext con1;
        int selectedRow;
        public учитель()
        {
            InitializeComponent();
        }

        private void учитель_Load(object sender, EventArgs e)
        {
            con1 = new ApplicationDbContext();
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "Имя");
            dataGridView1.Columns.Add("familia", "Фамилия");
            dataGridView1.Columns.Add("class", "Класс_Группа");
            dataGridView1.Columns.Add("data", "Дата_рождения");
            dataGridView1.Columns.Add("login", "login");
            dataGridView1.Columns.Add("password", "password");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from Пользователи";
            SqlCommand command = new SqlCommand(queryString, con1.GetCon());
            con1.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Пользователи where concat(ID, Имя, Фамилия, Класс_Группа, Дата_рождения, login, password) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, con1.GetCon());
            con1.OpenCon();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
