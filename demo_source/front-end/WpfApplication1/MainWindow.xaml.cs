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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_timer_inrange_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _inrange;
            if (int.TryParse(start_timer_inrange_textbox.Text, out _inrange) == false)
            {
                MessageBox.Show("Please enter only integer values.", "Value Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                start_timer_inrange_textbox.SelectAll();
            }
            e.Handled = true;
        }

        private void start_timer_outrange_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _outrange;
            if (int.TryParse(start_timer_outrange_textbox.Text, out _outrange) == false)
            {
                MessageBox.Show("Please enter only integer values.", "Value Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                start_timer_outrange_textbox.SelectAll();
            }
            e.Handled = true;
        }

        private void start_start_button_Click(object sender, RoutedEventArgs e)
        {
            int timer_inrange = int.Parse(start_timer_inrange_textbox.Text);
            int timer_outrange = int.Parse(start_timer_outrange_textbox.Text);
            bool values_accepted = true;

            /*
            if (timer_inrange <= 0 || timer_outrange <= 0)
            {
                MessageBox.Show("Timer values should be more than 1s.", "Value Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            */
            if (timer_inrange <= 0 || timer_inrange > 10)
            {
                MessageBox.Show("Vehicle coming in range timer value is limited between 1-10s inclusive.", "Limited Values", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                values_accepted = false;
                start_timer_inrange_textbox.SelectAll();
            }
            if (timer_outrange < 30 || timer_outrange > 150)
            {
                MessageBox.Show("Vehicle going out of range timer value is limited between 30-150s inclusive.", "Limited Values", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                values_accepted = false;
                start_timer_inrange_textbox.SelectAll();
            }
            if (values_accepted)
            {
                Window1 win1 = new Window1(timer_inrange, timer_outrange);
                win1.Show();
                this.Close();
            }
            e.Handled = true;
        }

        private void start_timer_inrange_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement keyboardFocus = Keyboard.FocusedElement as UIElement;

                if (keyboardFocus != null)
                {
                    keyboardFocus.MoveFocus(tRequest);
                }

                e.Handled = true;
            }
        }

        private void start_timer_outrange_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                start_start_button_Click(sender, e);
            }
        }
    }
}
