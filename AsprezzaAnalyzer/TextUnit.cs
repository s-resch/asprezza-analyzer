using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Class encapsulating textual unit, e.g. Canto of Divina Commedia
    /// </summary>
    public class TextUnit
    {
        /// <summary>
        /// Name identifying textual unit, e.g. "Inferno, I"
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// List of lines contained in textual unit
        /// </summary>
        public List<Line> Lines { get; set; }

        public TextUnit(string name, List<string> lines)
        {
            this.Identifier = name;
            this.Lines = new List<Line>();
            for(int i = 0; i < lines.Count; i++)
            {
                this.Lines.Add(new Line(i + 1, lines[i]));
            }
        }        
    }
}
