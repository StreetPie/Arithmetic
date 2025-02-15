using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Вход : Form
    {
        public Вход()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Вход_2 вход_2 = new Вход_2();
            this.Hide();
            вход_2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            регистрация регистрация = new регистрация();
            this.Hide();
            регистрация.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Завершение работы приложения
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
