using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FpFitnessApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            else
            {
                Name = name;
            }
        }
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        
    }
}
