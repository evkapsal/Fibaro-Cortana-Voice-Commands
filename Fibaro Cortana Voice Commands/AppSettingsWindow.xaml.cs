using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fibaro_Cortana_Voice_Commands
{
    public sealed partial class AppSettingsWindow : UserControl
    {
        public AppSettingsWindow()
        {
            this.InitializeComponent();

            this.InitializeComponent();
            this.InitSettingsPage();
        }

        private AppSettings Settings = CortanaFibaroVoice.Settings;


        private void InitSettingsPage()
        {
            IPAddress.Text = Settings.Connection.HostName ?? string.Empty;
            Username.Text = Settings.Connection.UserName ?? string.Empty;
            PasswordTextbox.Text = Settings.Connection.Password ?? string.Empty;
            Mainid.Text = Settings.GetSensorId("main") ?? string.Empty;
            DinningID.Text = Settings.GetSensorId("dinning") ?? string.Empty;
            Balconyid.Text = Settings.GetSensorId("balcony") ?? string.Empty;
            Visitorid.Text = Settings.GetSensorId("visitor") ?? string.Empty;
            BathroomID.Text = Settings.GetSensorId("bathroom") ?? string.Empty;
            Hallwayid.Text = Settings.GetSensorId("hallway") ?? string.Empty;
            Sideid.Text = Settings.GetSensorId("side") ?? string.Empty;
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            (this.Parent as Popup).IsOpen = false;
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Connection.HostName = IPAddress.Text;
            Settings.Connection.UserName = Username.Text;
            Settings.Connection.Password = PasswordTextbox.Text;
            Settings.SetSensorId("main", Mainid.Text);
            Settings.SetSensorId("dinning", DinningID.Text);
            Settings.SetSensorId("balcony", Balconyid.Text);
            Settings.SetSensorId("visitor", Visitorid.Text);
            Settings.SetSensorId("bathroom", BathroomID.Text);
            Settings.SetSensorId("hallway", Hallwayid.Text);
            Settings.SetSensorId("side", Sideid.Text);
            Settings.Save();
        }

    }
}
