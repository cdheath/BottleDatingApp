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
    public partial class DecorPage : PhoneApplicationPage
    {
        public DecorPage()
        {
            InitializeComponent();
        }

        private void suctionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = suctionList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.suctionScar = SuctionScar.yes;
                    break;
                case 1: QueryManager.suctionScar = SuctionScar.no;
                    break;
                default: QueryManager.suctionScar = SuctionScar.notSelected;
                    break;
            }
        }

        private void textureList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = textureList.SelectedIndex;
            switch (index)
            {
                case 0: QueryManager.baseTexture = BaseTexture.yes;
                    break;
                case 1: QueryManager.baseTexture = BaseTexture.no;
                    break;
                default: QueryManager.baseTexture = BaseTexture.notSelected;
                    break;
            }
        }

        private void enamelBox_Click(object sender, RoutedEventArgs e)
        {
            QueryManager.enamel = !QueryManager.enamel;
        }

        private void noDecBox_Click(object sender, RoutedEventArgs e)
        {
            QueryManager.noDecor = !QueryManager.noDecor;
        }

        private void fedEmBox_Click(object sender, RoutedEventArgs e)
        {
            QueryManager.fedEm = !QueryManager.fedEm;
        }

        private void decorButtonFwd_Click(object sender, RoutedEventArgs e)
        {
            QueryManager.ExecuteQuery();
            decorButtonFwd.Content = "Loading";
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            decorButtonFwd.Content = "Query";
        }

        /*
        private void decorButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }*/


    }
}