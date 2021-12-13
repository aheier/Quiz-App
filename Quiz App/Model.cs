using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public enum Type
        {
            Choice,
            TF
        }
        public Type QuestionType { get; set; } 
        public List<string> Choices { get; set; }

        public char Answer { get; set; }
        public string SelectedAnswer { get; set; }

        public Question(int id, string text, bool tf)
        {
            Id = id;
            Text = text;
            Answer = tf ? 'T' : 'F' ;
            QuestionType = Type.TF;
            Choices = new List<string>();
            Choices.Add("True");
            Choices.Add("False");
        }
        public Question(int id, string text, List<string> options, char answer)
        {
            Id = id;
            Text = text;
            Choices = options;
            Answer = answer;
            QuestionType = Type.Choice;
        }

    }

    public class Progress
    {
        public int Index { get; set; }
        public int MaxQuestions { get; set; }

        public int AnseredQuesitons { get; set; }

    }

    public class LoadQuestions
    {
        public string FilePath { get; set; }
        public List<Question> Questions { get; set; }
        public LoadQuestions(string path)
        {
            Questions = new List<Question>();
            try
            {
                LoadQuestionsFromFile(path, Questions);
            }
            catch(FileNotFoundException)
            {
                string text = "1|What Year is it this Year|Choice|A. 2019|B. 2020|C. 2021|D. 2022|C\n"+
                          "2|This class is Awesome.|TF|1";
                File.WriteAllText("questions.txt", text);
                throw new Exception("File not found");
            }
        }
        public void LoadQuestionsFromFile(string path, List<Question> Questions)
        {
            string[] textFile = File.ReadAllLines(path);
            //MessageBox.Show(File.ReadAllText(path));
            foreach (string line in textFile)
            {

                string[] items = line.Split('|');
                try
                {
                    if (items[2].Trim() == "Choice")
                    {
                        List<string> choices = new List<string>();
                        for (int idx = 3; idx < 7; idx++)
                        {
                            choices.Add(items[idx].Trim());
                        }
                        Question q = new Question(
                            id: Convert.ToInt32(items[0].Trim()),
                            text: items[1].Trim(),
                            options: choices,
                            answer: Convert.ToChar(items[7].Trim())
                            );
                        Questions.Add(q);
                    }
                    if (items[2].Trim() == "TF")
                    {
                        Questions.Add(new Question(
                            id: Convert.ToInt32(items[0].Trim()),
                            text: items[1].Trim(),
                            tf: Convert.ToBoolean(Convert.ToInt32(items[3].Trim()))
                            ));
                    }
                }
                catch
                {
                    MessageBox.Show($"A question could not be created: {line}");
                }
            }
        }
        

    }
}

