using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AsprezzaAnalyzer
{
    public class AsprezzaRuleImportExport
    {   
        public static void ExportToXml(string filename)
        {
            Dictionary<string, string> asprezzaRules = ConfigExtractor.ParseAsprezzaRules();
            decimal multiplicator = ConfigExtractor.ParseMultiplicatorRhyme();

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("asprezzaRules");
            xmlDoc.AppendChild(rootNode);

            foreach (KeyValuePair<string, string> entry in asprezzaRules)
            {
                XmlNode asprezzaNode = xmlDoc.CreateElement("asprezzaRule");
                XmlAttribute ruleAttribute = xmlDoc.CreateAttribute("rule");
                ruleAttribute.Value = entry.Key;
                asprezzaNode.Attributes.Append(ruleAttribute);
                asprezzaNode.InnerText = entry.Value;
                rootNode.AppendChild(asprezzaNode);
            }

            XmlNode multiplicatorNode = xmlDoc.CreateElement("multiplicatorRhyme");
            multiplicatorNode.InnerText = multiplicator.ToString();
            rootNode.AppendChild(multiplicatorNode);

            xmlDoc.Save(filename);
        }

        public static void ImportFromXml(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            Dictionary<string, string> asprezzaRules = new Dictionary<string, string>();
            decimal multiplicator = 0;

            XmlNodeList asprezzaRuleNodes = doc.SelectNodes("//asprezzaRule");

            foreach (XmlNode x in asprezzaRuleNodes)
            {
                asprezzaRules.Add(x.Attributes["rule"].Value, x.InnerText);
            }
            
            XmlNodeList multiplicatorNode = doc.SelectNodes("//multiplicatorRhyme");
            multiplicator = Decimal.Parse(multiplicatorNode[0].InnerText);

            ConfigExtractor.Write(asprezzaRules, multiplicator);
        }
    }
}
