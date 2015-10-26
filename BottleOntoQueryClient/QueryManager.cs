using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Linq;

namespace BottleOntoQueryClient
{
    public enum VerticleSeam { continuous, partial, none, notSelected };
    public enum Opening { wide, narrow, notSelected };
    public enum Finish { tooled, applied, threaded, other, notSelected };
    public enum bBaseSeam { straight, circle, keymold, none, notSelected };
    public enum PontilScar { scarPresent, noScar, notSelected }
    public enum Bubbles { blisters, seeds, none, notSelected };
    public enum AirVents { yes, no, notSelected };
    public enum ColorAtts { aqua, straw, lavender, other, clear, notSelected };
    public enum SuctionScar { yes, no, notSelected };
    public enum BaseTexture { yes, no, notSelected };

    public static class QueryManager
    {

        public static bool fedEm, enamel, noDecor;

        public static VerticleSeam vSeam = VerticleSeam.notSelected;
        public static Opening opening = Opening.notSelected;
        public static bBaseSeam bSeam = bBaseSeam.notSelected;
        public static ColorAtts color = ColorAtts.notSelected;
        public static Bubbles bubbles = Bubbles.notSelected;
        public static Finish finish = Finish.notSelected;
        public static PontilScar pontil = PontilScar.notSelected;
        public static AirVents airVents = AirVents.notSelected;
        public static SuctionScar suctionScar = SuctionScar.notSelected;
        public static BaseTexture baseTexture = BaseTexture.notSelected;

        private static string results, query;
        public static string maxDate, minDate;
        public static string[] ResultsArray;
        public static bool noResult;

        public static void ExecuteQuery()
        {
            BuildQuery();
            CallService();
        }

        private static string BuildQuery()
        {
            query = "MinimumManufactureDate";

            //Add Verticle Seam Statement
            string vsString = VerticleSeamSwitch();         
            if (!String.IsNullOrEmpty(vsString))
            {
                query = query + vsString;
            }

            //Add Opening Statement
            string oString = OpeningSwitch();
            if(!String.IsNullOrEmpty(oString))
            {
                query = query + oString;
            }


            //Add Finish Statement
            string fString = FinishSwitch();
            if (!String.IsNullOrEmpty(fString))
            {
                query = query + fString;
            }

            //Add Base Seam Statement
            string bsString = BaseSeamSwitch();
            if (!String.IsNullOrEmpty(bsString))
            {
                query = query + bsString;
            }

            //Add Pontil Scar Statement
            string pString = PontilScarSwitch();
            if (!String.IsNullOrEmpty(pString))
            {
                query = query + pString;
            }

            //Add Color Statement
            string cString = ColorAttsSwitch();
            if (!String.IsNullOrEmpty(cString))
            {
                query = query + cString;
            }

            //Add Inclusion Statement
            string bString = BubbleSwitch();
            if (!String.IsNullOrEmpty(bString))
            {
                query = query + bString;
            }

            //Add Inclusion Statement
            string aString = AirVentSwitch();
            if (!String.IsNullOrEmpty(aString))
            {
                query = query + aString;
            }

            //Add Inclusion Statement
            string btString = TextureSwitch();
            if (!String.IsNullOrEmpty(btString))
            {
                query = query + btString;
            }

            //Add Inclusion Statement
            string ssString = SuctionScarSwitch();
            if (!String.IsNullOrEmpty(ssString))
            {
                query = query + ssString;
            }


            if (fedEm)
            { query = query + " And HasDecor some FedEmbossing"; }

            if (enamel)
            { query = query + " And HasDecor some Enamel"; }

            return query;
        }

        private static void CallService()
        {
            string finalQuery = String.Format("DateRange and RangeImpliedBy some ({0})", query);
            QueryServiceRef.OntologyQueryServiceClient myQuerySerivce = new QueryServiceRef.OntologyQueryServiceClient();
            myQuerySerivce.QueryMethodCompleted += new EventHandler<QueryServiceRef.QueryMethodCompletedEventArgs>(myQuerySerivce_QueryMethodCompleted);
            myQuerySerivce.QueryMethodAsync(finalQuery);
        }

        static void myQuerySerivce_QueryMethodCompleted(object sender, QueryServiceRef.QueryMethodCompletedEventArgs e)
        {
            results = e.Result;
            QueryResultParser();

           // NavigationService navigator = new NavigationService();
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/QueryResults.xaml", UriKind.Relative));
        }

        private static string VerticleSeamSwitch()
        {
            string clause;

            switch (vSeam)
            {
                case VerticleSeam.continuous: clause = " And HasVerticleSeam some ContinuousVertSeam";
                    break;
                case VerticleSeam.partial: clause = " And HasVerticleSeam some PartialVertSeam";
                    break;
                case VerticleSeam.none: clause = " And HasVerticleSeam some NoVertSeam";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string OpeningSwitch()
        {
            string clause;

            switch (opening)
            {
                case Opening.wide: clause = " And HasOpening some WideOpening";
                    break;
                case Opening.narrow: clause = " And HasOpening some NarrowOpening";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string FinishSwitch()
        {
            string clause;

            switch (finish)
            {
                case Finish.applied: clause = " And HasFinish some AppliedFinish";
                    break;
                case Finish.tooled: clause = " And HasFinish some TooledFinish";
                    break;
                case Finish.threaded: clause = " And HasFinish some ThreadFinish";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string BaseSeamSwitch()
        {
            string clause;

            switch (bSeam)
            {
                case bBaseSeam.straight: clause = " And HasBaseSeam some Straight";
                    break;
                case bBaseSeam.circle: clause = " And HasBaseSeam some Circle";
                    break;
                case bBaseSeam.keymold: clause = " And HasBaseSeam some KeyMold";
                    break;
                case bBaseSeam.none: clause = " And HasBaseSeam some NoBaseSeam";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string PontilScarSwitch()
        {
            string clause;

            switch (pontil)
            {
                case PontilScar.scarPresent: clause = " And HasPontilScar some ScarPresent";
                    break;
                case PontilScar.noScar: clause = " And HasPontilScar some NoScar";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string ColorAttsSwitch()
        {
            string clause;

            switch (color)
            {
                case ColorAtts.aqua: clause = " And HasColor some Aqua";
                    break;
                case ColorAtts.other: clause = " And HasColor some Other";
                    break;
                case ColorAtts.straw: clause = " And HasColor some ClearStraw";
                    break;
                case ColorAtts.lavender: clause = " And HasColor some ClearLavender";
                    break;
                case ColorAtts.clear: clause = " And HasColor some ClearNoTint";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string BubbleSwitch()
        {
            string clause;

            switch (bubbles)
            {
                case Bubbles.blisters: clause = " And HasInclusions some Blisters";
                    break;
                case Bubbles.seeds: clause = " And HasInclusions some Seeds";
                    break;
                case Bubbles.none: clause = " And HasInclusions some No_Inclusions";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string AirVentSwitch()
        {
            string clause;

            switch (airVents)
            {
                case AirVents.yes: clause = " And HasAirVents some Present";
                    break;
                case AirVents.no: clause = " And HasAirVents some NoVents";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string SuctionScarSwitch()
        {
            string clause;

            switch (suctionScar)
            {
                case SuctionScar.yes: clause = " And HasBase some SuctionScar";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        private static string TextureSwitch()
        {
            string clause;

            switch (baseTexture)
            {
                case BaseTexture.yes: clause = " And HasBase some Texture";
                    break;
                default: clause = null;
                    break;
            }

            return clause;
        }

        public static void QueryResultParser()
        {
            int select;
            string[] Classes = results.Split(';');

            if(Classes[0].Equals("parser exception"))
            {
                    noResult = true;
                    return;
            }
            //return the equivalent class as the result
            //if there isnt an equivalent class return the subclasses
            if (Classes[1].Equals("EquivalentClasses: [NONE]") || Classes[1].Equals("EquivalentClasses: Nothing"))
            {
                if (Classes[2].Equals("SubClasses: [NONE]") || Classes[2].Equals("SubClasses: Nothing"))
                {
                    noResult = true;
                    return;
                }
                else
                {
                    select = 2;
                }
            }
            else 
            {
                select = 1;
            }
            ResultsArray = Classes[select].Split(' ');
            Array.Sort(ResultsArray);

            if (ResultsArray[ResultsArray.Length - 1].Equals("RangeBefore1820") || ResultsArray[ResultsArray.Length - 2].Equals("RangeBefore1820"))
            {
                string[] tempArray = new string[ResultsArray.Length];

                var str = (from x in ResultsArray where x.Equals("RangeBefore1820") select x).FirstOrDefault();
                tempArray[0] = str.ToString();
                int tempCounter = 1;
                for (int i = 0; i < ResultsArray.Length; i++)
                {
                    if (!ResultsArray[i].Equals("RangeBefore1820"))
                    {
                        tempArray[tempCounter] = ResultsArray[i];
                        tempCounter++;
                    }
                }
                Array.Copy(tempArray, ResultsArray, ResultsArray.Length);
                minDate = "No Min";
                maxDate = "1820";
            }
            else
            {
                minDate = ResultsArray[0].Substring(5, 4);
                maxDate = ResultsArray[ResultsArray.Length - 2].Substring(10, 4);
            }
            noResult = false;
        }
    }
}
