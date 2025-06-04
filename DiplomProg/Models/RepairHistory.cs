using System;

namespace DiplomProg.Models;

public class RepairHistory
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Action { get; set; } = ""; // "Создан", "Обновлен", "Завершен"
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string Details { get; set; } = "";
}