using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        private Point _startPos;
        private int _prevRudder;
        private double canvasWidth;
        private double canvasHeight;
        private int _prevElevator;

        public double Rudder { get; private set; }
        public double Elevator { get; private set; }

        public Joystick()
        {
            InitializeComponent();
        }


    

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Knob.IsMouseCaptured) return;
            Point Posit1 = e.GetPosition(Base);
            Point Posit2 = new Point(Posit1.X - _startPos.X, Posit1.Y = _startPos.Y);
            double distance = Math.Round(Math.Sqrt(Posit2.X * Posit2.X + Posit2.Y * Posit2.Y));
            if (distance >= canvasWidth / 2 || distance >= canvasHeight / 2) return;
            Rudder = -Posit2.Y;
            Elevator = Posit2.X;
            knobPosition.X = Posit2.X;
            knobPosition.Y = Posit2.Y;
           
        }

        private void Knob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPos = e.GetPosition(Base);
            _prevRudder = _prevElevator = 0;
            canvasWidth = Base.ActualWidth - KnobBase.ActualWidth;
            canvasHeight = Base.ActualHeight - KnobBase.ActualHeight;
            //Captured?.Invoke(this);
            Knob.CaptureMouse();
            //centerKnob.stop();

        }

        private void throttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
