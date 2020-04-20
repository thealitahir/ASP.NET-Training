using System;
using System.Xml;

namespace cSharpAssignment2
{
    class XMLParserMain
    {
        static void Main(string[] args)
        {
            IXmlParser xmlParser = new XmlParser();
            XmlParserMiddleware xmlParserMiddleware  = new XmlParserMiddleware(xmlParser);
            xmlParserMiddleware.ExtractText("files/SEC-0000950123-09-019360.xml", "files/output.txt", "long-name", "Risk Factors");
        }
    }
}
