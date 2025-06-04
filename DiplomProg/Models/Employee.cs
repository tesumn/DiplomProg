using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomProg.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ФИО обязательно")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Должность обязательна")]
        public string Position { get; set; } = "";

        [Phone(ErrorMessage = "Неверный формат телефона")]
        public string Phone { get; set; } = "";
    }
}