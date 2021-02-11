using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Еда.
    /// </summary>
    public class  Food
    {
        #region Свойства
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; }


        /// <summary>
        /// Калории на грамм.
        /// </summary>
        private double CaloriesOneGram { get { return Calories / 100.0; } }

        /// <summary>
        /// Белки на грамм.
        /// </summary>
        private double ProteinsOneGram { get { return Proteins / 100.0; } }

        /// <summary>
        /// Жиры на грамм.
        /// </summary>
        private double FatsOneGram { get { return Fats / 100.0; } }

        /// <summary>
        /// Углеводы на грамм.
        /// </summary>
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }
        #endregion

        public Food(string name) : this(name, 0, 0, 0, 0){ }

        /// <summary>
        /// Добавить/создать новый продукт.
        /// </summary>
        /// <param name="name">Название продукта.</param>
        /// <param name="proteins">Белки.</param>
        /// <param name="fats">Жиры.</param>
        /// <param name="carbohydrates">Углеводы.</param>
        /// <param name="calories">Калории.</param>
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя продукта не может быть пустым", nameof(name));
            }
            if (proteins <= 0)
            {
                throw new ArgumentNullException("Количество белков не может быть равно 0", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentNullException("Количество жиров не может быть равно 0", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentNullException("Количество углеводов не может быть равно 0", nameof(carbohydrates));
            }

            if (calories <= 0)
            {
                throw new ArgumentNullException("Количество калорий не может быть равно 0", nameof(calories));
            }
            #endregion
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
