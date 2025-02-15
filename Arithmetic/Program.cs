using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arithmetic.Models;


namespace Arithmetic
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == 1); // Загружаем пользователя с ID = 1 (пример)
                if (user != null)
                {
                    UserSession.Id = user.Id;
                    UserSession.FirstName = user.FirstName;
                    UserSession.LastName = user.LastName;
                    UserSession.UserClass = db.Classes
                        .Where(c => c.Id == user.ClassId)
                        .Select(c => c.Name)
                        .FirstOrDefault();
                }
            }

            Application.Run(new Главное_окно());
            //     Application.EnableVisualStyles();
            //     Application.SetCompatibleTextRenderingDefault(false);
            //     Application.Run(new Вход());
        }
    }
}
