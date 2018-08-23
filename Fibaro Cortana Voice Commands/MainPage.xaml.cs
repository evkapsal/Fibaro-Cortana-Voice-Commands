using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Fibaro_Cortana_Voice_Commands
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
      
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1000, 1000);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        private void Button_Click(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnMainLights"].DynamicInvoke();
        }

        private void LightsOffClick(object sender, RoutedEventArgs e)
        {
            
            CortanaFibaroVoice.vcdLookup["TurnOffMainLights"].DynamicInvoke();
        }

        private void dimhigh(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseMainLights"].DynamicInvoke();
        }

        private void dimlow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseMainLights"].DynamicInvoke();
        }

        private void mainlow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["MainLightsLow"].DynamicInvoke();
        }

        private void mainmed(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["MainLightsMedium"].DynamicInvoke();
        }

        private void dinon(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnDinningLights"].DynamicInvoke();
        }

        private void dinoff(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffDinningLights"].DynamicInvoke();
        }

        private void dinhigh(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseDinningLights"].DynamicInvoke();
        }

        private void dinlow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseDinningLights"].DynamicInvoke();
        }

        private void dinninglow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DinningLightsLow"].DynamicInvoke();
        }

        private void dinningmed(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DinningMainMedium"].DynamicInvoke();
        }

        private void balcon(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnBalconyLights"].DynamicInvoke();
        }

        private void balcoff(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffBalconyLights"].DynamicInvoke();
        }

        private void balhigh(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseBalconyLights"].DynamicInvoke();
        }

        private void balow(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseBalconyLights"].DynamicInvoke();
        }

        private void balconylow(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["BalconyLightsLow"].DynamicInvoke();
        }

        private void balconymedium(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["BalconyMainMedium"].DynamicInvoke();
        }

        private void hallon(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnHallLights"].DynamicInvoke();
        }

        private void halloff(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffHallLights"].DynamicInvoke();
        }

        private void halhigh(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseHallLights"].DynamicInvoke();
        }

        private void hallow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseHallLights"].DynamicInvoke();
        }

        private void hallwaylow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["HallLightsLow"].DynamicInvoke();
        }

        private void hallwaymedium(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["HallLightsMedium"].DynamicInvoke();
        }

        private void sideon(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnSideLight"].DynamicInvoke();
        }

        private void sideoff(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffSideLight"].DynamicInvoke();
        }

        private void vison(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnVisitorLights"].DynamicInvoke();
        }

        private void visoff(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffVisitorLights"].DynamicInvoke();
        }

        private void vishigh(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseVisitorLights"].DynamicInvoke();
        }

        private void vislow(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseVisitorLights"].DynamicInvoke();
        }

        private void visitorlor(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["VisitorLightsLow"].DynamicInvoke();
        }

        private void visitormedium(object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["VisitorLightsMedium"].DynamicInvoke();
        }

        private void bathon(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOnBathroomLights"].DynamicInvoke();
        }

        private void bathoff(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["TurnOffBathroomLights"].DynamicInvoke();
        }

        private void bathihg(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["IncreaseBathroomLights"].DynamicInvoke();
        }

        private void bathlow(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["DecreaseBathroomLights"].DynamicInvoke();
        }

        private void bathroomlow(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["BathroomLightsLow"].DynamicInvoke();
        }

        private void bathroomedium(System.Object sender, RoutedEventArgs e)
        {
            CortanaFibaroVoice.vcdLookup["BathroomLightsMedium"].DynamicInvoke();
        }
    }
}
