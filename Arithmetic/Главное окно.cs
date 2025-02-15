using System.Windows.Forms;
using System;

namespace Arithmetic
{
    public partial class Главное_окно : Form
    {

        public Главное_окно()
        {
            InitializeComponent();
            ShowCurrentDate();
            labelUserName.Text = $"Пользователь: {AuthInfo.UserName} {AuthInfo.UserSurname} {AuthInfo.UserClass}";
        }
        private void ShowCurrentDate()
        {
            // Устанавливаем текущую дату в текстовое поле метки
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void Главное_окно_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Задачи задачи = new Задачи();
            this.Hide();
            задачи.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            прогресс прогресс = new прогресс();
            this.Hide();
            прогресс.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Вход вход = new Вход();
            this.Hide();
            вход.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
