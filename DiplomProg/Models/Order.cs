using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomProg.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Дата заказа обязательна")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Статус обязателен")]
        public string Status { get; set; } = "В обработке";

        public string DeviceType { get; set; } = "Компьютер";
        public string ProblemDescription { get; set; } = string.Empty;

        // Навигационные свойства
        public Client? Client { get; set; }
        public Employee? Employee { get; set; }
        public Service? Service { get; set; }

        // Статусы для ComboBox
        public static List<string> Statuses { get; } = new List<string>
        {
            "В обработке",
            "В работе",
            "Завершен",
            "Отменен"
        };
    }
}