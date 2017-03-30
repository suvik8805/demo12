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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace pelihahmoliikkuvuus
{
    public sealed partial class Pelihahmo : UserControl
    { 
    
        // animaation timer
        private DispatcherTimer timer;

        // Hahmon näkyminen
        private int currentFrame = 0;
        private int direction = 1; // 1 tai -1, -1 vasen, 1 oikee, vrt koordinaatisto
        private int frameHeight = 40; // objektin koko

        //vauhti
        private readonly double Maxspeed = 10; //maksimivauhti
        private readonly double Accelerate = 1; // kiihtyvyys
        private double speed;

        private readonly double AngleStep = 5;
      


        public Pelihahmo()
        {
            this.InitializeComponent();

            //animaatio
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 125);
            // millisekunnit
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        //sijainti x ja y -akselit
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public object ButterflyRotateAngle { get; private set; }
        public object SpriteSheetOffset { get; private set; }

        //kääntymisen arvot
        private double Angle = 0; // tulee objektin määrittelystä

        internal void Move(int v)
        {
            throw new NotImplementedException();
        }

        private void Timer_Tick(object sender, object e)
        {
            SpriteSheetOffset.Y = currentFrame * -frameHeight;
        }

        //vauhti
        public void Move()
        {
            speed += Accelerate;
            if (speed > Maxspeed) speed = Maxspeed;

            Angle += direction * AngleStep; //-1*5 or 1*5
  
        }

        // sijainnin päivitys
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX); // vaakalinja
            SetValue(Canvas.TopProperty, LocationY); // pystylinja
        }
        

    }
}

    
    
    

