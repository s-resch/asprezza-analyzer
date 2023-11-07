using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AsprezzaAnalyzer
{
    public static class ConfigExtractor
    {
        /// <summary>
        /// Get the content of a Xml config file
        /// Built using following hints:
        /// https://stackoverflow.com/questions/453161/how-can-i-save-application-settings-in-a-windows-forms-application
        /// https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-write-user-settings-at-run-time-with-csharp?view=netframeworkdesktop-4.8
        /// </summary>
        /// <param name="path">Directory of the Xml config file</param>
        /// <returns>Set of entries stored in Xml config file</returns>
        public static Dictionary<string, string> ParseAsprezzaRules()
        {
            Dictionary<string, string> sets = new Dictionary<string, string>();

            //Open Xml document
            if(Properties.Settings.Default.asprezzaRules == null)
            {
                Properties.Settings.Default.asprezzaRules = new StringCollection();
            }
            string[] rulesArray = Properties.Settings.Default.asprezzaRules.Cast<string>().ToArray();
            foreach(string rule in rulesArray)
            {
                string[] splitRule = rule.Split('=');
                sets.Add(splitRule[0], splitRule[1].Replace(',', '.'));
            }

            return sets;
        }

        public static decimal ParseMultiplicatorRhyme()
        {
            return Properties.Settings.Default.multiplicatorRhyme;
        }

        /// <summary>
        /// Write new values for settings in Xml config file
        /// </summary>
        /// <param name="sets">Set of new values for Xml config file</param>
        /// <param name="path">Directory of the Xml config file</param>
        public static void Write(Dictionary<string, string> asprezzaRules, decimal multiplicatorRhyme)
        {
            List<string> rules = new List<string>();
            if(Properties.Settings.Default.asprezzaRules == null)
            {
                Properties.Settings.Default.asprezzaRules = new StringCollection(); 
            }
            Properties.Settings.Default.asprezzaRules.Clear();
            foreach (KeyValuePair<string, string> keyValuePair in asprezzaRules)
            {
                Properties.Settings.Default.asprezzaRules.Add(keyValuePair.Key + "=" + keyValuePair.Value);
            }

            if(Properties.Settings.Default.multiplicatorRhyme == null)
            {
                Properties.Settings.Default.multiplicatorRhyme = 1;
            }
            Properties.Settings.Default.multiplicatorRhyme = multiplicatorRhyme;

            Properties.Settings.Default.Save();
        }
    }

}
