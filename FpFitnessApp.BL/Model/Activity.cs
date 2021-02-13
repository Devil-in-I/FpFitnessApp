using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Кол-во калорий в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; }

        /// <summary>
        /// Создать новую активность.
        /// </summary>
        /// <param name="name">Название активности</param>
        /// <param name="caloriesPerMinute">Кол-во калорий в минуту.</param>
        public Activity(string name, double caloriesPerMinute)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название вида активности не может быть пустым", nameof(name));
            }
            if (caloriesPerMinute <= 0)
            {
                throw new ArgumentNullException("Количество калорий в минуту не может быть меньше или равно нулю", nameof(caloriesPerMinute));
            }
            #endregion
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
