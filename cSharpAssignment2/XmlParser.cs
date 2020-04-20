﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cSharpAssignment2
{
    class XmlParser: IXmlParser
    {
        public async Task ExtractText(string sourcePath, string destinationPath, string attribute, string attributeValue)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;  
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            using (XmlReader reader = XmlReader.Create(sourcePath, settings))
            {
                try
                {
                    reader.MoveToContent();
                    while (await reader.ReadAsync())
                    {
                        if (reader.GetAttribute(attribute) == attributeValue)
                        {
                            XmlReader xmlReader = reader.ReadSubtree();

                            while (await xmlReader.ReadAsync())
                            {
                                if (xmlReader.NodeType == XmlNodeType.Text)
                                {
                                    File.AppendAllText(destinationPath, await xmlReader.GetValueAsync());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    reader.Close();
                }

            }
        }

    }
}
