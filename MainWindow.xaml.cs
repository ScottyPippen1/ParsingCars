﻿using System;
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
using System.IO;

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

        private void Search_XML(XmlDocument count)
        {
            foreach (XmlNode node in count.DocumentElement)
            {
                string ModelName = node.Attributes[0].InnerText;
                if (ModelName == searchResults.SelectedItem.ToString())
                {
                    //clears list
                    modelDetails.Items.Clear();
                    //adds details for selected model
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        modelDetails.Items.Add(child.InnerText);
                    }
                }
            }
        }
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            //loads xml file
            XmlDocument doc = new XmlDocument();
            doc.Load("cars.xml");

            //parses through xml file elements
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

        private void searchResults_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //loads xml file
            XmlDocument doc1 = new XmlDocument();
            XmlDocument doc2 = new XmlDocument();
            XmlDocument doc3 = new XmlDocument();
            doc1.Load("audi.xml");
            doc2.Load("bmw.xml");
            doc3.Load("acura.xml");
            //checks if searchResults is empty
            if (searchResults.Items.Count == 0)
            {
                return;
            }
            Search_XML(doc1);
            Search_XML(doc2);
            Search_XML(doc3);
        }
    }
}
