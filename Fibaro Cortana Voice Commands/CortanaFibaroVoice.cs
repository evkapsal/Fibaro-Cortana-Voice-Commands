using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;
using Windows.System;
using System.Net;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;
using Windows.Devices.SerialCommunication;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Fibaro_Cortana_Voice_Commands

{
    
        
    
        class CortanaFibaroVoice
        {
            static XDocument _settingsDocument;

            /*
            This is the lookup of VCD CommandNames as defined in 
            CustomVoiceCommandDefinitios.xml to their corresponding actions
            */
            public readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{

            //Main Room Lights Control
            {"TurnOnMainLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var mainid = Getid("main");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{mainid.Result}/action/turnOn"));
                 await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffMainLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var mainid = Getid("main");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{mainid.Result}/action/turnOff"));
                 await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseMainLights", (Action)(async () => {
                var hname = GetHostName("home");
                var mainid = Getid("main");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{mainid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseMainLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var mainid = Getid("main");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{mainid.Result}/action/startLevelDecrease"));
                 await PostURI("home", uriToCall);
             }
            )},
            //Main Room Lights Preset
             {"MainLightsLow", (Action)(async () => {
                 var hname = GetHostName("home");
                 var mainid = Getid("main");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={mainid.Result}&name=setValue&arg1=25"));
                 await GetURI("home", uriToCall);
             }
            )},

             {"MainLightsMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var mainid = Getid("main");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={mainid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},

            //Dinning Room Lights Control
            {"TurnOnDinningLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var dinningid = Getid("dinning");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{dinningid.Result}/action/turnOn"));
                 await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffDinningLights", (Action)(async () => {
                var hname = GetHostName("home");
                var dinningid = Getid("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{dinningid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseDinningLights", (Action)(async () => {
                var hname = GetHostName("home");
                var dinningid = Getid("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{dinningid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseDinningLights", (Action)(async () => {
                var hname = GetHostName("home");
                var dinningid = Getid("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{dinningid.Result}/action/startLevelDecrease"));
                await PostURI("home", uriToCall);
             }
            )},

             //Dinning Room Lights Preset
             {"DinningLightsLow", (Action)(async () => {
                var hname = GetHostName("home");
                var dinningid = Getid("dinning");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={dinningid.Result}&name=setValue&arg1=25"));
                await GetURI("home", uriToCall);
             }
            )},

             {"DinningMainMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var dinningid = Getid("dinning");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={dinningid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},
            //Balcony Room Lights Control
            {"TurnOnBalconyLights", (Action)(async () => {
                var hname = GetHostName("home");
                var balconyid = Getid("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{balconyid.Result}/action/turnOn"));
                await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffBalconyLights", (Action)(async () => {
                var hname = GetHostName("home");
                var balconyid = Getid("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{balconyid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseBalconyLights", (Action)(async () => {
                var hname = GetHostName("home");
                var balconyid = Getid("balcony");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{balconyid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseBalconyLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var balconyid = Getid("balcony");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{balconyid.Result}/action/startLevelDecrease"));
                 await PostURI("home", uriToCall);
             }
            )},
             //Balcony Lights Preset
             {"BalconyLightsLow", (Action)(async () => {
                 var hname = GetHostName("home");
                 var balconyid = Getid("balcony");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={balconyid.Result}&name=setValue&arg1=25"));
                 await GetURI("home", uriToCall);
             }
            )},

             {"BalconyMainMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var balconyid = Getid("balcony");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={balconyid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},
            //Hallway Lights Control
            {"TurnOnHallLights", (Action)(async () => {
                var hname = GetHostName("home");
                var hallwayid = Getid("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{hallwayid.Result}/action/turnOn"));
                await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffHallLights", (Action)(async () => {
                var hname = GetHostName("home");
                var hallwayid = Getid("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{hallwayid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseHallLights", (Action)(async () => {
                var hname = GetHostName("home");
                var hallwayid = Getid("hallway");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{hallwayid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseHallLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var hallwayid = Getid("hallway");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{hallwayid.Result}/action/startLevelDecrease"));
                 await PostURI("home", uriToCall);
             }
            )},
             //Hall Lights Preset
             {"HallLightsLow", (Action)(async () => {
                 var hname = GetHostName("home");
                 var hallwayid = Getid("hallway");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={hallwayid.Result}&name=setValue&arg1=25"));
                 await GetURI("home", uriToCall);
             }
            )},

             {"HallLightsMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var hallwayid = Getid("hallway");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={hallwayid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},
             //Side Lights Control
            {"TurnOnSideLight", (Action)(async () => {
                var hname = GetHostName("home");
                var sidelightid = Getid("side");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{sidelightid.Result}/action/turnOn"));
                await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffSideLight", (Action)(async () => {
                var hname = GetHostName("home");
                var sidelightid = Getid("side");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{sidelightid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            //Visitor Bath Lights Control
            {"TurnOnVisitorLights", (Action)(async () => {
                var hname = GetHostName("home");
                var visitortid = Getid("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{visitortid.Result}/action/turnOn"));
                await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffVisitorLights", (Action)(async () => {
                var hname = GetHostName("home");
                var visitortid = Getid("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{visitortid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseVisitorLights", (Action)(async () => {
                var hname = GetHostName("home");
                var visitortid = Getid("visitor");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{visitortid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseVisitorLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var visitortid = Getid("visitor");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{visitortid.Result}/action/startLevelDecrease"));
                 await PostURI("home", uriToCall);
             }
            )},
              //Visitor Lights Preset
             {"VisitorLightsLow", (Action)(async () => {
                 var hname = GetHostName("home");
                 var visitortid = Getid("visitor");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={visitortid.Result}&name=setValue&arg1=25"));
                 await GetURI("home", uriToCall);
             }
            )},

             {"VisitorLightsMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var visitortid = Getid("visitor");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={visitortid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},
            //Bathroom Lights Control
            {"TurnOnBathroomLights", (Action)(async () => {
                var hname = GetHostName("home");
                var bathroomtid = Getid("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{bathroomtid.Result}/action/turnOn"));
                await PostURI("home", uriToCall);

             }
            )},

            {"TurnOffBathroomLights", (Action)(async () => {
                var hname = GetHostName("home");
                var bathroomtid = Getid("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{bathroomtid.Result}/action/turnOff"));
                await PostURI("home", uriToCall);
             }
            )},

            {"IncreaseBathroomLights", (Action)(async () => {
                var hname = GetHostName("home");
                var bathroomtid = Getid("bathroom");
                var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{bathroomtid.Result}/action/startLevelIncrease"));
                await PostURI("home", uriToCall);
             }
            )},

             {"DecreaseBathroomLights", (Action)(async () => {
                 var hname = GetHostName("home");
                 var bathroomtid = Getid("bathroom");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/devices/{bathroomtid.Result}/action/startLevelDecrease"));
                 await PostURI("home", uriToCall);
             }
            )},
               //Bathroom Lights Preset
             {"BathroomLightsLow", (Action)(async () => {
                 var hname = GetHostName("home");
                 var bathroomtid = Getid("bathroom");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={bathroomtid.Result}&name=setValue&arg1=25"));
                 await GetURI("home", uriToCall);
             }
            )},

             {"BathroomLightsMedium", (Action)(async () => {
                 var hname = GetHostName("home");
                 var bathroomtid = Getid("bathroom");
                 var uriToCall = new Uri(string.Format($"http://{hname.Result}/api/callAction?deviceID={bathroomtid.Result}&name=setValue&arg1=50"));
                 await GetURI("home", uriToCall);
             }
            )},
        };



            /*
            Register Custom Cortana Commands from VCD file
            */
            public static async void RegisterVCD()
            {
                StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(
                    @"CustomVoiceCommandDefinitions.xml");

                await VoiceCommandDefinitionManager
                    .InstallCommandDefinitionsFromStorageFileAsync(vcd);
            }

            public static void RunCommand(VoiceCommandActivatedEventArgs cmd)
            {
                SpeechRecognitionResult result = cmd.Result;
                string commandName = result.RulePath[0];
                vcdLookup[commandName].DynamicInvoke();
            }

            private static async Task<XDocument> GetSettings()
            {
                var uri = new System.Uri("ms-appx:///AppSettings.xml");
                var sampleFile = await StorageFile.GetFileFromApplicationUriAsync(uri);

                return XDocument.Load(sampleFile.Path);
            }


            private static async Task<string> GetHostAttribute(string key, string attribute)
            {
                if (_settingsDocument == null)
                {
                    _settingsDocument = await GetSettings();
                }

                var settings = _settingsDocument.Element("Settings").Elements("Host");

                var foundSetting = settings.FirstOrDefault(s => s.Attribute("key").Value == key);

                return (foundSetting != null) ? foundSetting.Attribute(attribute).Value : null;
            }




            private static async Task<string> GetHostName(string key)
            {
                string hostname = await GetHostAttribute(key, "name");

                return hostname;
            }

            private static async Task<string> Getid(string key)
            {
                string deviceid = await GetHostAttribute(key, "id");

                return deviceid;
            }

            private static async Task PostURI(string key, Uri url)
            {
                HttpClientHandler handler;
                handler = new HttpClientHandler();

                using (var client = new HttpClient(handler))
                {

                    var uri = url;
                    var username = await GetHostAttribute(key, "username");
                    var password = await GetHostAttribute(key, "password");
                    if (username != null && password != null)
                    {
                        handler.Credentials = new NetworkCredential(username, password);
                        var content = new StringContent("", Encoding.UTF8, "application/json");
                        await client.PostAsync(uri, content);
                    }
                }
            }
            private static async Task GetURI(string key, Uri url)
            {
                HttpClientHandler handler;
                handler = new HttpClientHandler();

                using (var client = new HttpClient(handler))
                {

                    var uri = url;
                    var username = await GetHostAttribute(key, "username");
                    var password = await GetHostAttribute(key, "password");
                    if (username != null && password != null)
                    {
                        handler.Credentials = new NetworkCredential(username, password);
                        await client.GetAsync(uri);
                    }
                }
            }
        
    }
    //{"OpenWebsite", (Action)(async () => {
    //
    //    await PostTo("home");
    //
    //     //Uri website = new Uri(
    //     //    hostname != null ? hostname : @"http://www.crclayton.com");
    //     //await Launcher.LaunchUriAsync(website);
    // }
    //)},


    //private static async Task PostTo(string key)
    //{
    //    HttpClientHandler handler;
    //    handler = new HttpClientHandler();

    //    using (var client = new HttpClient(handler))
    //    {


    //        //client.DefaultRequestHeaders.Accept.Add(
    //        //   new MediaTypeWithQualityHeaderValue("application/json"));

    //        var uri = await GetUri(key);
    //        var username = await GetHostAttribute(key, "username");
    //        var password = await GetHostAttribute(key, "password");
    //        if (username != null && password != null)
    //        {
    //            handler.Credentials = new NetworkCredential(username, password);
    //            //   client.DefaultRequestHeaders.Authorization =
    //            //      new AuthenticationHeaderValue("Basic",
    //            //      $"username={username},password={password}");

    //            var content = new StringContent("", Encoding.UTF8, "application/json");

    //            await client.PostAsync(uri, content);
    //        }
    //    }
    //}


    //private static async Task<Uri> GetUri(string key)
    //{
    //    var hostname = await GetHostAttribute(key, "name");

    //    Uri uriToCall = new Uri("http://www.google.com");

    //    if (hostname != null)
    //    {
    //        uriToCall = new Uri(string.Format($"http://{hostname}/api/devices/230/action/turnOff"));
    //    }

    //    return uriToCall;
    //}


    //{"OpenFile", (Action)(async () => {
    //    StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(@"Test.txt");
    //    await Launcher.LaunchFileAsync(file);
    //})},

    //{"CreateFile", (Action)(async () => {
    //    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    //    StorageFile sampleFile = await storageFolder.CreateFileAsync(
    //        @"NewFile.txt", CreationCollisionOption.ReplaceExisting);

    //    await storageFolder.GetFileAsync("NewFile.txt");
    //    await FileIO.WriteTextAsync(sampleFile, "This file was created by Cortana at " + DateTime.Now);

    //})},

    //{"SendSerialData", (Action)(async () => {
    //    string comPort = "COM3";
    //    string serialMessage = "String sent to the COM port";

    //    string selector = SerialDevice.GetDeviceSelector(comPort);
    //    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);

    //    if(devices.Count == 0)
    //    {
    //        MessageDialog popup = new MessageDialog($"No {comPort} device found.");
    //        await popup.ShowAsync();
    //        return;
    //    }

    //    DeviceInformation deviceInfo = devices[0];
    //    SerialDevice serialDevice = await SerialDevice.FromIdAsync(deviceInfo.Id);
    //    serialDevice.BaudRate = 9600;
    //    serialDevice.DataBits = 8;
    //    serialDevice.StopBits = SerialStopBitCount.Two;
    //    serialDevice.Parity = SerialParity.None;

    //    DataWriter dataWriter = new DataWriter(serialDevice.OutputStream);
    //    dataWriter.WriteString(serialMessage);
    //    await dataWriter.StoreAsync();
    //    dataWriter.DetachStream();
    //    dataWriter = null;
    //})},
}
