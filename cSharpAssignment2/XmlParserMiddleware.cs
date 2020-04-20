using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpAssignment2
{
    class XmlParserMiddleware
    {
        IXmlParser _xmlParser;
        public XmlParserMiddleware(IXmlParser xmlParser)
        {
            _xmlParser = xmlParser;
        }

        public async void ExtractText(string sourcePath, string destinationPath, string attribute, string attributeValue)
        {
            await _xmlParser.ExtractText(sourcePath, destinationPath, attribute, attributeValue);
        }
    }
}
