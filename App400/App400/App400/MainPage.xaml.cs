using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App400
{  

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<EventsHB> AllItems { get; set; }


        public MainPage()
        {
            InitializeComponent();            

            AllItems = new ObservableCollection<EventsHB>();

            var julyGroup = new EventsHB() {month = "july"};

            julyGroup.Add(new EventTO() { calendarEventId = "1", title = "firstTitle", startDate = "01-1-1", startTime = "01-1-1"});
            julyGroup.Add(new EventTO() { calendarEventId = "2", title = "secondTitle", startDate = "02-1-1", startTime = "01-1-2" });
            julyGroup.Add(new EventTO() { calendarEventId = "3", title = "thirdTitle", startDate = "02-1-1", startTime = "01-1-3" });
            julyGroup.Add(new EventTO() { calendarEventId = "4", title = "fourthTitle", startDate = "02-1-1", startTime = "01-1-4" });
            
            var juneGroup = new EventsHB() { month = "june" };
            juneGroup.Add(new EventTO() { calendarEventId = "1", title = "junefirstTitle", startDate = "01-1-1", startTime = "01-1-1" });
            juneGroup.Add(new EventTO() { calendarEventId = "2", title = "junesecondTitle", startDate = "02-1-1", startTime = "01-1-2" });
            juneGroup.Add(new EventTO() { calendarEventId = "3", title = "junethirdTitle", startDate = "02-1-1", startTime = "01-1-3" });
            juneGroup.Add(new EventTO() { calendarEventId = "4", title = "junefourthTitle", startDate = "02-1-1", startTime = "01-1-4" });

            AllItems.Add(julyGroup);
            AllItems.Add(juneGroup);
            //...
            //more months like April,May can be added

            BindingContext = this;
        }

        //A test function to convert you json array to the array we need
        void test() {

            EventsHB julyGroup = new EventsHB() { month = "july" }; ;
            EventsHB juneGroup = new EventsHB() { month = "june" };
            //other months group


            foreach (var item in AllItems)
            {
                EventsHB hb = item; 
                if (hb.month == "july")
                {               
                    julyGroup.Add(hb.eventTO);
                }
                else if (hb.month == "june")
                {
                    juneGroup.Add(hb.eventTO);
                }//...other months
            }

            //at last, add them to All items.
            AllItems.Add(julyGroup);
            AllItems.Add(juneGroup);
            //...add other months
        }
    }

    public class EventsHB : ObservableCollection<EventTO>
    {
        public string month { get; set; }
        public EventTO eventTO { get; set; }
    }

    public class EventTO
    {
        public string calendarEventId { get; set; }
        public string title { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
    }
}
