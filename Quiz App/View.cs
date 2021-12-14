using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Control;

namespace Quiz_App
{
    partial class View : Form
    {
        Controller control;
        Question currentQuestion;
        bool isFinished = false; 
        TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
        int startTime;
        readonly int maxTime = 1800;
        public View()
        {
            InitializeComponent();
            control = new Controller();
            buttonPrevious_Click(new object(), new EventArgs());
            buttonNext.Enabled = false;
            progressBar.Maximum = control.progress.MaxQuestions;
            questionBox.Enabled = false;
            buttonFinish.Enabled = false;
            timer1.Start();
            startTime = (int)t.TotalSeconds;
        }

        public void buttonNext_Click(object sender, EventArgs e)
        {
            currentQuestion = control.GetNextQuestion();
            labelQuestionNumber.Text = currentQuestion.Id.ToString();
            SetQuestion(currentQuestion.Text);
            SetOptions(currentQuestion.Choices);
            if(currentQuestion.SelectedAnswer != null)
            {
                SetOptionsSelectedIndex(currentQuestion.SelectedAnswer);
                SetOptionsCorrectAnswer(currentQuestion);
                return;
            }
            buttonNext.Enabled = false;

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentQuestion = control.GetPreviousQuestion();
            SetQuestion(currentQuestion.Text);
            SetOptions(currentQuestion.Choices);
            SetOptionsSelectedIndex(currentQuestion.SelectedAnswer);
            SetOptionsCorrectAnswer(currentQuestion);
        }
        private void answersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (answersBox.SelectedItem != null)
            {
                if(currentQuestion.SelectedAnswer == null)
                {
                    control.AddProgress();
                }
                currentQuestion.SelectedAnswer = answersBox.SelectedItem.ToString();
                buttonNext.Enabled = true;
                SetProgressBar();
            }
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
        public void SetOptionsSelectedIndex(string index)
        {
            answersBox.SelectedItem = index;
        }
        public void SetOptionsCorrectAnswer(Question q)
        {
            if (!isFinished)
                return;
            foreach(string opt in q.Choices)
            {
                if(opt[0] == q.Answer)
                answersBox.Items.Add($"Correct Answer: {opt}");
            }
        }
        public void SetProgressBar()
        {
            progressBar.Value = control.GetProgress();
            if((progressBar.Value == progressBar.Maximum) && !isFinished)
            {
                buttonFinish.Enabled = true;
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            control.CheckAnswers();
            MessageBox.Show($"Your Scored {control.correctAnswers} / {control.progress.MaxQuestions}");
            control.progress.MaxQuestions = control.questions.Count();
            isFinished = true;
            try
            {
                buttonPrevious_Click(sender, e);
            }
            catch(IndexOutOfRangeException)
            {
                buttonPrevious.Enabled = false;
                buttonNext.Enabled = false;
                buttonFinish.Enabled = false;
            }
            answersBox.Enabled = false;
            buttonFinish.Enabled = false;
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            int current = (int)t.TotalSeconds - startTime;
            labelTimer.Text = $"Time Remaining: {formatTime(maxTime - current)}";
            if (current >= maxTime)
            {
                timer1.Stop();
                buttonFinish_Click(sender, e);
            }
        }
        private string formatTime(int seconds)
        {
            return $"{(seconds/60)}:{String.Format("{0:00}", seconds%60)}";
        }

    }
}
