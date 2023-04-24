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

        public void Get_arr(Label[] get_label)
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
            while (true)
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Text = label[i];
                    label[i] = label[i];
                }
                await Task.Delay(1000);
                foreach (var i in label)
                {
                    System.Console.WriteLine(i);
                }
            }
        }
        //private string[] places = { "Место 1", "Место 2", "Место 3", "Место 4", "Конференц-зал 5", "Конференц-зал 6", "Конференц-зал 7" };

        public string get_text(int num_place)
        {
            return label[num_place - 1];
        }

        public void set_text(int num_place, string text)
        {
            label[num_place] = text;

        }
    }
}
