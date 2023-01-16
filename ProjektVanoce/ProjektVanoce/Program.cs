using System.Linq.Expressions;

namespace ProjektVanoce
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
             
            Console.WriteLine(" 1.Game\n 2.Editor");
            int choice = 0;

            while (true)
            {
                try
                {
                     choice = Convert.ToInt32(Console.ReadLine());// vyber mezi editorem a hrou
                    Console.WriteLine("Zadej odpoved"  );
                    Console.WriteLine();
                    break; 
                }
                catch(Exception ex)
                {
                    Console.Write("Zadej cele cislo"+ex);
                    Console.WriteLine();
                }
            }

           

            
            
            
             
           


            if (choice == 1) // hra
            {
               
                Console.WriteLine("Choose quiz(file name)default \"Game1\" : "); // vyber souboru ze ktereho se kviz nacte
             string file = Console.ReadLine();
                
                Game g = new Game(file);
                g.LoadQuest();
                int score = 0;

                Console.Write("Your answer(just number of answer -> 1 ,2 , 3 ...) : ");
                Console.WriteLine();

                for (int i = 0; i < g.List.Count; i++) // vypisuji otazky a ziskavam odpoved
                {
                    int guess;
                    Console.WriteLine(g.toString(i));
                    guess = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    if( g.IsCorrect(guess, i))
                    {
                        score++;
                        Console.WriteLine("Correct");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect");
                    }
 
                }
                Console.WriteLine();
                Console.WriteLine(g.Percantage(score,g.List.Count));
               
            }
            






            if(choice == 2) // editor
            {
                string fileName;
                Console.WriteLine("Name of a file made: ");
                fileName = Console.ReadLine();

                Console.WriteLine("Number of questions? ");
                int num = Convert.ToInt32(Console.ReadLine());



                using (StreamWriter writer = new StreamWriter(fileName+".txt"))
                   {

                    for (int i = 0; i < num; i++)  // zapisuji podle poctu otazek 
                    {

                        string question;
                        string answer;
                        int number;

                        Console.WriteLine("Question: "); // zapis otazky
                        question = Console.ReadLine();
                        Console.WriteLine("Number of answers min 2 max 5: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write ! before the right answer");
                        writer.WriteLine(question);



                        for (int j = 0; j < number; j++) // zapis moznych odpovedi
                        { Console.WriteLine("Answer n." + (j + 1) + ": ");
                            answer = Console.ReadLine();
                            writer.WriteLine(answer);



                        };
                        switch (number)
                        {
                            case 1:
                                throw new Exception("Atleast 2 answers");
                                break;
                            case 2:
                                for(int j = 0; j < 4; j++)
                                {
                                    writer.WriteLine();
                                }
                                break;
                            case 3:
                                for (int j = 0; j < 3; j++)
                                {
                                    writer.WriteLine();
                                }
                                break;
                            case 4:
                                for (int j = 0; j < 2; j++)
                                {
                                    writer.WriteLine();
                                }
                                break;
                            case 5:
                                
                                    writer.WriteLine();
                                break; 
                                
                        }









                    } 
                    
                            

                        

                }

             


            }








        }
    }
}