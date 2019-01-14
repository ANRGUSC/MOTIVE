using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            win2_current_textblock.Text = "INITIALIZING";
            win2_status_groupbox_vehicleid_textblock.Text = "DL3CAP5426";
            win2_status_groupbox_rating_textblock.Text = 0.0.ToString();
            win2_status_groupbox_balance_value_textblock.Text = 0.ToString();
            win2_status_groupbox_counter_value_textblock.Text = 0.ToString();
            win2_messagebox_history_textbox.Text = "";
            win2_messagebox_current_textblock.Text = "";
        }

        public void print_message(string str)
        {
            win2_messagebox_current_textblock.Text = str;
            add_to_history(str);
        }

        public void add_to_history(string str)
        {
            win2_messagebox_history_textbox.Text += "[" + DateTime.Now.TimeOfDay.ToString() + "] " + str + "\n";
            win2_messagebox_history_textbox.ScrollToEnd();
        }

        public async Task counter_manager(int counter)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => { win2_status_groupbox_counter_value_textblock.Text = counter.ToString(); }));
            while (counter != 0)
            {
                await Task.Delay(1000);
                counter--;
                Application.Current.Dispatcher.Invoke(new Action(() => { win2_status_groupbox_counter_value_textblock.Text = counter.ToString(); }));
            }
        }
    }
}
