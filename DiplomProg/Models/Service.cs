using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomProg.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название услуги обязательно")]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        [Range(0, 100000, ErrorMessage = "Цена должна быть от 0 до 100000")]
        public decimal Price { get; set; }
    }
}