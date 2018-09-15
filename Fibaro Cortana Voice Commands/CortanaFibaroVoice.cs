using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;
using System.Net;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;
using Windows.System;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Text;
using Windows.Devices.SerialCommunication;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Diagnostics;

namespace Fibaro_Cortana_Voice_Commands
{
    class CortanaFibaroVoice
    {
        public static readonly AppSettings Settings = AppSettings.Load();

       // static XDocument _settingsDocument;

        /*
        This is the lookup of VCD CommandNames as defined in 
        CustomVoiceCommandDefinitios.xml to their corresponding actions
        */
        public readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{

            //Main Room Lights Control
            {"TurnOnMainLights", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var mainid = Settings.GetSensorId("main");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{mainid}/action/turnOn"));
                 await PostURI(uriToCall);

             }
            )},

            {"TurnOffMainLights", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var mainid = Settings.GetSensorId("main");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{mainid}/action/turnOff"));
                 await PostURI(uriToCall);
             }
            )},

            {"IncreaseMainLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var mainid = Settings.GetSensorId("main");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{mainid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseMainLights", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var mainid = Settings.GetSensorId("main");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{mainid}/action/startLevelDecrease"));
                 await PostURI(uriToCall);
             }
            )},
            //Main Room Lights Preset
             {"MainLightsLow", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var mainid = Settings.GetSensorId("main");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={mainid}&name=setValue&arg1=25"));
                 await GetURI(uriToCall);
             }
            )},

             {"MainLightsMedium", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var mainid = Settings.GetSensorId("main");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={mainid}&name=setValue&arg1=50"));
                 await GetURI(uriToCall);
             }
            )},

            //Dinning Room Lights Control
            {"TurnOnDinningLights", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var dinningid = Settings.GetSensorId("dinning");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{dinningid}/action/turnOn"));
                 await PostURI(uriToCall);

             }
            )},

            {"TurnOffDinningLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var dinningid = Settings.GetSensorId("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{dinningid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            {"IncreaseDinningLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var dinningid = Settings.GetSensorId("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{dinningid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseDinningLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var dinningid = Settings.GetSensorId("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{dinningid}/action/startLevelDecrease"));
                await PostURI(uriToCall);
             }
            )},

             //Dinning Room Lights Preset
             {"DinningLightsLow", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var dinningid = Settings.GetSensorId("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={dinningid}&name=setValue&arg1=25"));
                await GetURI(uriToCall);
             }
            )},

             {"DinningLightsMedium", (Action)(async () => {
                 var hname = Settings.Connection.HostName;
                 var dinningid = Settings.GetSensorId("dinning");
                 var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={dinningid}&name=setValue&arg1=50"));
                 await GetURI(uriToCall);
             }
            )},
            //Balcony Room Lights Control
            {"TurnOnBalconyLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{balconyid}/action/turnOn"));
                await PostURI(uriToCall);

             }
            )},

            {"TurnOffBalconyLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{balconyid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            {"IncreaseBalconyLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{balconyid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseBalconyLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{balconyid}/action/startLevelDecrease"));
                await PostURI(uriToCall);
             }
            )},
             //Balcony Lights Preset
             {"BalconyLightsLow", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={balconyid}&name=setValue&arg1=25"));
                await GetURI(uriToCall);
             }
            )},

             {"BalconyMainMedium", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var balconyid = Settings.GetSensorId("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={balconyid}&name=setValue&arg1=50"));
                await GetURI(uriToCall);
             }
            )},
            //Hallway Lights Control
            {"TurnOnHallLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{hallwayid}/action/turnOn"));
                await PostURI(uriToCall);

             }
            )},

            {"TurnOffHallLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{hallwayid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            {"IncreaseHallLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{hallwayid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseHallLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{hallwayid}/action/startLevelDecrease"));
                await PostURI(uriToCall);
             }
            )},
             //Hall Lights Preset
             {"HallLightsLow", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={hallwayid}&name=setValue&arg1=25"));
                await GetURI(uriToCall);
             }
            )},

             {"HallLightsMedium", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var hallwayid = Settings.GetSensorId("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={hallwayid}&name=setValue&arg1=50"));
                await GetURI(uriToCall);
             }
            )},
             //Side Lights Control
            {"TurnOnSideLight", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var sidelightid =  Settings.GetSensorId("side");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{sidelightid}/action/turnOn"));
                await PostURI(uriToCall);

             }
            )},

            {"TurnOffSideLight", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var sidelightid =  Settings.GetSensorId("side");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{sidelightid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            //Visitor Bath Lights Control
            {"TurnOnVisitorLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{visitortid}/action/turnOn"));
                await PostURI(uriToCall);

             }
            )},

            {"TurnOffVisitorLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{visitortid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            {"IncreaseVisitorLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{visitortid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseVisitorLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{visitortid}/action/startLevelDecrease"));
                await PostURI(uriToCall);
             }
            )},
              //Visitor Lights Preset
             {"VisitorLightsLow", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={visitortid}&name=setValue&arg1=25"));
                await GetURI(uriToCall);
             }
            )},

             {"VisitorLightsMedium", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var visitortid = Settings.GetSensorId("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={visitortid}&name=setValue&arg1=50"));
                await GetURI(uriToCall);
             }
            )},
            //Bathroom Lights Control
            {"TurnOnBathroomLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{bathroomtid}/action/turnOn"));
                await PostURI(uriToCall);

             }
            )},

            {"TurnOffBathroomLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{bathroomtid}/action/turnOff"));
                await PostURI(uriToCall);
             }
            )},

            {"IncreaseBathroomLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{bathroomtid}/action/startLevelIncrease"));
                await PostURI(uriToCall);
             }
            )},

             {"DecreaseBathroomLights", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/devices/{bathroomtid}/action/startLevelDecrease"));
                await PostURI(uriToCall);
             }
            )},
               //Bathroom Lights Preset
             {"BathroomLightsLow", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={bathroomtid}&name=setValue&arg1=25"));
                await GetURI(uriToCall);
             }
            )},

             {"BathroomLightsMedium", (Action)(async () => {
                var hname = Settings.Connection.HostName;
                var bathroomtid = Settings.GetSensorId("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname}/api/callAction?deviceID={bathroomtid}&name=setValue&arg1=50"));
                await GetURI(uriToCall);
             }
            )},
        };



        /*
        Register Custom Cortana Commands from VCD file
        */
        public static async void RegisterVCD()
        {
            try
            {
                StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(@"CustomVoiceCommandDefinitions.xml");
                await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcd);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("There was an error registering the Voice Command Definitions", ex);
            }

        }

        public static void RunCommand(VoiceCommandActivatedEventArgs cmd)
        {
            SpeechRecognitionResult result = cmd.Result;
            string commandName = result.RulePath[0];
            vcdLookup[commandName].DynamicInvoke();
        }




        private static async Task PostURI(Uri url)
        {
            HttpClientHandler handler;
            handler = new HttpClientHandler();

            using (var client = new HttpClient(handler))
            {

                var uri = url;
                var username = Settings.Connection.UserName;
                var password = Settings.Connection.Password;
                if (username != null && password != null)
                {
                    handler.Credentials = new NetworkCredential(username, password);                   
                    var response = await client.PostAsync(uri, null);
                  
                }
            }
        }
        private static async Task GetURI(Uri url)
        {
            HttpClientHandler handler;
            handler = new HttpClientHandler();

            using (var client = new HttpClient(handler))
            {

                var uri = url;
                var username = Settings.Connection.UserName;
                var password = Settings.Connection.Password;
                if (username != null && password != null)
                {
                    handler.Credentials = new NetworkCredential(username, password);
                    await client.GetAsync(uri);
                }
            }
        }

    }

}
