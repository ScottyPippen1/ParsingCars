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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private bool VehicleExists(XmlDocument exists)
        {
            
            foreach (XmlNode node in exists.DocumentElement)
            {
                string ModelName = node.Attributes[0].InnerText;
                if (ModelName == modelTextbox.Text)
                {
                    return true;
                }

            }
            return false;
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            //loads xml file
            XmlDocument doc1 = new XmlDocument();
            XmlDocument doc2 = new XmlDocument();
            XmlDocument doc3 = new XmlDocument();
            doc1.Load("audi.xml");
            doc2.Load("bmw.xml");
            doc3.Load("acura.xml");

            //calls xml file when model selected
            VehicleExists(doc1);
            VehicleExists(doc2);
            VehicleExists(doc3);

            bool flag1 = VehicleExists(doc1);
            bool flag2 = VehicleExists(doc2);
            bool flag3 = VehicleExists(doc3);

            if (flag1 == false)
            {
                return;
            }
            if (flag2 == false)
            {
                return;
            }
            if (flag3 == false)
            {
                return;
            }

            string makeName = makeTextbox.Text;

            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");
            XmlNode make = doc.CreateElement("Make");
            XmlAttribute newAttribute = doc.CreateAttribute("MakeName");
            XmlNode model = doc.CreateElement("Model");
            newAttribute.Value = makeName;
            make.Attributes.Append(newAttribute);
            model.InnerText = modelTextbox.Text;
            make.AppendChild(model);
            doc.DocumentElement.AppendChild(make.Clone());
            doc.Save("cars.xml");

            MainWindow objMainWindow = new MainWindow();
            //hides main window displays second window
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}
