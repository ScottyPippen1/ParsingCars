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
using System.Xml;

namespace ParsingCars
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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
                makeComboBox.Items.Add(MakeName);
            }
        }

        private void LoadMakeXML(XmlDocument doc1)
        {

            string audi = "Audi";
            string bmw = "BMW";
            string acura = "Acura";
            if (makeComboBox.Text == audi)
            {
                doc1.Load("audi.xml");
            }
            else if (makeComboBox.Text == bmw)
            {
                doc1.Load("bmw.xml");
            }
            else if (makeComboBox.Text == acura)
            {
                doc1.Load("acura.xml");
            }
        }

     /*   private bool VehicleDoesNotExist(XmlDocument doc1)
        {
            LoadMakeXML(doc1);
            //checks if input exists in xml file
            foreach (XmlNode node in doc1.DocumentElement)
            {
                string ModelName = node.Attributes[0].InnerText;
                if (ModelName != modelTextbox.Text)
                {
                    MessageBox.Show("Entry does not exist");
                    return true;
                }

            }
            return false;
        }*/

        private void RemoveModelUnderExistingMake()
        {
            //loads xml file
            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");

            bool flag = false;

            //parses through xml file elements
            foreach (XmlNode node in doc.SelectNodes("//Make/Model"))
            {
                if (node.InnerText == modelTextbox.Text)
                {
                    node.ParentNode.RemoveChild(node);
                    flag = true;
                    break;
                }  
            }
            if(flag == false)
            {
                MessageBox.Show("Model does not exist");
            }
            doc.Save("cars.xml");
            doc.Save(@"C:\Users\ZackF\source\repos\ParsingCars\ParsingCars\cars.xml");
        }
        private void RemoveVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            LoadMakeXML(doc1);
            //declared flag variables
         /*   bool flag1 = VehicleDoesNotExist(doc1);

            if (flag1 == true)
            {
                return;
            }*/

            RemoveModelUnderExistingMake();





            //hides remove vehicle window displays main window
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}
