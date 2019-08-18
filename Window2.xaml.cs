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
using System.Configuration;

namespace ParsingCars
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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
            if(makeComboBox.Text == audi)
            {
                doc1.Load("audi.xml");
            }
            else if(makeComboBox.Text == bmw)
            {
                doc1.Load("bmw.xml");
            }
            else if(makeComboBox.Text == acura)
            {
                doc1.Load("acura.xml");
            }
        }
        
        private bool VehicleExists(XmlDocument doc1)
        {
            LoadMakeXML(doc1);
            //checks if input already exists in xml file
            foreach (XmlNode node in doc1.DocumentElement)
            {
                string ModelName = node.Attributes[0].InnerText;
                if (ModelName == modelTextbox.Text)
                {
                    MessageBox.Show("Entry already exists");
                    return true;
                }

            }
            return false;
        }

        //adds and saves new make and model to xml file
        private void AddModelUnderExistingMake()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");
            string audi = "Audi";
            string bmw = "BMW";
            string acura = "Acura";
            if(makeComboBox.Text == audi)
            {
                XmlNode xmakename = doc.SelectSingleNode(@"/Cars/Make[@MakeName='Audi']");
                XmlNode xmodel = doc.CreateElement("Model");
                xmodel.InnerText = modelTextbox.Text;
                xmakename.AppendChild(xmodel);
            }
            else if(makeComboBox.Text == bmw)
            {
                XmlNode xmakename = doc.SelectSingleNode(@"/Cars/Make[@MakeName='BMW']");
                XmlNode xmodel = doc.CreateElement("Model");
                xmodel.InnerText = modelTextbox.Text;
                xmakename.AppendChild(xmodel);
            }
            else if(makeComboBox.Text == acura)
            {
                XmlNode xmakename = doc.SelectSingleNode(@"/Cars/Make[@MakeName='Acura']");
                XmlNode xmodel = doc.CreateElement("Model");
                xmodel.InnerText = modelTextbox.Text;
                xmakename.AppendChild(xmodel);
            }
            doc.Save("cars.xml");
            doc.Save(@"C:\Users\ZackF\source\repos\ParsingCars\ParsingCars\cars.xml");
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {

            XmlDocument doc1 = new XmlDocument();
            LoadMakeXML(doc1);
            //declared flag variables
            bool flag1 = VehicleExists(doc1);
            
            if (flag1 == true)
            {
                return;
            }

            AddModelUnderExistingMake();

            //hides main window displays second window
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}
