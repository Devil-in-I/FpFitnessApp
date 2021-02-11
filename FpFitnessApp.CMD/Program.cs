using FpFitnessApp.BL.Controller;
using FpFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение FpFitnessApp приветствует вас.");

            Console.WriteLine("Введите имя пользователя");

            var name = Console.ReadLine();
            bool check = true;
            while (check)
            {
                if (name.Length <= 1 || name.Length >= 50)
                {
                    Console.WriteLine("Что-то не так. Введите имя пользователя еще раз");
                    name = Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            }

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.weight);
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();


            var cal = ParseDouble("Калорийность");
            var prot = ParseDouble("белки");
            var fat = ParseDouble("жиры");
            var carbs = ParseDouble("Углеводы");


            var weight = ParseDouble("вес порции");
            var product = new Food(food, prot, fat, carbs, cal);
            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля <<{name}>>");
                }
            }
        }
    }
}
