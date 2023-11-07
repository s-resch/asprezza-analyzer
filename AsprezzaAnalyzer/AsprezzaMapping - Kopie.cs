using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Class containing all Asprezza Rules to be applied during asprezza analysis
    /// </summary>
    class AsprezzaMapping
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

            //TO-DO: Read mapping rules from config file
            //Add other rules such as Rhyme Position factor and syllabification
            mappingTable.Add(new AsprezzaRule("bb", 1.5));
            mappingTable.Add(new AsprezzaRule("cc", 2));
            mappingTable.Add(new AsprezzaRule("cci", 3));
            mappingTable.Add(new AsprezzaRule("lz", 3.5));
            mappingTable.Add(new AsprezzaRule("nc", 2.5));
            mappingTable.Add(new AsprezzaRule("ngi", 3));
            mappingTable.Add(new AsprezzaRule("ns", 1.5));
            mappingTable.Add(new AsprezzaRule("pr", 3));
            mappingTable.Add(new AsprezzaRule("rr", 1));
            mappingTable.Add(new AsprezzaRule("rm", 1.5));
            mappingTable.Add(new AsprezzaRule("rs", 2.5));
            mappingTable.Add(new AsprezzaRule("rz", 4));
            mappingTable.Add(new AsprezzaRule("spr", 4));
            mappingTable.Add(new AsprezzaRule("tr", 3));
            mappingTable.Add(new AsprezzaRule("str", 4));
            mappingTable.Add(new AsprezzaRule("zz", 3));
            //mappingTable.Add(new AsprezzaRule("squ", 4));
            mappingTable.Add(new AsprezzaRule("ll", 0.5));
            mappingTable.Add(new AsprezzaRule("nostr", 1));
            mappingTable.Add(new AsprezzaRule("vostr", 1));
            //mappingTable.Add(new AsprezzaRule("quell", 1));
            //mappingTable.Add(new AsprezzaRule("dell", 1));
            //mappingTable.Add(new AsprezzaRule("dall", 1));
            //mappingTable.Add(new AsprezzaRule("sull", 1));
            //mappingTable.Add(new AsprezzaRule("nell", 1));
            mappingTable.Add(new AsprezzaRule("tra", 1));
            mappingTable.Add(new AsprezzaRule("contr", 1));
            mappingTable.Add(new AsprezzaRule("ebbe", 1));
            mappingTable.Add(new AsprezzaRule("ebbi", 1));
        }

    }

    /// <summary>
    /// DataSet that contains a rule to be allied during asprezza analysis
    /// </summary>
    class AsprezzaRule
    {
        public string phoneticRepresentation { get; set; }
        public double asprezzaValue { get; set; }

        public AsprezzaRule(string s, double i)
        {
            this.phoneticRepresentation = s;
            this.asprezzaValue = i;
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
