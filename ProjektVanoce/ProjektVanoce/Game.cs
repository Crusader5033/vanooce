using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ProjektVanoce
{
    internal class Game
    {
        private string filePath;
        private List<Question> list = new List<Question>();

        public string FilePath { get => filePath; set => filePath = value; }
        internal List<Question> List { get => list; set => list = value; }

        public Game(string filePath)
        {
            this.filePath = filePath;
            this.list = new List<Question>();


        }

        public void LoadQuest() // nacitam otazky ze souboru a ukladam do listu 
        {



            using (StreamReader reader = new StreamReader(this.filePath+".txt"))
            {
                string line;



                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Length == 0) // v pripade ze je radek prazdny preskoc loop 
                        continue;


                    Question question = new Question(); // vytvarim otazku 


                    question.Text = line;

                    question.Choices = new string[]
                    {

                          reader.ReadLine(),
                          reader.ReadLine(),
                          reader.ReadLine(),
                          reader.ReadLine(),
                          reader.ReadLine()

                };

                    this.findRightAnswer(question);


                    this.list.Add(question); 
                }
            }

        }


        public void findRightAnswer(Question q)//kontroluji a zjistuji spravnou odpoved urcenou !
        {
            q.Answer.Add(-1); // defaultne dávám -1,tedy odpoved nenalezena ;


            for (int i = 0; i < q.Choices.Length; i++) // procházim odpovedi,hledam spravnou ,ukladam do listu v pripade ze bude vice spravnych
            {
                if (q.Choices[i].StartsWith("!"))
                {

                    q.Choices[i] = q.Choices[i].Substring(1);
                    q.Answer.RemoveAt(0);
                    q.Answer.Add(i);    
                    
                }
            }



            if (q.Answer.Contains(-1) ) // vyjimky kontroluje aby nebyla otazka bez odpovedi
            {
                throw new InvalidOperationException
                    ("No correct answer");
            }

        }



        public string toString(int i) // vypis jedne otazky
        {
            string result = this.list[i].Text + "\n";

            for (int j = 0; j < this.List[i].Choices.Length; j++)
            {

               
                 result += (j + 1) + ". " + list[i].Choices[j] + "\n";
                
 
                   
                
               
            }
            return result;
        }

        public bool IsCorrect(int guess,int i)
        {

            if (this.List[i].Answer.Contains(guess - 1)) // kontrola zdali je odpoved v listu spravnych odpovedi
            {

                return true;
            }
            return false;

        }

        public string Percantage(int score, int numOfQues)
        {
          
            return "Your succes percentage is"+ (Convert.ToDouble( score) / Convert.ToDouble(numOfQues))*100+"%"; 
        }







    }
}
