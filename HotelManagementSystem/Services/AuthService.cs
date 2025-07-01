using HotelManagementSystem.Models;
using System;
using System.Linq;

namespace HotelManagementSystem.Services
{
    public class AuthService
    {
        public static Staff CurrentUser { get; private set; }

        public static bool Login(string username, string password)
        {
            try
            {
                var context = Helper.GetContext();
                var user = context.Staff.FirstOrDefault(s => s.Username == username && s.Password == password);

                if (user != null)
                {
                    CurrentUser = user;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static string GetGreeting()
        {
            if (CurrentUser == null) return string.Empty;

            var hour = DateTime.Now.Hour;
            string greeting;

            if (hour >= 6 && hour < 12)
                greeting = "Доброе утро";
            else if (hour >= 12 && hour < 18)
                greeting = "Добрый день";
            else if (hour >= 18 && hour < 21)
                greeting = "Добрый вечер";
            else
                greeting = "Доброй ночи";

            return $"{greeting}, {CurrentUser.LastName} / {CurrentUser.Positions?.Name}";
        }
    }
}