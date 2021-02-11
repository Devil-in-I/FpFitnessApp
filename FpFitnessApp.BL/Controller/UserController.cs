﻿using FpFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; } 
        
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public UserController(string userName)
        {
            
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();           
        }

        /// <summary>
        /// Сохранить новый список пользователей.
        /// </summary>
        /// <param name="genderName">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="Weight">Вес.</param>
        /// <param name="Height">Рост.</param>
        public void SetNewUserData(string genderName, DateTime birthDate, double Weight = 1, double Height = 1)
        {
            //TODO: Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = Weight;
            CurrentUser.Height = Height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }      
    }
}
