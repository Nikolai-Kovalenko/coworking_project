using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class MainWindow : Window
    {
        [UI] private Button _button_count = null;
        [UI] private Button _button_sale = null;
        [UI] private Button _button_extend = null;
        [UI] private Entry _entry_hours = null;
        [UI] private Entry _entry_minutes = null;
        [UI] private Label _label_price = null;

        double price_for_minute = 4.99;

        private int _counter;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button_count.Clicked += Button_count_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private double All_minetes(double hours, double minutes) {
            return hours * 60 + minutes;
        }

        private void Button_count_Clicked(object sender, EventArgs a)
        {
           double total_summ = All_minetes(Convert.ToDouble(_entry_hours.Text), Convert.ToDouble(_entry_minutes.Text));
            _label_price.Text = $"{total_summ}";
        }
    }
}
