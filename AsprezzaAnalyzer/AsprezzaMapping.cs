using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Class containing all Asprezza Rules to be applied during asprezza analysis
    /// </summary>
    public class AsprezzaMapping
    {
        List<AsprezzaRule> mappingTable;

        /// <summary>
        /// Get mapping table with all rules to be applied during asprezza analysis
        /// </summary>
        /// <returns>List containing all rules to be applied during asprezza analysis</returns>
        public List<AsprezzaRule> GetMappingTable()
        {
            return this.mappingTable;
        }

        public AsprezzaMapping()
        {
            mappingTable = new List<AsprezzaRule>();

            Dictionary<string, string> rules = ConfigExtractor.ParseAsprezzaRules();

            foreach(KeyValuePair<string, string> keyValuePair in rules)
            {
                // Add Rule to mapping table; solve double parsing problem with following hint:
                // https://stackoverflow.com/questions/19295560/language-invariant-double-tostring
                mappingTable.Add(new AsprezzaRule(keyValuePair.Key, Double.Parse(keyValuePair.Value, CultureInfo.InvariantCulture)));
            }
        }

    }

    /// <summary>
    /// DataSet that contains a rule to be applied during asprezza analysis
    /// </summary>
    public class AsprezzaRule
    {
        public string phoneticRepresentation { get; set; }
        public double asprezzaValue { get; set; }
        public bool exactMatch { get; set; }

        public AsprezzaRule(string s, double i, bool exact = false)
        {
            this.phoneticRepresentation = s;
            this.asprezzaValue = i;
            this.exactMatch = exact;
        }
    }

    /// <summary>
    /// Helper class to compare to AsprezzaRules so we can sort them
    /// We need to apply, at first, rules that defines transformation of long strings
    /// </summary>
    class AsprezzaRuleComparer : IComparer<AsprezzaRule>
    {
        public int Compare(AsprezzaRule x, AsprezzaRule y)
        {
            if (x.phoneticRepresentation.Length == y.phoneticRepresentation.Length)
            {
                return x.phoneticRepresentation.CompareTo(y.phoneticRepresentation);
            }
            else return (x.phoneticRepresentation.Length.CompareTo(y.phoneticRepresentation.Length) * -1);
        }
    }
}
