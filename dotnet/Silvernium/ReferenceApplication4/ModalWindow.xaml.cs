using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    public partial class ModalWindow
    {
        public ModalWindow(string message)
        {
            InitializeComponent();
            messageTextBlock.Text = message;
            WindowTracker.Instance().Track(this);
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
