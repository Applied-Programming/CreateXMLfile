using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CreateXMLfile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter("C:\\Users\\HP\\Desktop\\xDoc1.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("People");//People
            writer.WriteStartElement("Person");//Person
            writer.WriteStartElement("Name"); //<Name>
            writer.WriteString(textBox1.Text); //textbox1.Text
            writer.WriteEndElement(); //</Name>
            writer.WriteStartElement("Age"); //<Age>
            writer.WriteString(numericUpDown1.Value.ToString()); //numericUpDown1.Value
            writer.WriteEndElement(); //</Age>
            writer.WriteStartElement("Email"); //<Email>
            writer.WriteString(textBox2.Text); //textbox2.Text
            writer.WriteEndElement(); //</Email>
            writer.WriteEndElement(); //</Person>
            writer.WriteEndElement(); //</People>
            writer.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("C:\\Users\\HP\\Desktop\\xDoc1.xml");
            XmlNode person = xdoc.CreateElement("Person");
            XmlNode name = xdoc.CreateElement("Name");
            name.InnerText = textBox1.Text;
            person.AppendChild(name);
            XmlNode age = xdoc.CreateElement("Age");
            age.InnerText = numericUpDown1.Value.ToString();
            person.AppendChild(age);
            XmlNode email = xdoc.CreateElement("Email");
            email.InnerText = textBox2.Text;
            person.AppendChild(email);
            xdoc.DocumentElement.AppendChild(person);
            xdoc.Save("C:\\Users\\HP\\Desktop\\xDoc1.xml");
        }
    }
}
