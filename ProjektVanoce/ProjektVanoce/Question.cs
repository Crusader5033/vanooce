using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektVanoce
{
    internal class Question
    {
        private string text;
        private string[] choices;
        private List<int> answer = new List<int>();

        public Question()
        {

        }

        public string Text { get => text; set => text = value; }
        public string[] Choices { get => choices; set => choices = value; }
        public List<int> Answer { get => answer; set => answer = value; }

       
    }
}
