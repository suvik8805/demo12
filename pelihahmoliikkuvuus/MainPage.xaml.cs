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
        public List<Karkki> karkit;

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

            Karkki karkki = new Karkki();
            karkit.Add(new Karkki { LocationX = 498, LocationY = 48 });
            karkit.Add(new Karkki { LocationX = 368, LocationY = 322 });
            karkit.Add(new Karkki { LocationX = 230, LocationY = 414 });
            karkit.Add(new Karkki { LocationX = 736, LocationY = 184 });
            karkit.Add(new Karkki { LocationX = 460, LocationY =552 });

            foreach (Karkki Karkki in karkit)
            {
                Tausta.Children.Add(Karkki);
                Karkki.SetLocation();
                karkit.Add(karkki);
            };





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



        /*
        private void KarkkiCollision()
        {
            //loop list
            foreach (Karkki karkki in karkit)
            {
                //get rects
                Rect HRect = new Rect(
                    pelihahmo.LocationX, pelihahmo.LocationY,
                    pelihahmo.ActualWidth, pelihahmo.ActualHeight
                    );
                Rect KRect = new Rect(
                    karkki.LocationX, karkki.LocationY,
                    karkki.ActualWidth, karkki.ActualHeight
                    );
                // törmäys?
                HRect.Intersect(KRect);
                if (!HRect.IsEmpty) //negaatio
                {
                    // Törmäys!
                    Tausta.Children.Remove(karkki);
                    // poisto listasta
                    karkit.Remove(karkki);
                    karkki.Picked = true;
                    break;
                }
            }
        }
        */

        private void PahisCollision()
        {
            Rect PRect = new Rect(
                pahis.LocationX, pahis.LocationY,
                pahis.ActualWidth, pahis.ActualHeight);
            Rect HRect = new Rect(
                pelihahmo.LocationX, pelihahmo.LocationY,
                pelihahmo.ActualHeight, pelihahmo.ActualWidth);
          //  Rect PRect2 = new Rect(
              //  pahis2.LocationX, pahis2.LocationY,
               // pahis2.ActualWidth, pahis2.ActualHeight);
            HRect.Intersect(PRect);
            if (!HRect.IsEmpty)
            {
                Tausta.Children.Remove(pahis);
                
            }

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

