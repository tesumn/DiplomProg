using System.Collections.Generic;

namespace DiplomProg.Services;

public interface IDataService
{
    List<T> LoadData<T>(string fileName);
    void SaveData<T>(IEnumerable<T> items, string fileName);
    void LogAction(string action, string details);
}
