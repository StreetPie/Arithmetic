using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Arithmetic
{
    public partial class регистрация : Form
    {
        ApplicationDbContext con1;

        public регистрация()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var surname = textBox1_surname.Text;
            var name = textBox2_name.Text;
            var klass = textBox3_klass.Text;
            var password = textBox5_password.Text;
            var confirmpassword = textBox6_confirmpassword.Text;
            var birthday = maskedTextBox1_birthday.Text;

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(klass) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmpassword) || string.IsNullOrEmpty(birthday))
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmpassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем объект для сохранения данных о регистрации
            var registrationData = new RegistrationData
            {
                Surname = surname,
                Name = name,
                Class = klass,
                Password = password,
                Birthday = birthday
            };

            // Путь к файлу для сохранения данных о регистрации
            var filePath = "registrationData.json";
            List<RegistrationData> registrationList = new List<RegistrationData>();

            // Если файл существует, загружаем существующие данные
            if (File.Exists(filePath))
            {
                var existingData = File.ReadAllText(filePath);
                registrationList = JsonConvert.DeserializeObject<List<RegistrationData>>(existingData);
            }

            // Добавляем новые данные в список
            registrationList.Add(registrationData);

            try
            {
                // Преобразуем список в JSON массив и сохраняем в файл
                var json = JsonConvert.SerializeObject(registrationList);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Регистрация завершена успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Главное_окно главное_Окно = new Главное_окно();
                this.Hide();
                главное_Окно.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Вход вход = new Вход();
            this.Hide();
            вход.ShowDialog();
        }

        private void регистрация_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
