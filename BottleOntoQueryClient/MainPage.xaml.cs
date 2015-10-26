using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BottleOntoQueryClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void vertSeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = vertSeamList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.vSeam = VerticleSeam.continuous;
                    break;
                case 1: QueryManager.vSeam = VerticleSeam.partial;
                    break;
                case 2: QueryManager.vSeam = VerticleSeam.none;
                    break;
                default: QueryManager.vSeam = VerticleSeam.notSelected;
                    break;
            }
        }

        private void baseSeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = baseSeamList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.bSeam = bBaseSeam.straight;
                    break;
                case 1: QueryManager.bSeam = bBaseSeam.circle;
                    break;
                case 2: QueryManager.bSeam = bBaseSeam.keymold;
                    break;
                case 3: QueryManager.bSeam = bBaseSeam.none;
                    break;
                default: QueryManager.bSeam = bBaseSeam.notSelected;
                    break;
            }
        }

        private void openingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = openingList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.opening = Opening.wide;
                    break;
                case 1: QueryManager.opening = Opening.narrow;
                    break;
                default: QueryManager.opening = Opening.notSelected;
                    break;
            }
        }

        private void finishList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = finishList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.finish = Finish.applied;
                    break;
                case 1: QueryManager.finish = Finish.tooled;
                    break;
                case 2: QueryManager.finish = Finish.threaded;
                    break;
                case 3:
                default: QueryManager.finish = Finish.notSelected;
                    break;
            }
        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = colorList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.color = ColorAtts.aqua;
                    break;
                case 1: QueryManager.color = ColorAtts.straw;
                    break;
                case 2: QueryManager.color = ColorAtts.lavender;
                    break;
                case 3: QueryManager.color = ColorAtts.clear;
                    break;
                case 4: QueryManager.color = ColorAtts.other;
                    break;
                default: QueryManager.color = ColorAtts.notSelected;
                    break;
            }
        }

        private void bubbleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = bubbleList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.bubbles = Bubbles.blisters;
                    break;
                case 1: QueryManager.bubbles = Bubbles.seeds;
                    break;
                case 2: QueryManager.bubbles = Bubbles.none;
                    break;
                default: QueryManager.bubbles = Bubbles.notSelected;
                    break;
            }
        }

        private void pontilList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = pontilList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.pontil = PontilScar.scarPresent;
                    break;
                case 1: QueryManager.pontil = PontilScar.noScar;
                    break;
                default: QueryManager.pontil = PontilScar.notSelected;
                    break;
            }
        }

        private void ventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ventList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.airVents = AirVents.yes;
                    break;
                case 1: QueryManager.airVents = AirVents.no;
                    break;
                default: QueryManager.airVents = AirVents.notSelected;
                    break;
            }
        }

        private void neckButtonFwd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DecorPage.xaml",UriKind.Relative));
            
        }
    }
}