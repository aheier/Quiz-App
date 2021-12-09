using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_App
{
    class Controller
    {
        public Model.Progress progress= new Model.Progress();
        public List<Model.Question> questions = new List<Model.Question>();

        public Controller()
        {
            Model.LoadQuestions loader = new Model.LoadQuestions("questions.txt");
            questions = loader.Questions;
        }

        public void printQuesitons()
        {
            foreach(Model.Question q in questions)
            {
                MessageBox.Show($"{q.Id} {q.Text}");
            }
        }
    }
}
