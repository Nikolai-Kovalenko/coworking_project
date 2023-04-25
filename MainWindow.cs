using System;
using System.Threading;
using System.Threading.Tasks;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class MainWindow : Window
    {
        [UI] public Button _button_count = null;
        [UI] public Button _button_sale = null;
        [UI] public Button _button_extend = null;
        [UI] public Button _button_reset = null;
        [UI] public Button _button_free = null;

        [UI] public Entry _entry_hours = null;
        [UI] public Entry _entry_minutes = null;
        [UI] public Entry _entry_place = null;

        [UI] public Label _label_price = null;

        [UI] public Label _place1 = null;
        [UI] public Label _place2 = null;
        [UI] public Label _place3 = null;
        [UI] public Label _place4 = null;
        [UI] public Label _place5 = null;
        [UI] public Label _place6 = null;
        [UI] public Label _place7 = null;


        string place;
        string hours;
        string minutes;
        string _price;

        public static Places places = new Places();

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button_count.Clicked += Button_count_Clicked;
            _button_reset.Clicked += Button_reset_Clicked;
            _button_sale.Clicked += Button_sale_Clicked;
            _button_free.Clicked += Button_free_Clicked;
            _button_extend.Clicked += Button_extend_Clicked;
            //_button_free.Clicked += Button_free_Clicked;
        }

        public void Run_sicle()
        {
            Label[] labels = new Label[] { _place1, _place2, _place3, _place4, _place5, _place6, _place7 };
            places.Get_arr(labels);
            places.Print_time();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button_count_Clicked(object sender, EventArgs a)
        {
            this.place = _entry_place.Text;
            this.hours = _entry_hours.Text;
            this.minutes = _entry_minutes.Text;

            Price price = new Price();

            price.Get_data(place, hours, minutes);
            this._price = price.Calculate_price();
            _label_price.Text = _price;
        }

        private void Button_reset_Clicked(object sender, EventArgs a)
        {
            _entry_place.Text = "";
            _entry_hours.Text = "";
            _entry_minutes.Text = "";
            _label_price.Text = "";
        }

        private void Button_sale_Clicked(object sender, EventArgs a)
        {
            Print_time();
        }
        private void Button_free_Clicked(object sender, EventArgs a)
        {
            Remove_text(Convert.ToInt32(_entry_place.Text) - 1);
        }

        private void Button_extend_Clicked(object sender, EventArgs a)
        {

        }

        private void Print_time()
        {

            Label[] labels = new Label[] { _place1, _place2, _place3, _place4, _place5, _place6, _place7 };
            int num = Convert.ToInt32(place) - 1;


            string str = labels[num].Text;

            if (str.StartsWith("Место") || str.StartsWith("Конфе"))
            {
                try
                {
                    Timer timer = new Timer(hours, minutes);

                    //Places places = new Places();
                    places.set_text(num, Convert.ToString(timer.seconds()));
                    _label_price.Text = $"Оплпта {_price} пинята и место {place} забронировано";
                }
                catch
                {
                    _label_price.Text = "Сначала рассчитайте цену для нового места!";
                }
            }
            else
            {
                _label_price.Text = "Данное место уже занято!";
            }
        }

        private void Remove_text(int num_place)
        {
            string new_tex;
            if (num_place < 5)
            {
                new_tex = $"Место {num_place + 1}";
            }
            else
            {
                new_tex = $"Конференц-зал {num_place + 1}";
            }
            places.set_text(num_place, new_tex);
        }
    }
}
