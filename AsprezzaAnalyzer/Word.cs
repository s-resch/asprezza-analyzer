using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Class containing information of a single word
    /// </summary>
    public class Word
    {      
        /// <summary>
        /// Graphemic Representation of word as found in text
        /// </summary>
        public string graphemeRepresentation { get; set; }


        /// <summary>
        /// Build new word and remove interpunction but keep accents/diacritics using this hint:
        /// https://stackoverflow.com/questions/56279948/remove-special-characters-but-not-accented-letters
        /// </summary>
        /// <param name="graphemeRepresentation">Graphematic representation of word</param>
        public Word(string graphemeRepresentation)
        {
            this.graphemeRepresentation = Regex.Replace(graphemeRepresentation, @"[^A-Za-zÀ-ÖØ-öø-ÿ'\-’]", "");
        }

        /// <summary>
        /// Calculate asprezza value for single word
        /// </summary>
        /// <param name="am">DataSet containing asprezza reules to be applied during calculation</param>
        /// <returns></returns>
        public double GetAsprezzaScale(AsprezzaMapping am)
        {
            double returnValue = 0;

            //Get rules and sort them so we start with longest rules, e.g. "str" before "tr"
            List<AsprezzaRule> tempRules = am.GetMappingTable();
            tempRules.Sort(new AsprezzaRuleComparer());

            //Go through all rules and check if applicable to string
            //If applicable, set asprezzaScale accordingly and delete substring from string to be analyzed
            //This way we avoid double apllications, e.g. "tr" after "str"
            //First delete apostrophe and hyphen -> they are not considered as phonetically relevant separators
            string tempString = Regex.Replace(this.graphemeRepresentation, @"['\-’]", "");

            foreach (AsprezzaRule ar in tempRules)
            {
                if (tempString != "" && tempString.Contains(ar.phoneticRepresentation))
                {
                    if (ar.exactMatch)
                    {
                        if (tempString.Equals(ar.phoneticRepresentation))
                        {
                            returnValue += ar.asprezzaValue;
                            tempString = tempString.Replace(ar.phoneticRepresentation, "");
                        }
                    }
                    else
                    {
                        returnValue += ar.asprezzaValue;
                        tempString = tempString.Replace(ar.phoneticRepresentation, "");
                    }
                }
            }
            
            return returnValue;
        }
    }
}
