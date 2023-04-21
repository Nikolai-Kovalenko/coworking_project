using System;
using System.Threading;
using System.Threading.Tasks;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class Timer
    {
        int hours;
        int minutes;

        public Timer()
        {
        }

        public Timer(string hours, string minutes)
        {
            this.hours = Convert.ToInt32(hours);
            this.minutes = Convert.ToInt32(minutes);
        }

        public int seconds()
        {
            return hours * 3600 + minutes * 60;
        }

        public string Сountdown()
        {
            return $"";
        }

        public void TestMethod(Label label)
        {
            label.Text = "sdg";

        }

    }
}
