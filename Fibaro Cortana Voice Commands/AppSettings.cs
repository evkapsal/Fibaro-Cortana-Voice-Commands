using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibaro_Cortana_Voice_Commands
{
    public class AppSettings
    {
        private AppSettings() { }

        public ConnectionInfo Connection { get; private set; } = new ConnectionInfo();
        public IDictionary<string, string> Sensors { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string GetSensorId(string sensorName)
        {
            if (Sensors.TryGetValue(sensorName, out var value))
                return value;

            return null;
        }

        public void SetSensorId(string sensorName, string sensorId)
        {
            Sensors[sensorName] = sensorId;
        }

        public void Save()
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
            settings.Values["Connection.UserName"] = Connection.UserName;
            settings.Values["Connection.Password"] = Connection.Password;
            settings.Values["Connection.HostName"] = Connection.HostName;      
         
            var sensorValues = new Windows.Storage.ApplicationDataCompositeValue();
            foreach (var item in Sensors)
            {
                sensorValues[item.Key] = item.Value;
            }

            settings.Values["Sensors"] = sensorValues;
        }


        public static AppSettings Load()
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;

            var appSettings = new AppSettings();
            appSettings.Connection.UserName = settings.Values["Connection.UserName"] as string;
            appSettings.Connection.Password = settings.Values["Connection.Password"] as string;
            appSettings.Connection.HostName = settings.Values["Connection.HostName"] as string;

            var sensorValues = settings.Values["Sensors"] as Windows.Storage.ApplicationDataCompositeValue;
            if (sensorValues == null)
                return appSettings;

            foreach (var item in sensorValues)
            {
                appSettings.Sensors[item.Key] = $"{item.Value}";
            }           

            return appSettings;
        }
    }

    public class ConnectionInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
    }
}
