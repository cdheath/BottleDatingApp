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
    public partial class QueryResults : PhoneApplicationPage
    {
        public QueryResults()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!QueryManager.noResult)
            {
                string[] results = QueryManager.ResultsArray;

                minDateBox.Text = QueryManager.minDate;
                maxDateBox.Text = QueryManager.maxDate;

                if (results.Length == 2)
                { moreInfoLabel.Text = ""; }

                foreach (var result in results)
                {
                    if (!result.Equals("EquivalentClasses:") && !result.Equals("SubClasses:"))
                    {
                        modelBox.Items.Add(result.Substring(5));
                    }
                }
            }
            else
            {
                moreInfoLabel.Text = "Conflicting data was given, No models were returned";
                modelBox.Items.Add("None");
            }
        }
    }
}