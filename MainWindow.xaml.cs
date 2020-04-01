using FlightSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SimulatorViewModel vm;
		bool connected = false;

		public MainWindow()
		{
			InitializeComponent();
			vm = new SimulatorViewModel(new SimulatorModel(new TelnetClient()));
			DataContext = vm;

			

		}

		private void B_Click(object sender, RoutedEventArgs e)
		{
			if (connected == false)
			{
				vm.model.connect("127.0.0.1",5402);
				vm.model.start();
				vm.model.Status = "Connected succesfuly";
				connected = true;
			}
			

		}

		private void B2_Click(object sender, RoutedEventArgs e)
		{
			if (connected == true)
			{
				vm.model.disconnect();
				vm.model.Status = "disconnected";
				connected = false;
			}
		}
	}



	
}
