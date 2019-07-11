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
using System.Xml;

namespace ParsingCars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMakes();
        }

        private void LoadMakes()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string MakeName = node.Attributes[0].Value;
                dropDownList.Items.Add(MakeName);
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string MakeName = node.Attributes[0].InnerText;
                if (MakeName == dropDownList.Text)
                {
                    //clears list
                    searchResults.Items.Clear();
                    //adds models of selected make to list
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        searchResults.Items.Add(child.InnerText);
                    }
                }
            }
        }

        /*  private void Button_Click(object sender, EventArgs e)
          {
              if(searchInput.Text != null)
              {
                  XmlDocument doc = new XmlDocument();
                  doc.Load("cars.xml");

                  foreach(XmlNode node in doc.DocumentElement)
                  {
                      string name = node.Attributes[0].InnerText;
                      if(name == searchInput.Text)
                      {
                          foreach(XmlNode child in node.ChildNodes)
                          {
                              searchResults.Items.Add(child.InnerText);
                          }
                      }
                  }
              }
              else
              {
                  MessageBox.Show("Invalid Input");
              }
          }*/

    }
}
