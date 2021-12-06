using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Maslov_Bot_Kursov.Pages.Bot
{
    class BotClass
    {
       public string name;
        public bool firstTime;
       public string img;
        public string design;


        public Tuple<string, bool> Chat(string userText)
        {
            List<string> words;
            words = WordsReader();
            string[] vs;
            foreach (var word in words)
            {
                vs = word.Split(':');
                if (userText == vs[0])
                {
                    return Tuple.Create(vs[1], true);
                }
            }
            string answer = "Я не знаю как ответить на фразу ' "+ userText + " '.\n Напишите пожалуйста ответ, чтобы в следующий раз я смог ответить.";
            return Tuple.Create(answer, false);
        }



        public void NewMessageReg(string userText, string userAnswer)
        {
            List<string> words = WordsReader();
            words.Add(userText + ":" + userAnswer);
            WordsWriter(words);
            return;
        }



        private List<string> WordsReader()
        {
            List<string> mass = new List<string>();

          
            using (StreamReader sr = new StreamReader("BotWords.txt"))
            {
     
                while (sr.EndOfStream != true)
                {
                    mass.Add(sr.ReadLine());
               
                }
                sr.Close();
            }
            
            return mass;
        }




        private void WordsWriter(List<string> newmass)
        {

            using (StreamWriter wr = new StreamWriter("BotWords.txt"))
            {

                foreach (var word in newmass)
                {
                    wr.WriteLine(word);

                }
                wr.Close();
            }

            return;
        }

        

       public void CreateState()
        {
            using (StreamWriter sw = new StreamWriter("BotState.txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(firstTime);
                sw.WriteLine(img);
                sw.WriteLine(design);
                sw.Close();
            }
        }

       public void GetState()
        {
            using (StreamReader sr = new StreamReader("BotState.txt"))
            {
                name = sr.ReadLine();
                firstTime = Convert.ToBoolean(sr.ReadLine());
                img = sr.ReadLine();
                design = sr.ReadLine();
                sr.Close();
            }
        }

        
    }
}
