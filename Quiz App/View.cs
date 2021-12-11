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
        Question currentQuestion;
        int currentAnswer;
        public View()
        {
            InitializeComponent();
            control = new Controller();
        }

        public void buttonNext_Click(object sender, EventArgs e)
        {
            currentQuestion = control.GetNextQuestion();
            SetQuestion(currentQuestion.Text);
            SetOptions(currentQuestion.Choices);

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentQuestion = control.GetPreviousQuestion();
            if(control.GetQuestionAnswer(currentQuestion) != null)
            {
                currentAnswer = (int)(control.GetQuestionAnswer(currentQuestion));
            }
            SetQuestion(currentQuestion.Text);
            SetOptions(currentQuestion.Choices);
            SetOptionsSelectedIndex(currentAnswer);
        }
        private void answersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.SaveQuestion(currentQuestion, answersBox.SelectedIndex);
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
        public void SetOptionsSelectedIndex(int index)
        {
            answersBox.SelectedIndex = index;
        }
    }
}
