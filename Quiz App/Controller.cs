using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Control
{
    class Controller
    {
        public Progress progress= new Progress();
        public List<Question> questions = new List<Question>();
        public int correctAnswers = 0;
        public List<Question> wrongAnswers = new List<Question>();

        public Controller()
        {
            LoadQuestions loader;
            try
            {
                loader = new LoadQuestions("questions.txt");
                questions = loader.Questions;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            progress.Index = 0;
            progress.MaxQuestions = questions.Count();
        }
        public void AddProgress()
        {
            progress.AnseredQuesitons++;
        }
        public int GetProgress()
        {
            return progress.AnseredQuesitons;
        }
        public void printQuesitons()
        {
            foreach(Question q in questions)
            {
                MessageBox.Show($"{q.Id} {q.Text}");
            }
        }
        public Question GetPreviousQuestion()
        {
            if (progress.Index == 0)
            {
                return questions[0];
            }
            progress.Index -= 1;
            return questions[progress.Index];
        }
        public Question GetNextQuestion()
        {
            if (progress.Index == progress.MaxQuestions-1)
            {
                return questions[progress.Index];
            }
            progress.Index += 1;
            return questions[progress.Index];
        }
        public void CheckAnswers()
        {
            correctAnswers = 0;
            wrongAnswers = new List<Question>();
            foreach(Question q in questions)
            {
                if(q.SelectedAnswer == null)
                {
                    q.Choices.Add("No answer given");
                    q.SelectedAnswer = "No answer given";
                    wrongAnswers.Add(q);
                    continue;
                }
                if(q.Answer == q.SelectedAnswer[0])
                {
                    correctAnswers++;
                }
                else
                {
                    wrongAnswers.Add(q);
                }
            }
            questions = wrongAnswers;
            progress.Index = 0;
            
        }
    }
}
