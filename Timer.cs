using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class Timer
    {
        int hours;
        int minutes;

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

    }
}
