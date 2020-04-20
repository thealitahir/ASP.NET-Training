using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cSharpAssignment2
{
    interface IXmlParser
    {
        Task ExtractText(string source, string destination, string attribute, string attributeValue);
    }
}
