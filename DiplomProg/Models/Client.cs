using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomProg.Models;

public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "ФИО обязательно")]
    [StringLength(100, ErrorMessage = "ФИО не должно превышать 100 символов")]
    public string FullName { get; set; } = "";

    [Phone(ErrorMessage = "Неверный формат телефона")]
    public string Phone { get; set; } = "";

    [EmailAddress(ErrorMessage = "Неверный формат email")]
    public string Email { get; set; } = "";

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}