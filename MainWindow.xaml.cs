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

namespace U3SportsKeegan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Net.WebClient webClient = new System.Net.WebClient();
            string strNewsFeed;
            string strStory;
            int counter = 1;

            System.IO.StreamReader streamReader = new System.IO.StreamReader(webClient.OpenRead("http://www.cbc.ca/cmlink/rss-sports-nhl"));

            try
            {
                strNewsFeed = streamReader.ReadToEnd();

                while (counter != 20)
                {
                    counter++;
                    strStory = strNewsFeed.Substring(strNewsFeed.IndexOf("<item"), strNewsFeed.IndexOf("</item>") - strNewsFeed.IndexOf("<item"));

                    if (strStory.Contains("Toronto") || strStory.Contains("toronto"))
                    {
                        txbOutput.Text = txbOutput.Text + "\n" + strStory;
                    }

                    strNewsFeed = strNewsFeed.Substring(strNewsFeed.IndexOf("</item>") + 7);
                    
                    //MessageBox.Show(strStory);
                    //MessageBox.Show(strNewsFeed); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
            streamReader.Close();
            MessageBox.Show("I have read everything!");

        }
    }
}
