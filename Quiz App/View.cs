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
        readonly int maxTime = 450;
        int totalQuestions = 0;
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
            totalQuestions = control.progress.MaxQuestions;
        }

        public void buttonNext_Click(object sender, EventArgs e)
        {
            buttonPrevious.Enabled = true;
            currentQuestion = control.GetNextQuestion();
            SetQuestion(currentQuestion.Text);
            SetOptions(currentQuestion.Choices);
            SetQuestionCounter(currentQuestion);
            if (currentQuestion.SelectedAnswer != null)
            {
                SetOptionsSelectedIndex(currentQuestion.SelectedAnswer);
                SetOptionsCorrectAnswer(currentQuestion);
                if (currentQuestion.Id == control.questions[control.questions.Count -1].Id)
                    buttonNext.Enabled = false;
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
            SetQuestionCounter(currentQuestion);
            if (currentQuestion.Id == control.questions[0].Id)
                buttonPrevious.Enabled = false;
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
                if (currentQuestion.Id == control.questions[control.questions.Count - 1].Id)
                    buttonNext.Enabled = false;
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
                //answersBox.Items[answersBox.Items.Count-1].BackColor 
            }
        }
        public void SetQuestionCounter(Question q)
        {
            labelQuestionNumber.Text = $"{q.Id} / {totalQuestions}";
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
