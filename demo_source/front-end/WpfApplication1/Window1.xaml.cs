using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Window2 win2;
        TcpClient tcp = new TcpClient();
        private NetworkStream client;

        public Window1(int timer_inrange, int timer_outrange)
        {
            InitializeComponent();

            win1_status_other_grid.Visibility = Visibility.Collapsed;
            win1_current_textblock.Text = "INITIALIZING";
            win1_status_groupbox_vehicleid_textblock.Text = "DL3CAP5424";
            win1_status_groupbox_rating_textblock.Text = 0.0.ToString();
            win1_status_groupbox_balance_value_textblock.Text = 0.ToString();
            win1_status_groupbox_counter_value_textblock.Text = 0.ToString();
            win1_messagebox_history_textbox.Text = "";
            win1_messagebox_current_textblock.Text = "";

            demo_start(timer_inrange, timer_outrange);
        }


        private async void demo_start(int timer_inrange, int timer_outrange)
        {
            win1_messagebox_progressbar.Visibility = Visibility.Visible;
            win1_messagebox_progressbar.IsIndeterminate = true;
            print_message("Initializing...");
            await Task.Run(() =>
            {
                while (true)
                {
                    if (!tcp.Connected)
                    {
                        try
                        {
                            tcp.Connect("127.0.0.1", 44188);
                            client = tcp.GetStream();
                        }
                        catch { }
                    }
                    else
                    {
                        break;
                    }
                }
            });
            string[] initial_values = read_stream_message().Split(','); //balA, balB, rateA, rateB
            win1_status_groupbox_balance_value_textblock.Text = initial_values[0];
            win1_status_groupbox_rating_textblock.Text = initial_values[2];
            win1_messagebox_progressbar.Visibility = Visibility.Hidden;
            win1_messagebox_progressbar.IsIndeterminate = false;
            await wait_for_response("_beaconing");
            win1_current_textblock.Text = "BEACONING";
            print_message("No Vehicles in Range");
            await Task.Delay(1000);
            print_message("Beaconing...");
            win1_messagebox_progressbar.Visibility = Visibility.Visible;
            win1_messagebox_progressbar.IsIndeterminate = true;
            await counter_manager(timer_inrange);
            win1_messagebox_progressbar.Visibility = Visibility.Hidden;
            win1_messagebox_progressbar.IsIndeterminate = false;
            print_message("Vehicle DL3CAP5426 in Range");
            win2 = new Window2();
            win2.WindowStartupLocation = WindowStartupLocation.Manual;
            win2.Left = this.Left + this.Width;
            win2.Top = this.Top;
            win2.Show();
            win2.win2_status_groupbox_balance_value_textblock.Text = initial_values[1];
            win2.win2_status_groupbox_rating_textblock.Text = initial_values[3];
            win2.print_message("Vehicle DL3CAP5424 in Range");
            win1_status_other_grid.Visibility = Visibility.Visible;
            win2.win2_current_textblock.Text = "BEACONING";
            win1_status_other_groupbox_vehicleid_textblock.Text = win2.win2_status_groupbox_vehicleid_textblock.Text;
            win2.win2_status_other_groupbox_vehicleid_textblock.Text = win1_status_groupbox_vehicleid_textblock.Text;
            await Task.Delay(5000);
            print_message("Acquiring Balance and Rating of Vehicle DL3CAP5426...");
            win2.print_message("Acquiring Balance and Rating of Vehicle DL3CAP5424...");
            win1_messagebox_progressbar.IsIndeterminate = true;
            win1_messagebox_progressbar.Visibility = Visibility.Visible;
            win2.win2_messagebox_progressbar.IsIndeterminate = true;
            win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
            await Task.Delay(1000);
            win1_messagebox_progressbar.IsIndeterminate = false;
            win1_messagebox_progressbar.Visibility = Visibility.Hidden;
            win2.win2_messagebox_progressbar.IsIndeterminate = false;
            win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
            print_message("Updated Balance and Rating of Vehicle DL3CAP5426");
            win2.print_message("Updated Balance and Rating of Vehicle DL3CAP5424");
            win1_status_other_groupbox_rating_textblock.Text = win2.win2_status_groupbox_rating_textblock.Text;
            win1_status_other_groupbox_balance_value_textblock.Text = win2.win2_status_groupbox_balance_value_textblock.Text;
            win2.win2_status_other_groupbox_rating_textblock.Text = win1_status_groupbox_rating_textblock.Text;
            win2.win2_status_other_groupbox_balance_value_textblock.Text = win1_status_groupbox_balance_value_textblock.Text;
            await Task.Delay(1000);
            win1_current_textblock.Text = "RATING VALIDATION";
            win2.win2_current_textblock.Text = "RATING VALIDATION";
            print_message("Rating is Above Minimum Threshold for Vehicle DL3CAP5426");
            win2.print_message("Rating is Above Minimum Threshold for Vehicle DL3CAP5424");
            await Task.Delay(2000);
            await wait_for_response("link_prediction");
            win1_current_textblock.Text = "LINK PREDICTION";
            win2.win2_current_textblock.Text = "LINK PREDICTION";
            win1_messagebox_progressbar.IsIndeterminate = true;
            win1_messagebox_progressbar.Visibility = Visibility.Visible;
            win2.win2_messagebox_progressbar.IsIndeterminate = true;
            win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
            print_message("Predicting Link Duration...");
            win2.print_message("Predicting Link Duration...");
            await Task.Delay(500);
            print_message("Acquiring Navigation and Speed Information...");
            win2.print_message("Acquiring Navigation and Speed Information...");
            win1_messagebox_progressbar.IsIndeterminate = false;
            win2.win2_messagebox_progressbar.IsIndeterminate = false;
            await Task.Delay(3000);
            for (int i = 1; i <= 100; i++)
            {
                win1_messagebox_progressbar.Value = i;
                if (i%10==0) win2.win2_messagebox_progressbar.Value = i;
                await Task.Delay(10);
            }
            win1_messagebox_progressbar.Visibility = Visibility.Hidden;
            win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
            print_message("Link Duration (Counter Starts): " + timer_outrange.ToString() + "s");
            win2.print_message("Link Duration (Counter Starts): "+ timer_outrange.ToString() + "s");
            await Task.Delay(1000);
            await wait_for_response("service_advertisement");
            win1_current_textblock.Text = "SERVICE ADVERTISEMENT";
            win2.win2_current_textblock.Text = "SERVICE ADVERTISEMENT";


            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew( () => {
                Application.Current.Dispatcher.Invoke(new Action( async () =>
                {
                    print_message("Services Required by DL3CAP5426: EV_CHARGING_INFO");
                    print_message("Services Provided by Local Vehicle: EV_CHARGING_INFO");
                    print_message("Services Required by Local Vehicle: COMPUTATION_INFO, TRAFFIC_INFO, PARKING_INFO");
                    print_message("Services Provided by DL3CAP5426: TOLL_INFO, GAS_INFO");
                    win2.print_message("Services Required by DL3CAP5424: COMPUTATION_INFO, TRAFFIC_INFO, PARKING_INFO");
                    win2.print_message("Services Provided by Local Vehicle: TOLL_INFO, GAS_INFO");
                    win2.print_message("Services Required by Local Vehicle: EV_CHARGING_INFO");
                    win2.print_message("Services Provided by DL3CAP5424: EV_CHARGING_INFO");;
                    await Task.Delay(1000);
                    if (ct.IsCancellationRequested) return;
                    print_message("Matched Service: EV_CHARGING_INFO");
                    win2.print_message("Matched Service: EV_CHARGING_INFO");
                    await Task.Delay(1000);
                    if (ct.IsCancellationRequested) return;
                    print_message("Selling Service: EV_CHARGING_INFO");
                    win2.print_message("Buying Service: EV_CHARGING_INFO");
                    await wait_for_response("scheduling_service");
                    if (ct.IsCancellationRequested) return;
                    win1_current_textblock.Text = "SCHEDULING SERVICE";
                    win2.win2_current_textblock.Text = "SCHEDULING SERVICE";
                    print_message("Scheduled EV_CHARGING_INFO Service Exchange");
                    win2.print_message("Scheduled EV_CHARGING_INFO Service Exchange");
                    print_message("Allocating Resources...");
                    win2.print_message("Allocating Resources...");
                    win1_messagebox_progressbar.IsIndeterminate = true;
                    win1_messagebox_progressbar.Visibility = Visibility.Visible;
                    win2.win2_messagebox_progressbar.IsIndeterminate = true;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
                    await Task.Delay(5000);
                    if (ct.IsCancellationRequested) return;
                    win1_messagebox_progressbar.Visibility = Visibility.Hidden;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
                    print_message("Allocated Resources for EV_CHARGING_INFO Service Exchange");
                    win2.print_message("Allocated Resources for EV_CHARGING_INFO Service Exchange");
                    await Task.Delay(3000);
                    if (ct.IsCancellationRequested) return;
                    print_message("Establishing Secure TCP Connection...");
                    win2.print_message("Establishing Secure TCP Connection...");
                    win1_messagebox_progressbar.IsIndeterminate = true;
                    win1_messagebox_progressbar.Visibility = Visibility.Visible;
                    win2.win2_messagebox_progressbar.IsIndeterminate = true;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
                    await Task.Delay(2000);
                    if (ct.IsCancellationRequested) return;
                    print_message("Sending: EV_CHARGING_INFO");
                    win2.print_message("Receiving: EV_CHARGING_INFO");
                    await Task.Delay(1000);
                    win1_messagebox_progressbar.IsIndeterminate = false;
                    win2.win2_messagebox_progressbar.IsIndeterminate = false;
                    for (int i = 1; i <= 100; i++)
                    {
                        win1_messagebox_progressbar.Value = i;
                        if (i % 10 == 0) win2.win2_messagebox_progressbar.Value = i;
                        await Task.Delay(10);
                    }
                    win1_messagebox_progressbar.Visibility = Visibility.Hidden;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
                    print_message("Sent: EV_CHARGING_INFO");
                    win2.print_message("Received: EV_CHARGING_INFO");
                    await wait_for_response("blockchain_payment");
                    if (ct.IsCancellationRequested) return;
                    win1_current_textblock.Text = "BLOCKCHAIN PAYMENT";
                    win2.win2_current_textblock.Text = "BLOCKCHAIN PAYMENT";
                    //Random r = new Random();
                    //int ri = r.Next(1, int.Parse(win2.win2_status_groupbox_balance_value_textblock.Text)); //!
                    double price = 0.0100;
                    print_message("Receiving Payment from Vehicle DL3CAP5426: " + price);
                    win2.print_message("Sending Payment to Vehicle DL3CAP5424: " + price);
                    win1_messagebox_progressbar.Visibility = Visibility.Visible;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
                    for (int i = 1; i <= 100; i++)
                    {
                        win1_messagebox_progressbar.Value = i;
                        if (i % 10 == 0) win2.win2_messagebox_progressbar.Value = i;
                        await Task.Delay(1);
                    }
                    win1_messagebox_progressbar.Visibility = Visibility.Hidden;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
                    win1_status_groupbox_balance_value_textblock.Text = (double.Parse(win1_status_groupbox_balance_value_textblock.Text) + price).ToString();
                    print_message("ETH Balance Updated: +" + price.ToString());
                    win2.win2_status_groupbox_balance_value_textblock.Text = (double.Parse(win2.win2_status_groupbox_balance_value_textblock.Text) - price).ToString();
                    win2.print_message("ETH Balance Updated: -" + price.ToString());
                    win1_status_other_groupbox_balance_value_textblock.Text = win2.win2_status_groupbox_balance_value_textblock.Text;
                    win2.win2_status_other_groupbox_balance_value_textblock.Text = win1_status_groupbox_balance_value_textblock.Text;
                    await Task.Delay(1000);
                    await wait_for_response("_rating");
                    if (ct.IsCancellationRequested) return;
                    win1_current_textblock.Text = "RATING";
                    win2.win2_current_textblock.Text = "RATING";
                    print_message("Rating Vehicle DL3CAP5426...");
                    win2.print_message("Rating Vehicle DL3CAP5424...");
                    win1_messagebox_progressbar.IsIndeterminate = true;
                    win1_messagebox_progressbar.Visibility = Visibility.Visible;
                    win2.win2_messagebox_progressbar.IsIndeterminate = true;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Visible;
                    await Task.Delay(3000);
                    win1_messagebox_progressbar.IsIndeterminate = false;
                    win1_messagebox_progressbar.Visibility = Visibility.Hidden;
                    win2.win2_messagebox_progressbar.IsIndeterminate = false;
                    win2.win2_messagebox_progressbar.Visibility = Visibility.Hidden;
                    if (ct.IsCancellationRequested) return;
                    //double rd = Math.Round(r.NextDouble() * (5.0 - double.Parse(win1_status_groupbox_rating_textblock.Text)) + double.Parse(win1_status_groupbox_rating_textblock.Text), 2);
                    double rating = 5.0;
                    //win1_status_groupbox_rating_textblock.Text = rd.ToString();
                    print_message("Submitted Rating: " + rating);
                    //rd = Math.Round(r.NextDouble() * (5.0 - double.Parse(win2.win2_status_groupbox_rating_textblock.Text)) + double.Parse(win2.win2_status_groupbox_rating_textblock.Text), 2);
                    //win2.win2_status_groupbox_rating_textblock.Text = rd.ToString();
                    win2.print_message("Submitted Rating: " + rating);
                    win1_status_other_groupbox_rating_textblock.Text = win2.win2_status_groupbox_rating_textblock.Text;
                    win2.win2_status_other_groupbox_rating_textblock.Text = win1_status_groupbox_rating_textblock.Text;
                    win1_current_textblock.Text = "READY";
                    win2.win2_current_textblock.Text = "READY";
                    print_message("Complete");
                    win2.print_message("Complete");
                }));    
            }, ct);

            Task.Factory.StartNew(() => win2.counter_manager(timer_outrange));
            await counter_manager(timer_outrange);
            ts.Cancel();
            win2.Close();
            win1_current_textblock.Text = "READY";
            win2.win2_current_textblock.Text = "READY";
            print_message("Vehicle DL3CAP5426 Out of Range");
            win1_status_other_grid.Visibility = Visibility.Collapsed;
            win1_messagebox_progressbar.Visibility = Visibility.Hidden;
        }

        private async Task wait_for_response(string status)
        {
            Visibility prev_visibility = win1_messagebox_progressbar.Visibility;
            bool prev_isindeterminate = win1_messagebox_progressbar.IsIndeterminate;
            double prev_val = win1_messagebox_progressbar.Value;

            win1_messagebox_progressbar.Visibility = Visibility.Visible;
            win1_messagebox_progressbar.IsIndeterminate = true;
            win1_messagebox_progressbar.Value = 0;

            //print_message("Waiting for server to respond...");
            send_stream_message(status);
            await Task.Run( async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    if (read_stream_message() == "OK") break;
                }
            });

            //print_message("Server: OK");
            win1_messagebox_progressbar.Visibility = prev_visibility;
            win1_messagebox_progressbar.IsIndeterminate = prev_isindeterminate;
            win1_messagebox_progressbar.Value = prev_val;
        }

        private string read_stream_message()
        {
            string message = "";
            byte[] myReadBuffer = new byte[1024];
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            try
            {
                if (client.CanRead)
                {
                    do
                    {
                        numberOfBytesRead = client.Read(myReadBuffer, 0, myReadBuffer.Length);

                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    while (client.DataAvailable);
                }
                message = myCompleteMessage.ToString().TrimEnd('\r', '\n'); ;
            }
            catch { }

            return message;
        }

        private void send_stream_message(string str)
        {
            try
            {
                client.Write(System.Text.Encoding.ASCII.GetBytes(str), 0, System.Text.Encoding.ASCII.GetBytes(str).Length);
            }
            catch { }
        }

        private void print_message(string str)
        {
            win1_messagebox_current_textblock.Text = str;
            send_stream_message(str);
            add_to_history(str);
        }

        private void add_to_history(string str)
        {
            win1_messagebox_history_textbox.Text += "[" + DateTime.Now.TimeOfDay.ToString() + "] " + str + "\n";
            win1_messagebox_history_textbox.ScrollToEnd();
        }

        private async Task counter_manager(int counter)
        {
            win1_status_groupbox_counter_value_textblock.Text = counter.ToString();
            while (counter != 0)
            {
                await Task.Delay(1000);
                counter--;
                win1_status_groupbox_counter_value_textblock.Text = counter.ToString();
            }
        }

        private void win1_main_window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.win2 != null)
                win2.Close();
        }
    }
}
