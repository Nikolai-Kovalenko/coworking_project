using System;
using System.Threading;
using System.Threading.Tasks;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace coworking_project
{
    class Places : MainWindow
    {
        string[] label = { "Место 1", "Место 2", "Место 3", "Место 4", "Конференц-зал 5", "Конференц-зал 6", "Конференц-зал 7" };

        Label[] labels = new Label[7];

        public Places() { }

        public Places(Label[] get_label)
        {
            FillArray(labels, get_label);
        }

        static void FillArray(Label[] set_arr, Label[] get_arr)
        {
            for (int i = 0; i < get_arr.Length; i++)
            {
                set_arr[i] = get_arr[i];
            }
        }

        public async void Print_time()
        {
            int j = 0;
            while (true)
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Text = label[i] + $"{j}";
                    label[i] = label[i];
                }
                j++;
                await Task.Delay(1000);
            }
        }
        //private string[] places = { "Место 1", "Место 2", "Место 3", "Место 4", "Конференц-зал 5", "Конференц-зал 6", "Конференц-зал 7" };

        public string get_text(int num_place)
        {
            return label[num_place - 1];
        }

        public void set_text(int num_place, string text)
        {
            int place_index = num_place - 1;
            label[place_index] = text;
        }
    }
}
