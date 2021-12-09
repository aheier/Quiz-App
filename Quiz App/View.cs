using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Quiz_App
{
    partial class View : Form
    {
        Controller control;
        public View()
        {
            InitializeComponent();
            control = new Controller();
        }

        public void buttonNext_Click(object sender, EventArgs e)
        {
            questionBox.Text = "HI click ";

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Question q = control.GetPreviousQuestion();
            SetQuestion(q.Text);
            SetOptions(q.Choices);
        }
        private void answersBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SetQuestion(string question)
        {
            questionBox.Text = question;
        }
        public void SetOptions(List<string> options)
        {
            answersBox.Items.Clear();
            foreach (string option in options)
            {
                answersBox.Items.Add(option);
            }
        }

    }
}
