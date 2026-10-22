using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.ebay.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (driver == null)
                return;

            IWebElement searchField = driver.FindElement(By.Id("gh-ac"));
            searchField.Clear();
            searchField.SendKeys(textBox1.Text);
            driver.FindElement(By.Id("gh-search-btn")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.Url.Contains("/sch/"));

            textBox2.Text = driver.Url;
            richTextBox1.AppendText(driver.Url + "\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (driver != null)
                driver.Navigate().Back();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseBrowser();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (driver != null)
                driver.Url = e.LinkText;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseBrowser();
        }

        private void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
