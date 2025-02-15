using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Arithmetic
{
    public partial class Вход_2 : Form
    {
        public Вход_2()
        {
            InitializeComponent();
        }

        private void Вход_2_Load(object sender, EventArgs e)
        {
            // Загружаем данные пользователей для заполнения ComboBox
            var filePath = "registrationData.json";
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<RegistrationData>>(json);

                var classes = new HashSet<string>();
                var names = new HashSet<string>();

                foreach (var user in users)
                {
                    classes.Add(user.Class);
                    names.Add($"{user.Name} {user.Surname}");
                }

                comboBoxClass.Items.AddRange(classes.ToArray());
                comboBoxNameSurname.Items.AddRange(names.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedClass = comboBoxClass.SelectedItem?.ToString();
            var selectedNameSurname = comboBoxNameSurname.SelectedItem?.ToString();
            var password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(selectedClass) ||  string.IsNullOrEmpty(selectedNameSurname) || string.IsNullOrEmpty(password))
{
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filePath = "registrationData.json";
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<RegistrationData>>(json);

                var user = users.FirstOrDefault(u =>
                    u.Class == selectedClass &&
                    $"{u.Name} {u.Surname}" == selectedNameSurname &&
                    u.Password == password);


                if (user != null)
                {
                    MessageBox.Show("Авторизация успешна", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AuthInfo.SetAuthenticatedUser(user.Name, user.Surname, user.Class);
                    Главное_окно главное_Окно = new Главное_окно();
                    this.Hide();
                    главное_Окно.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильные данные для входа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Нет зарегистрированных пользователей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Вход вход = new Вход();
            this.Hide();
            вход.ShowDialog();
        }
    }
}
