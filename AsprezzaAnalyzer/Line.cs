using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Class encapsulating single line of TextUnit
    /// </summary>
    public class Line
    {
        public int LineNumber { get; set; }
        public List<Word> Words { get; set; }

        public Line(int number, string line)
        {
            this.LineNumber = number;
            this.Words = new List<Word>();
            string[] words = line.Split(' ');
            foreach(string s in words)
            {
                this.Words.Add(new Word(s));
            }
        }
    }
}
