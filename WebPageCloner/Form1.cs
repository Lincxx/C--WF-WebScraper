using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebPageCloner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "HTML file (*html)|*.html";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }



            string URL = textBoxURL.Text; //getting the text from the text box
            HtmlWeb hw = new HtmlWeb(); //this will help us load the htmt doc

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = hw.Load(URL);

            using (StreamWriter fw = new StreamWriter(filePath))
            {
                fw.Write(doc.ParsedText);
            }
            MessageBox.Show("Awesome you downloaded the page");



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string URL = textBoxURL.Text; //getting the text from the text box
            HtmlWeb hw = new HtmlWeb(); //this will help us load the htmt doc

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            
            //loaded doc
            doc = hw.Load(URL);

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a"))
            {
                listBox1.Items.Add(link.GetAttributeValue("href", ""));
            }

            
        }
    }
}
