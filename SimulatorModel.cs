using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace FlightSimulator
{
	class SimulatorModel : ISimulatorModel
	{
		public TelnetClient telnetClient;
		volatile Boolean stop;

		public SimulatorModel(TelnetClient telnetClient)
		{
			this.telnetClient = telnetClient;
			stop = false;
		}
		public void connect(string ip, int port)
		{
			telnetClient.connect(ip, port);
		}
		public void disconnect()
		{
			stop = true;
			this.telnetClient.disconnect();
		}
		public void start()
		{
			double d= Double.Parse("34.5");
			latitude = d;

			Thread t = new Thread(delegate ()
			  {
				  while (!stop)
				  {
					  telnetClient.write("get /position/latitude-deg");
					  //latitude and longitude in different order in Location class
					  location.Longitude = Double.Parse(telnetClient.read());
					  telnetClient.write("get /position/longitude-deg");
					  location.Latitude = Double.Parse(telnetClient.read());
					  NotifyPropertyChanged("Location");
					  telnetClient.write("get /instrumentation/heading-indicator/indicated-heading-deg");
					  heading_deg = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/gps/indicated-vertical-speed");
					  vertical_speed = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/airspeed-indicator/indicated-speed-kt");


					  airspeed = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/gps/indicated-ground-speed-kt");


					  ground_speed = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/attitude-indicator/internal-roll-deg");


					  roll = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/gps/indicated-altitude-ft");


					  altitude = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/attitude-indicator/internal-pitch-deg");


					  pitch = Double.Parse(telnetClient.read());
					  telnetClient.write("get /instrumentation/altimeter/indicated-altitude-ft");
					  altimeter = Double.Parse(telnetClient.read());

					  Thread.Sleep(250);
				  }
			  }); 
		t.SetApartmentState(ApartmentState.STA);
		t.Start();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private double heading;
		public double heading_deg
		{
			get
			{
				return heading;
			}
			set
			{
				heading = value;
				NotifyPropertyChanged("heading_deg");
			}
		}
		public double vertical;
		public double vertical_speed
		{
			get
			{
				return vertical;
			}
			set
			{
				vertical = value;
				NotifyPropertyChanged("vertical_speed");
			}
		}
		public double ground;
		public double ground_speed
		{
			get
			{
				return ground;
			}
			set
			{
				ground = value;
				NotifyPropertyChanged("ground_speed");
			}
		}
		public double airs;
		public double airspeed
		{
			get
			{
				return airs;
			}
			set
			{
				airs = value;
				NotifyPropertyChanged("airspeed");
			}
		}
		public double alt;
		public double altitude
		{
			get
			{
				return alt;
			}
			set
			{
				alt = value;
				NotifyPropertyChanged("altitude");
			}
		}
		public double rollo;
		public double roll
		{
			get
			{
				return rollo;
			}
			set
			{
				rollo = value;
				NotifyPropertyChanged("roll");
			}
		}
		public double pitchy;
		public double pitch
		{
			get
			{
				return pitchy;
			}
			set
			{
				pitchy = value;
				NotifyPropertyChanged("pitch");
			}
		}
		public double altim;
		public double altimeter
		{
			get
			{
				return altim;
			}
			set
			{
				altim = value;
				NotifyPropertyChanged("altimeter");
			}
		}
		public double longi;
		public double longitude
		{
			get
			{
				return longi;
			}
			set
			{
				longi = value;
				NotifyPropertyChanged("longitude");
			}
		}
		public double lat;
		public double latitude
		{
			get
			{
				return lat;
			}
			set
			{
					lat = value;
					NotifyPropertyChanged("latitude");
			}
		}
		public double rudder;
		public double Rudder
		{
			get
			{
				return rudder;
			}
			set
			{
				rudder = value;
				NotifyPropertyChanged("Rudder");
			}
		}
		public double elavator;
		public double Elavator
		{
			get
			{
				return elavator;
			}
			set
			{
				elavator = value;
				NotifyPropertyChanged("Elavator");
			}
		}
		public double throttle;
		public double Throttle
		{
			get
			{
				return throttle;
			}
			set
			{
				throttle = value;
				NotifyPropertyChanged("Throttle");
			}
		}
		public double aileron;
		public double Aileron
		{
			get
			{
				return aileron;
			}
			set
			{
				aileron = value;
				NotifyPropertyChanged("Aileron");
			}
		}
		private Location location = new Location(3, 31);

		public Location Location
		{
			get
			{
			
				return location;
			}
			set
			{
				location = value;
				NotifyPropertyChanged("Location");

			}
		}

		

		public void NotifyPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
