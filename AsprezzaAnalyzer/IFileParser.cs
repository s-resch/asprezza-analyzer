using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Definition of interface to read input (text) files to allow new types of file readers
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Read text from a file and process text in a way so we get a list of TextUnits
        /// </summary>
        /// <param name="path">Path specifying file to be read</param>
        /// <returns>List of TextUnits that can be anlayzed by application</returns>
        List<TextUnit> ReadText(string path);
    }
}
