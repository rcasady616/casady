using System;
using System.IO;
using System.Xml;

namespace Casady.Lib.MutateConfigFile
{
    public class ConfigChange
    {
        /// <summary>
        /// Changes an xml node value in a given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="xPathQuery"></param>
        /// <param name="nodeValue"></param>
        public static void UpdateConfigFile(string fileName, string xPathQuery, string nodeValue)
        {
            if (File.Exists(fileName))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                var nodeList = xmlDoc.SelectNodes(xPathQuery);
                if (nodeList == null)
                    throw new XmlNodeNotFoundException("", fileName, xPathQuery, nodeValue);
                if (nodeList.Count == 0)
                    Console.Write(new XmlNodeNotFoundException("", fileName, xPathQuery, nodeValue));
                if (nodeList.Count > 1)
                    Console.Write(new MultipleNodesFoundException("", fileName, xPathQuery, nodeValue));

                nodeList[0].InnerText = nodeValue;
                xmlDoc.Save(fileName);
            }
        }

        /// <summary>
        /// Changes an xml attribute value in a given file
        /// </summary>
        /// <param name="fileName">The xml config to be changed</param>
        /// <param name="xPathQuery">the xPath query to the node</param>
        /// <param name="attributeKey">The name of the attribute to be changed</param>
        /// <param name="attributeValue">The new attribute value</param>
        public static void UpdateConfigFile(string fileName, string xPathQuery, string attributeKey, string attributeValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var nodeList = xmlDoc.SelectNodes(xPathQuery);
            if (nodeList == null)
                throw new XmlNodeNotFoundException("", fileName, xPathQuery, attributeKey, attributeValue);
            if (nodeList.Count == 0)
                Console.Write(new XmlNodeNotFoundException("", fileName, xPathQuery, attributeKey, attributeValue));
            if (nodeList.Count > 1)
                Console.Write(new MultipleNodesFoundException("", fileName, xPathQuery, attributeKey, attributeValue));

            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes != null && node.Attributes[attributeKey] != null)
                    node.Attributes[attributeKey].Value = attributeValue;
                else
                    Console.Write(new XmlAttributesNotFoundException("", fileName, xPathQuery, attributeKey, attributeValue));
            }
            xmlDoc.Save(fileName);
        }

    }

    public class XmlNodeNotFoundException : XmlException
    {
        public XmlNodeNotFoundException()
        {

        }
        public XmlNodeNotFoundException(string exceptionText)
            : base(string.Format("XmlNodeNotFoundException: {0}", exceptionText))
        {
        }
        public XmlNodeNotFoundException(string exceptionText, string fileName, string xPathQuery, string nodeValue)
            : base(string.Format("XmlNodeNotFoundException: {0}\nFile name: {1}\nXPath query: {2}\nNode value: {3}", exceptionText, fileName, xPathQuery, nodeValue))
        {
        }
        public XmlNodeNotFoundException(string exceptionText, string fileName, string xPathQuery, string attributekey, string attributeValue)
            : base(string.Format("XmlNodeNotFoundException: {0}\nFile name: {1}\nXPath Query: {2}\nAttribute key: {3}\nAttribute Value:{4}", exceptionText, fileName, xPathQuery, attributekey, attributeValue))
        {
        }
    }

    public class MultipleNodesFoundException : XmlException
    {
        public MultipleNodesFoundException()
        {

        }
        public MultipleNodesFoundException(string exceptionText)
            : base(string.Format("MultipleNodesFoundException: {0}", exceptionText))
        {
        }
        public MultipleNodesFoundException(string exceptionText, string fileName, string xPathQuery, string nodeValue)
            : base(string.Format("MultipleNodesFoundException: {0}\nFile name: {1}\nXPath query: {2}\nNode value: {3}", exceptionText, fileName, xPathQuery, nodeValue))
        {
        }
        public MultipleNodesFoundException(string exceptionText, string fileName, string xPathQuery, string attributekey, string attributeValue)
            : base(string.Format("MultipleNodesFoundException: {0}\nFile name: {1}\nXPath Query: {2}\nAttribute key: {3}\nAttribute Value:{4}", exceptionText, fileName, xPathQuery, attributekey, attributeValue))
        {
        }
    }

    public class XmlAttributesNotFoundException : XmlException
    {
        public XmlAttributesNotFoundException()
        {

        }
        public XmlAttributesNotFoundException(string exceptionText)
            : base(string.Format("XmlAttributesNotFoundException: {0}", exceptionText))
        {
        }
        public XmlAttributesNotFoundException(string exceptionText, string fileName, string xPathQuery, string nodeValue)
            : base(string.Format("XmlAttributesNotFoundException: {0}\nFile name: {1}\nXPath query: {2}\nNode value: {3}", exceptionText, fileName, xPathQuery, nodeValue))
        {
        }
        public XmlAttributesNotFoundException(string exceptionText, string fileName, string xPathQuery, string attributekey, string attributeValue)
            : base(string.Format("XmlAttributesNotFoundException: {0}\nFile name: {1}\nXPath Query: {2}\nAttribute key: {3}\nAttribute Value:{4}", exceptionText, fileName, xPathQuery, attributekey, attributeValue))
        {
        }
    }
}
