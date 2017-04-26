using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace pelihahmoliikkuvuus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Pelihahmo pelihahmo;
        private Pahis pahis;
        private Seinä seinä;
        private Pahis2 pahis2;
        private Pahis3 pahis3;

        // näppäinten arvot ylös/alas
        private bool LeftPressed;
        private bool RightPressed;
        private bool Uppressed;
        private bool Downpressed;


        //pelilloopi
        private DispatcherTimer timer;
       

        public object SpriteSheetOffset { get; private set; }
        public double LocationY { get; private set; }
        public double LocationX { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();

            // hahmo taustaan

            pelihahmo = new Pelihahmo
            {
                LocationX = 10,
                LocationY = 550
            };

            Tausta.Children.Add(pelihahmo);

           pahis = new Pahis
                {
                LocationX = 184,
                LocationY = 50
               };

            Tausta.Children.Add(pahis);
            pahis2 = new Pahis2
            {
                LocationX = 230,
                LocationY = 370
            };
            Tausta.Children.Add(pahis2);

            pahis3 = new Pahis3
            {
                LocationX = 598,
                LocationY = 400
            };
            Tausta.Children.Add(pahis3);

            seinä = new Seinä
            {
                LocationX = 300,
                LocationY = 300
            };

            Tausta.Children.Add(seinä);
            
            //näppäimet alas/ylös
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            //pelilooppi
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start(); 
        }

        private void Timer_Tick(object sender, object e)
        {



            if (LeftPressed) pelihahmo.MoveLeft();
            if (RightPressed) pelihahmo.MoveRight();
            if (Uppressed) pelihahmo.MoveUp();
            if (Downpressed) pelihahmo.MoveDown();

            pahis.Move();
            pahis2.Move();
            pahis3.Move();
            
            
            
           

            //päivitä sijainti
            pelihahmo.SetLocation();
            pahis.SetLocation();
            seinä.SetLocation();
        }
       

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                case VirtualKey.Up:
                    Uppressed = false;
                    break;
                case VirtualKey.Down:
                    Downpressed = false;
                    break;


            }

        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                case VirtualKey.Up:
                    Uppressed = true;
                    break;
                case VirtualKey.Down:
                    Downpressed = true;
                    break;


            }
            
            }
        }
    }

