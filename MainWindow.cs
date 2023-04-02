using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class MainWindow : Window
    {
        [UI] public Button _button_count = null;
        [UI] public Button _button_sale = null;
        [UI] public Button _button_extend = null;
        [UI] public Entry _entry_hours = null;
        [UI] public Entry _entry_minutes = null;
        [UI] public Label _label_price = null;
        [UI] public Entry _entry_place = null;

        [UI] public Label _place1 = null;
        [UI] public Label _place2 = null;
        [UI] public Label _place3 = null;
        [UI] public Label _place4 = null;
        [UI] public Label _place5 = null;
        [UI] public Label _place6 = null;
        [UI] public Label _place7 = null;

        double price_for_minute = 1.5;

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

        private void Button_count_Clicked(object sender, EventArgs a)
        {
            string place     = _entry_place.Text;
            string hours     = _entry_hours.Text;
            string minutes    = _entry_minutes.Text;

            Calc_price calc_price = new Calc_price();
            _label_price.Text = calc_price.Calculate_price(place, hours, minutes);
        }
    }
}
