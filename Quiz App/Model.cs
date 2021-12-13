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
                File.WriteAllText("questions.txt", exampleQuestions);
                MessageBox.Show("File not found, Creating Sample questions");
                LoadQuestionsFromFile(path, Questions);
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
        

        string exampleQuestions = 
            @"1 | What is the longest that an elephant has ever lived? (That we know of) | Choice | A. 49 years| B. 86 years| C. 142 years| D. 17 years | B
            2 | In 1768, Captian James Cook set out to explore what ocean? | Choice | A.Pacific Ocean | B.Atlantic Ocean  | C.Indian Ocean | D.Artic Ocean | A
            3 | What is actually electricity?  | Choice | A.A flow of water  | B.A flow of air | C.A flow of electrons | D.A flow of atoms | C
            4 | Which of the follwing is not an international organisation? | Choice | A.FIFA | B.NATO | C.ASEAN | D.FBI | D
            5 | Which of the ofllowing disorders is the fear of being alone? | Choice | A.Agoraphobia| B.Aerophobiea | C.Acrophobia | D.Arachnophobia|A
            6 | Which of hte follwing is a song by the german heav metal band ""Scorpions""? | Choice | A.Stairway to Heaven | B.Wind of Change| C.Don't Stop Me Now| D. Hey Jude| B
            7 | What is the speed of sound? | Choice | A. 120 km/h | B. 1,200 km/h | C. 400 km/h | D. 700 km/h |B
            8 | Which is the easiest way to tell the age of many trees? | Choice | A.To measure the width of the tree | B.To count the rings on the trunk | C.To count the number of leaves| D.To measure the height of the tree|B
            9 | What do we call a newly hatched butterfly? | Choice | A.A moth | B.A butter| C.A caterpillar | D.A chysalis|C
            10 | In total, how many novels were written by the Bronte sisters? | Choice | A. 4 | B. 5| C.6| D.7|D
            11 | What did Viking people use as money? | Choice | A.Rune stones | B.Jewellery | C.Seal skins | D.Wool| B
            12 | What was the first contry to use tanks in combat during World War I? | Choice | A.France | B.Japan | C.Britain | D.Germany | C
            13 | What is the main component of the sun? | Choice | A.Liquid lava| B.Gas| C.Molten Iron| D.Rock| B
            14 | Goulash is a type of beef soup in which country? | Choice | A.Hungary | B.Czech Republic | C.Slovakia| D.ireland|A
            15 | Which two months are named after Emperors of the Roman Empire? | Choice | A.january and February | B.March and April | C.May and June | D.July and August |D
            16 | The Caribbean Island of Aruba is part of Portugal | TF |0
            17 | In the animation film ""Finding Nemo,"" the main protagonist is a pufferfish. | TF |0
            18 | Is Mount Kilimanjaro the world's talles peak? | TF |0
            19 | Spaghetto is the singular form of the word spaghetti. | TF |1
            20 | Pinoccio was Walt Disney's first animated feature film in full color. | TF |0
            21 | Venezuela is home to the world's highest waterfall. | TF |1
            22 | Coffee is a berry-based beverage. | TF |1
            23 | The capital of Australia is Sydney | TF |0
            24 | The longest river in the world is the Amazon River | TF |0
            25 | polar bears can only live in the Artic rgion, not in the Antartic | TF |1";
    }
}

