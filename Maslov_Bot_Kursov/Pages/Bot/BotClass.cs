using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Maslov_Bot_Kursov.Pages.Bot
{
    class BotClass
    {
       public string name;
       public int rep;
       public string img;

        private void Chat()
        {
            return;
        }

        private void Advice()
        {
            return;
        }

       public void CreateState()
        {
            using (StreamWriter sw = new StreamWriter("BotState.txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(rep);
                sw.WriteLine(img);
            }
        }

       public void GetState()
        {
            using (StreamReader sr = new StreamReader("BotState.txt"))
            {
                name = sr.ReadLine();
                rep = Convert.ToInt32(sr.ReadLine());
                img = sr.ReadLine();
            }
        }

        
    }
}
