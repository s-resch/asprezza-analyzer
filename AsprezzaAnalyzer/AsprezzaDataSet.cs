using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Currently not in use
    /// </summary>
    public class AsprezzaDataSet
    {
        public int identifier { get; set; }
        public string word { get; set; }
        public double asprezzaScale { get; set; }

        public AsprezzaDataSet(int id, string word, double asprezza)
        {
            this.identifier = id;
            this.word = word;
            this.asprezzaScale = asprezza;
        }
    }
}
