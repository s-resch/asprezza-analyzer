using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace AsprezzaAnalyzer
{ 
    /// <summary>
    /// Class to read text in TEI XML format into system
    /// </summary>
    public class TeiXmlParser : IFileParser
    {
        /// <summary>
        /// Read TEI XML file specified by path using follwoing hints:
        /// https://stackoverflow.com/questions/6442024/getting-specified-node-values-from-xml-document
        /// https://learn.microsoft.com/de-de/dotnet/api/system.xml.xmldocument?view=net-7.0
        /// https://www.w3schools.com/xml/xpath_syntax.asp
        /// </summary>
        /// <param name="path">Path specifying TEI XML file to be read into systme</param>
        /// <returns></returns>
        public List<TextUnit> ReadText(string path)
        {
            List<TextUnit> returnList = new List<TextUnit>();
            try
            {                
                List<string> linesOfUnit = new List<string>();

                //Load text document to be read
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                //Get all <div1> nodes from TEI XML
                XmlNodeList nodes = doc.SelectNodes("//div1");
                foreach (XmlNode x in nodes)
                {
                    //Get all <div2> and <head> nodes within the main <div1> container
                    XmlNodeList subUnits = x.SelectNodes("div2");
                    XmlNode Supertitle = x.SelectSingleNode("head");

                    foreach (XmlNode xSub in subUnits)
                    {
                        //Get all lines (<l>-nodes) within <div2> container
                        XmlNodeList lines = xSub.SelectNodes(".//l");
                        XmlNode title = xSub.SelectSingleNode("head");
                        linesOfUnit.Clear();

                        //Save all lines in object representation
                        foreach (XmlNode x2 in lines)
                        {
                            linesOfUnit.Add(x2.InnerText);
                        }

                        //Save parsed TextUnit to list to be returned
                        returnList.Add(new TextUnit(Supertitle.InnerText + ", " + title.InnerText, linesOfUnit));
                    }
                }
                return returnList;
            }
            catch (Exception e)
            {
                //Return empty list in case we got an error reading XML file, e.g. wrong format
                return returnList;
            }
        }
        
    }
}
