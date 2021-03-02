using System.Collections.Generic;

namespace Homework_01
{
    public class Requests
    {
        private Dictionary<string, string> _requestsList;

        public Requests()
        {
            _requestsList = new Dictionary<string, string>
            {
                ["Вся информация"] = "Select * FROM Info_Vegetables_fruits",
                ["Наименования"] = "Select Name FROM Info_Vegetables_fruits",
                ["Цвет"] = "Select Color FROM Info_Vegetables_fruits Group by Color",
                ["Максимальная калорийность"] = "Select MAX(Caloric) FROM Info_Vegetables_fruits",
                ["Минимальная калорийность"] = "Select MIN(Caloric) FROM Info_Vegetables_fruits",
                ["Средняя калорийность"] = "Select AVG(Caloric) FROM Info_Vegetables_fruits",
                ["Количество овощей"] = "Select COUNT(Name) FROM Info_Vegetables_fruits WHERE Type = 'vegetable'",
                ["Количество фруктов"] = "Select COUNT(Name) FROM Info_Vegetables_fruits WHERE Type = 'fruit'",
                ["Количество фруктов и овощей заданного цвета"] = "Select COUNT(Name) FROM Info_Vegetables_fruits WHERE Color = '{0}'",
                ["Количество фруктов и овощей каждого цвета"] = "SELECT COUNT(color), Color FROM Info_Vegetables_fruits GROUP BY Color",
                ["Овощи и фрукты с калорийностью ниже указанной"] = "SELECT Name, Caloric FROM Info_Vegetables_fruits Where Caloric < {0}",
                ["Овощи и фрукты с калорийностью выше указанной"] = "SELECT Name, Caloric FROM Info_Vegetables_fruits Where Caloric > {0}",
                ["Овощи и фрукты с калорийностью в указанном диапазоне"] = "SELECT Name, Caloric FROM Info_Vegetables_fruits Where Caloric > {0} AND Caloric < {1}",
                ["Овощи и фрукты, у которых цвет желтый или красный"] = "SELECT Name, Color FROM Info_Vegetables_fruits Where Color = 'yellow'; SELECT Name, Color FROM Info_Vegetables_fruits Where Color = 'red'"
            };
        }

        public Dictionary<string, string> GetRequestsList { get { return _requestsList; } }

    }
}
