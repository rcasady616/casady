using System.Xml;

namespace NUnit.Framework
{
    public static class XmlNodeAssert
    {
        public static XmlNode InnerTextAreEqual(this XmlNode xmlNode, string expectedInnerText)
        {
            Assert.AreEqual(expectedInnerText, xmlNode.InnerText);
            return xmlNode;
        }

        public static XmlNode InnerXmlAreEqual(this XmlNode xmlNode, string expectedXmlText)
        {
            Assert.AreEqual(expectedXmlText, xmlNode.InnerXml);
            return xmlNode;
        }

        public static XmlNode AttributeExists(this XmlNode xmlNode, string attributeName)
        {
            var attribute = xmlNode.Attributes[attributeName];
            Assert.NotNull(attribute);
            return xmlNode;
        }

        public static XmlNode AttributeValueAreEqual(this XmlNode xmlNode, string attributeName, string expectedAttributeValue)
        {
            xmlNode.AttributeExists(attributeName);
            Assert.AreEqual(expectedAttributeValue, xmlNode.Attributes[attributeName].Value);
            return xmlNode;
        }

        /// <summary>
        /// Asserts that the Value and all Attributes Values are Equivalent
        /// Equivalent meaning all attribute values are equal but the match may be in any order. 
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static XmlNode DataEqual(this XmlNode xmlNode, XmlNode expected)
        {
            var attributes = expected.Attributes;
            if (attributes != null)
                foreach (XmlAttribute attribute in attributes)
                    Assert.AreEqual(expected.Attributes[attribute.Name].Value, xmlNode.Attributes[attribute.Name].Value);
            xmlNode.InnerTextAreEqual(expected.InnerText);
            return xmlNode;
        }
    }
}