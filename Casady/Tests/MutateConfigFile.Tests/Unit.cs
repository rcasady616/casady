using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Casady.Lib.MutateConfigFile;
using NUnit.Framework;

namespace Casady.Tests.MutateFile.Tests
{
    [TestFixture]
    public class Unit
    {
        #region Update node

        [TestCase(@"..\..\NeverGonnaGetIt.xml", "/ConfigDriver/SampleOne", "Change one node value")]
        public void ThrowsFileNotFound(string fileName, string xPathQuery, string nodeValue)
        {
            Exception ex = Assert.Throws<FileNotFoundException>(() => ConfigChange.UpdateConfigFile(fileName, xPathQuery, nodeValue));
        }

        [TestCase(@"sampleFile.xml", "/NeverGonnaGetIt/NeverGonnaGetIt", "Change one node value")]
        public void ThrowsNodeNotFound(string fileName, string xPathQuery, string nodeValue)
        {
            Exception ex = Assert.Throws<XmlNodeNotFoundException>(() => ConfigChange.UpdateConfigFile(fileName, xPathQuery, nodeValue));
        }

        [TestCase(@"sampleFile.xml", "/ConfigDriver/SampleOne", "Change one node value")]
        [TestCase(@"sampleFile.xml", "/ConfigDriver/SampleThree[@name='SpecificNone']", "Change one node value by attribute name")]
        public void ChangeNodeValue(string fileName, string xPathQuery, string nodeValue)
        {
            ConfigChange.UpdateConfigFile(fileName, xPathQuery, nodeValue);
            AssertNode(fileName, xPathQuery, nodeValue);
        }

        #endregion

        [TestCase(@"sampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "description", "Change one specific attribute value")]
        public void ChangeAttributeValue(string fileName, string xPathQuery, string attributeKey, string attributeValue)
        {
            ConfigChange.UpdateConfigFile(fileName, xPathQuery, attributeKey, attributeValue);
            AssertAttribute(fileName, xPathQuery, attributeKey, attributeValue);
        }

        private void AssertEqualXml(string expectedXml, string actualXml)
        {
            Assert.IsTrue(XNode.DeepEquals(XElement.Parse(expectedXml), XElement.Parse(actualXml)),
                String.Format("{0} \n does not equal \n{1}", actualXml, expectedXml));
        }

        private static void AssertNode(string fileName, string xPathQuery, string nodeValue)
        {
            var fileXml = new XmlDocument();
            using (var sr = new StreamReader(fileName))
            {
                fileXml.LoadXml(sr.ReadToEnd());
                var nodes = fileXml.SelectNodes(xPathQuery);
                Assert.AreEqual(1, nodes.Count);
                Assert.AreEqual(nodeValue, nodes[0].InnerText);
            }
        }
        
        private static void AssertAttribute(string fileName, string xPathQuery, string attributeKey, string attributeValue)
        {
            var fileXml = new XmlDocument();
            using (var sr = new StreamReader(fileName))
            {
                fileXml.LoadXml(sr.ReadToEnd());
                var nodes = fileXml.SelectNodes(xPathQuery);
                Assume.That(1 == nodes.Count);
                Assert.AreEqual(attributeValue, nodes[0].Attributes[attributeKey].Value);
            }
        }
    }
}
