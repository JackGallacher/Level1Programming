﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Workshop_14
{
    public delegate void clickDelegate();//Function reference to our delegate event.

    public partial class Form1 : Form
    {
        string FileName;
        string About = "Simple Windows Form example.";

        public event clickDelegate clickEvent;

        private void customButtonClick(object sender, EventArgs e)//This creates a custom event, this is not tied to a button.
        {
            MessageBox.Show("customButtonClick is called.");//Displays a MessageBox.
        }

        private void newCustomClickEvent()//Defines an event.
        {
            MessageBox.Show("newCustomClickEvent: Application has started.");
        }

        public Form1()
        {
            InitializeComponent();
            CustomEvent.Click += new EventHandler(customButtonClick);//This links our custom event to a new EventHandler and then adds it to a button we have created.
            clickEvent += new clickDelegate(newCustomClickEvent);//Creates a new event from our delegate.
            clickEvent();//Fires our new event.
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 AboutForm = new Form2(About);//Inits Form 2 with the About string.
            AboutForm.ShowDialog();//Displays Form2, "ShowDialog" ensures the window is handled exclusivly and allows features such as "DialogResult" to be used.
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();//Displays the file browser.
            file.Title = "Open";
            file.Filter = "TXT files|*.txt|PHP files|*.php|HTML files|*.html|CS files|*.cs";//Sets which files are visible and can be opened by this application.
            file.InitialDirectory = @"C:\";

            if (file.ShowDialog() == DialogResult.OK)
            {
                FileName = file.FileName;
                StreamReader inputFile = new StreamReader(file.FileName);//Reads the current file into the application.
                richTextBox1.Text = inputFile.ReadToEnd();
                inputFile.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FileName, richTextBox1.Text);//Writes the current contents of the text box to the chosen file.
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Closes the application when the exit button is pressed.
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();//Clears the text box when the "Clear" button is pressed.
        }

        private void signatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 SignatureWindow = new Form3();
            if (SignatureWindow.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = Form3.Signature;//Sets the text to the signature value in Form3.
            }
        }
    }
}
