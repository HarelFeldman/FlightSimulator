using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlightSimulator
{
	class SimulatorViewModel : INotifyPropertyChanged
	{
		public ISimulatorModel model;
		public SimulatorViewModel(ISimulatorModel model)
		{
			this.model = model;
			model.PropertyChanged +=
			  delegate (Object sender, PropertyChangedEventArgs e)
			  {
				  NotifyPropertyChanged("VM_" + e.PropertyName);
			  };
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
		// Properties
		public double VM_heading_deg
		{
			get
			{
				return model.heading_deg;
			}

		}
		public double VM_vertical_speed
		{
			get
			{
				return model.vertical_speed;
			}

		}

		public double VM_ground_speed
		{
			get
			{
				return model.ground_speed;
			}

		}
		public double VM_airspeed
		{
			get
			{
				return model.airspeed;
			}

		}
		public double VM_altitude
		{
			get
			{
				return model.altitude;
			}

		}
		public double VM_roll
		{
			get
			{
				return model.roll;
			}

		}
		public double VM_pitch
		{
			get
			{
				return model.pitch;
			}

		}
		public double VM_altimeter
		{
			get
			{
				return model.altimeter;
			}

		}
		public double VM_longitude
		{
			get
			{
				return model.longitude;
			}

		}
		public double VM_latitude
		{
			get
			{
				return model.latitude;
			}
		}
		public double VM_Rudder
		{
			set
			{
				model.Rudder = value;
			}
		}
		public double VM_Aileron
		{
			set
			{
				model.Aileron = value;
			}
		}
		public double VM_Throttle
		{
			set
			{
				model.Throttle = value;
			}
		}
		public double VM_Elavator
		{
			set
			{
				model.Elavator = value;
			}
		}
		public Location VM_Location
		{
			get
			{
				return model.Location;
			}
		}

	}
}
