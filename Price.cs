using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class Price : MainWindow

    {

        private double _num_place = 0;
        private double _hours = 0;
        private double _minutes = 0;

        public Price()
        {
            //           Calculate_price(_num_place, _hours, _minutes);
        }

        public void Get_data(string num_place, string hours, string minutes)
        {
            this._num_place = Chack_null(num_place);
            this._hours = Chack_null(hours);
            this._minutes = Chack_null(minutes);
        }


        public string Calculate_price()
        {
            if ((_num_place < 1 || _num_place > 7) == true)
            {
                return $"Места {_num_place} не существует";
            }
            if (Chack_time(_hours, _minutes) == false)
            {
                return "Времмя введено не корректно";
            }

            double price_for_minute = _num_place < 5 ? 1.5 : 5;
            if (price_for_minute == 0) return "Время введено не коректно";

            double total_price = (_hours * 60 + _minutes) * price_for_minute;
            return $"{total_price}";
        }

        private bool Chack_time(double hours, double minuttes)
        {
            if (hours > 8) return false;

            if (minuttes > 60) return false;

            return true;
        }

        private double Chack_null(string x)
        {
            double y;
            if (x == null)
            {
                y = 0;
            }
            else
            {
                double.TryParse(x, out y);
            }

            return y;
        }
    }
}

