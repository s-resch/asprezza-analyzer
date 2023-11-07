using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Services to export asprezza data into various formats
    /// </summary>
    public class AsprezzaExporter
    {
        /// <summary>
        /// Export asprezza data into CSV format using these hints: https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp
        /// </summary>
        /// <param name="results">Asprezza results to be exported</param>
        /// <param name="fileToWrite">File name where to write results</param>
        public static void ExportAsprezzaCSV(AsprezzaResultSet results, string fileToWrite)
        {
            var csv = new StringBuilder();

            AsprezzaMapping am = new AsprezzaMapping();

            for (int i = 0; i < results.dataAsprezza.Count && i < results.dataWordName.Count; i++)
            {
                string newLine = string.Format("{0};{1}", results.dataWordName[i], results.dataAsprezza[i].ToString());
                csv.AppendLine(newLine);             
            }

            File.WriteAllText(fileToWrite, csv.ToString());
        }

        /// <summary>
        /// Export asprezza data into XML format using these hints: https://stackoverflow.com/questions/15083727/how-to-create-xml-in-c-sharp
        /// </summary>
        /// <param name="results">Asprezza results to be exported</param>
        /// <param name="fileToWrite">File name where to write results</param>
        public static void ExportAsprezzaXML(AsprezzaResultSet results, string fileToWrite)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("asprezza");
            xmlDoc.AppendChild(rootNode);

            for (int i = 0; i < results.dataAsprezza.Count && i < results.dataWordName.Count; i++)
            {
                XmlNode asprezzaNode = xmlDoc.CreateElement("asprezzaValue");
                XmlAttribute wordAttribute = xmlDoc.CreateAttribute("word");
                wordAttribute.Value = results.dataWordName[i];
                asprezzaNode.Attributes.Append(wordAttribute);
                asprezzaNode.InnerText = results.dataAsprezza[i].ToString();
                rootNode.AppendChild(asprezzaNode);
            }

            xmlDoc.Save(fileToWrite);
        }

        /// <summary>
        /// Export asprezza data/plot into PNG format using ScottPlot directly (using information from https://scottplot.net/)
        /// </summary>
        /// <param name="plotToExport">Plot to be exported</param>
        /// <param name="fileToWrite">File name where to write results</param>
        public static void ExportAsprezzaPNG(ScottPlot.FormsPlot plotToExport, string fileToWrite)
        {
            plotToExport.Plot.SaveFig(fileToWrite, 1920, 870, false, 2);
        }
    }
}
