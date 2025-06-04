using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DiplomProg.Models;
using Serilog;

namespace DiplomProg.Services;

public class FileStorageService : IDataService
{
    private readonly string _storagePath;

    public FileStorageService()
    {
        _storagePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ServiceCenterStorage");
        Directory.CreateDirectory(_storagePath);
    }

    public List<T> LoadData<T>(string fileName)
    {
        try
        {
            var path = Path.Combine(_storagePath, fileName);
            if (!File.Exists(path)) return new List<T>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка загрузки данных из {FileName}", fileName);
            return new List<T>();
        }
    }

    public void SaveData<T>(IEnumerable<T> items, string fileName)
    {
        try
        {
            var path = Path.Combine(_storagePath, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка сохранения данных в {FileName}", fileName);
        }
    }

    public void LogAction(string action, string details)
    {
        try
        {
            var logEntry = new RepairHistory
            {
                Action = action,
                Details = details,
                Timestamp = DateTime.Now
            };

            var path = Path.Combine(_storagePath, "history.json");
            var history = LoadData<RepairHistory>("history.json");
            history.Add(logEntry);
            SaveData(history, "history.json");

            Log.Information("Действие: {Action}, Детали: {Details}", action, details);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка логирования действия");
        }
    }
}