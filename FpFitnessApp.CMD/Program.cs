using FpFitnessApp.BL.Controller;
using FpFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var culture = CultureInfo.CreateSpecificCulture("ru-RU");
            //var resourceManager = new ResourceManager("FpFitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

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
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t {item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var  item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t {item.Activity} c {item.Start.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");           

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value}(dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
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
