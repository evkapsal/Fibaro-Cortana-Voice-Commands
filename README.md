# Fibaro Cortana Voice Commands

Cortana voice commands for Fibaro HCL/HC2, is a Universal Windows Application based on  [Clayton](https://github.com/crclayton/custom-cortana-commands-template) - template for cortana commands on github, and gives you the ability to send voice commands in your Fibaro device through Cortana. In this release the following lights control are supported:
 
* Light on/off 
* Lights low/medium - 20%  & 50%
* Lights Dim High/Low  

(Rest API integration with Fibaro HCL/HC2)
Voice Commands 1.0.18 Release

## Getting Started

Following the instructions below you can install Fibaro Voice Cortana Commands in you Windows 10 PC and control your home lights.

### Prerequisites

Before Application installation you have to install the application certificate in your computer to the trusted root certification authority.

* Enable Windows App [Sideload](https://www.windowscentral.com/how-enable-windows-10-sideload-apps-outside-store) in your Windows 10 Machine.
* Download [Certificate](https://github.com/evkapsal/Fibaro-Cortana-Voice-Commands/tree/master/Fibaro%20Cortana%20Voice%20Commands/AppPackages/Fibaro%20Cortana%20Voice%20Commands_1.0.18.0_Test) - Fibaro Cortana Voice Commands_1.0.18.0_x64.cer, from github repository.
**Example of Windows Certificate mmc** [here](https://technet.microsoft.com/en-us/library/dd632619.aspx).
* On your windows machine -> **Start** -> **Run** -> **mmc**
* **File** -> **Add Remove Snap In** -> and select **Certificates** -> **Add** -> **Computer Account** -> **Local Computer** -> **Finish** -> **OK**
* Expand **Trusted Root Certification Authority** -> **Certificates**
* Right Click in **Certificates** -> **All tasks** -> **Import**
* Got through the wizard and select the **Fibaro Cortana Voice Commands_1.0.16.0_x64.cer** 
* You don't have to enter any password just select import and finish the wizard.

### Installing

Download or clone the release folder of UWP from github [Repository](https://github.com/evkapsal/Fibaro-Cortana-Voice-Commands/tree/master/Fibaro%20Cortana%20Voice%20Commands/AppPackages/Fibaro%20Cortana%20Voice%20Commands_1.0.18.0_Test).

Double click on the **Fibaro Cortana Voice Commands_1.0.16.0_x64.appxbundle** file and install application. 

![](https://pgp6oq.am.files.1drv.com/y4mFLJg89WIc6RFTCoMa6VlrbRTIF56Cckok4K3XluBk881UepCfB1PNNY3e6FNQ2DaE2ClXMWdXG3wrhLZY_w-bS5Xlfp0562dEeOCZz_gGgknUAb96q_1i6xUlxYB57FFWJFFMGND4CPnpikWvhfLK-ilPVMtqeIS1hfdJl4wyI8PJS5pEL0ABv9kZfGI9D9MC4s2wCcNRaOmN5FDKz-GsA?width=660&height=401&cropmode=none)


**Application Configuration**

After installing the Application you have to configure the following:

* Fibaro IP Address.
* Fibaro Username.
* Fibaro Password.
* Light ID's.

For that click on settings and fulfill the connection settings and light id's.

![](https://194hra.am.files.1drv.com/y4mgO3dT_wFix_1uhlcY3EsG1PmUDs8T0OC25JzYBbZRCnOAgjVWCwdj-UH6--yWSwot5lVbpF18rwJRgIdu9kj6Ugs64pKO82zIr3GluCYkxinB1Eukq93HFgtbmSUrwTcJbkSr0-Vo-OlgcUrewXdxHeKEldCSa0lReno0jrtS1xQ42wvlSksrmK3Wxmb_2yeGcOd3CZ11T0u7h5eLHTAQQ?width=982&height=1024&cropmode=none)

Click on **Save** and then **Back** to your application.
You can test the connectivity and application directly through the buttons to see if everything is ok.


## Running the Voice Commands

Cortana now is able to here you and execute the light commands. The key phrase that you have to remember is **room**.

### Voice Commands examples:

In case you have the **Hey Cortana** enabled you can start by saying:

```
Hey cortana...
```

#### Voice Commands

**Main room Commands**

```
room main light on
```

```
room main light off
```

```
room main dim low
```

```
room main dim high
```

```
room main low
```

```
room main medium
```

**Dinning room Commands**

```
room dinning light on
```

```
room dinning light off
```

```
room dinning dim low
```

```
room dinning dim high
```

```
room dinning low
```

```
room dinning medium
```

**Hallway room Commands**

```
room hallway light on
```

```
room hallway light off
```

```
room hallway dim low
```

```
room hallway dim high
```

```
room hallway low
```

```
room hallway medium
```

**Balcony room Commands**

```
room balcony light on
```

```
room balcony light off
```

```
room balcony dim low
```

```
room balcony dim high
```

```
room balcony low
```

```
room balcony medium
```

**Visitor room Commands**

```
room visitor light on
```

```
room visitor light off
```

```
room visitor dim low
```

```
room visitor dim high
```

```
room visitor low
```

```
room visitor medium
```

**Bathroom room Commands**

```
room bathroom light on
```

```
room bathroom light off
```

```
room bathroom dim low
```

```
room bathroom dim high
```

```
room bathroom low
```

```
room bathroom medium
```

**Side light Command**

```
room side light on
```

```
room side light off
```


## Z-Wave Devices and Fibaro:

You can find the device id directly through your fibaro HCL/HC2 web interface.
The devices that are tested are:

* Fibaro Dimmer 2
* TBK Home Light Dimmer Switch
* Swiid Inter Cord Switch


## Contributing

Please fill free to contribute and ask any new integration with cortana. More voice commands in Roadmap with Scenes and several other devices.


## License

This project is licensed under the MIT License

## Acknowledgments

* Thank to Costas and Nikos for helping me in this project :-)


