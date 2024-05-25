using System;
using System.Linq;
using NoteApp.App.Database.Data;

namespace NoteApp.Common.Appsetting
{
    public interface IAppsettingService
    {
        string GetValueByKey(string key);
    }

    public class AppsettingService : IAppsettingService 
    {
        private readonly noteappContext _dbContext;

        public AppsettingService(noteappContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetValueByKey(string key)
        {
            try
            {
                var appSetting = _dbContext.AppSettings.FirstOrDefault(s => s.Key == key);
                return appSetting?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving value for key '{key}': {ex.Message}");
                return null;
            }
        }
    }
}
