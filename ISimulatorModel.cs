using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlightSimulator
{
    interface ISimulatorModel : INotifyPropertyChanged
    {
        // connection to simulator
        void connect(string ip, int port);
        void disconnect();
        void start();
        //ללוח המחוונים
        double heading_deg { get; set; }
        double vertical_speed { get; set; }
        double ground_speed { get; set; }
        double airspeed { get; set; }
        double altitude { get; set; }
        double roll { get; set; }
        double pitch { get; set; }
        double altimeter { get; set; }
        //map
        double longitude { get; set; }
        double latitude { get; set; }
        //
        double Rudder { get; set; }
        double Elavator { get; set; }
        double Aileron { get; set; }
        double Throttle { get; set; }
        Location Location { get; set; }
        string Status { get; set; }
    }
}
