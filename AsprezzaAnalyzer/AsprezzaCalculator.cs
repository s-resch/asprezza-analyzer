using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    public class AsprezzaCalculator
    {
        private AsprezzaResultSet result;

        public AsprezzaCalculator()
        {
            this.result = new AsprezzaResultSet();
        }

        public AsprezzaResultSet CalulateAsprezza(List<string> textsToCalculate, List<TextUnit> textUnitsToProcess)
        {
            //Load mapping rules
            AsprezzaMapping am = new AsprezzaMapping();

            //Re-Initialize storage for analysis (important in case we already have data stored there)
            this.result = new AsprezzaResultSet();

            foreach (string s in textsToCalculate)
            {
                //Get TextUnit that corresponds to selected text in listbox
                //Actually, we should get only one result but, technically, we have to store value in list
                List<TextUnit> tempTextUnit = textUnitsToProcess.Where(unit => unit.Identifier == s).ToList();

                //Go through all lines of TextUnit and then through every single word of single lines
                //Calculate asprezza for every single word and add data to local stotrage for results
                foreach (TextUnit tu in tempTextUnit)
                {
                    foreach (Line l in tu.Lines)
                    {
                        foreach (Word w in l.Words)
                        {
                            double asp = w.GetAsprezzaScale(am);

                            //If word is at last position of line (i.e. at rhyme position), increase asprezza value
                            if (l.Words.IndexOf(w) == l.Words.Count - 1 && asp > 0)
                                asp *= decimal.ToDouble(Properties.Settings.Default.multiplicatorRhyme);

                            this.result.dataAsprezza.Add(asp);
                            this.result.dataWordName.Add(w.graphemeRepresentation);
                            this.result.dataLables.Add(tu.Identifier + "-" + w.graphemeRepresentation);
                        }
                    }
                }
            }

            return this.result;
        }
    }


    /// <summary>
    /// Encapsulation for all asprezza data needed to process calculation and plot
    /// </summary>
    public class AsprezzaResultSet
    {
        /// <summary>
        /// List to store results of asprezza calculation for each single word
        /// </summary>
        public List<double> dataAsprezza  { get; set; }

        /// <summary>
        /// List to store single words to be analyzed or having been analyzed
        /// </summary>
        public List<string> dataWordName { get; set; }

        /// <summary>
        /// List to store lables to be displayed to user for each single word
        /// </summary>
        public List<string> dataLables { get; set; }

        /// <summary>
        /// Construct a new AsprezzaResultSet
        /// </summary>
        public AsprezzaResultSet()
        {
            this.dataAsprezza = new List<double>();
            this.dataLables = new List<string>();
            this.dataWordName = new List<string>();
        }
    }
}
