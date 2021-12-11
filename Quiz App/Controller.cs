using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Quiz_App
{
    class Controller
    {
        public Progress progress= new Progress();
        public List<Question> questions = new List<Question>();

        public Controller()
        {
            LoadQuestions loader = new LoadQuestions("questions.txt");
            questions = loader.Questions;
            progress.Index = 0;
            progress.MaxQuestions = questions.Count();
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
        public void SaveQuestion(Question q, int item)
        {
            MessageBox.Show(item.ToString());
            progress.SavedAnswers.Add(q, item);
        }
        public int? GetQuestionAnswer(Question q)
        {
            if (progress.SavedAnswers.ContainsKey(q))
            {
                return progress.SavedAnswers[q];
            }
            return null;
        }
    }
}
