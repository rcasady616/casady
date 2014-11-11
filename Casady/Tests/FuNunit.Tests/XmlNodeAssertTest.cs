using NUnit.Framework;
using System.IO;
using System.Xml;

namespace FuNunit.Tests
{
    [TestFixture]
    public class XmlNodeAssertTest
    {
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "Change one node value")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree", "")]
        public void InnerTextAreEqual(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.InnerTextAreEqual(expectedValue);
        }

        [ExpectedException(typeof(AssertionException))]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "Never gonna get it")]
        public void InnerTextAreEqualThows(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.InnerTextAreEqual(expectedValue);
        }

        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree[@name='SpecificNone']", "name")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib", "name")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib", "description")]
        public void AttributeExists(string fileName, string xPathQuery, string attributeName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.AttributeExists(attributeName);
        }

        [ExpectedException(typeof(AssertionException))]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree", "name")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib", "YourMom")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib", "NeverGonnaGetIt")]
        public void AttributeExistsThrows(string fileName, string xPathQuery, string attributeName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.AttributeExists(attributeName);
        }

        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree[@name='SpecificNone']", "name", "SpecificNone")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "description", "Change one specific attribute value")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item2']", "description", "")]
        public void AttributeValueAreEqual(string fileName, string xPathQuery, string attributeName, string attributeValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.AttributeValueAreEqual(attributeName, attributeValue);
        }

        [ExpectedException(typeof(AssertionException))]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree[@name='SpecificNone']", "name", "")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree[@name='SpecificNone']", "nameq", "SpecificNone")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "description", "")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item2']", "description", "Change one specific attribute value")]
        public void AttributeValueAreEqualThrows(string fileName, string xPathQuery, string attributeName, string attributeValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.AttributeValueAreEqual(attributeName, attributeValue);
        }

        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "Change one node value")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleThree", "")]
        [TestCase(@"TestData/SampleFileAlternateStructure.xml", "/ConfigDriver/SampleThree", "")]
        public void InnerXmlAreEqual(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.InnerXmlAreEqual(expectedValue);
        }

        [ExpectedException(typeof(AssertionException))]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", " <Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "  <Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "      <Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<Attrib name=\"item1\" description=\"Change one specific attribute value\" />     <Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<Attrib   name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        [TestCase(@"TestData/SampleFileAlternateStructure.xml", "/ConfigDriver/SampleTwo", "<Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" />")]
        public void InnerXmlAreEqualThrows(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            node.InnerXmlAreEqual(expectedValue);
        }

        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "<SampleOne>Change one node value</SampleOne>")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<SampleTwo><Attrib name=\"item1\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" /></SampleTwo>")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<SampleTwo><Attrib name=\"ChildNodeAttributeIsDiffernt\" description=\"Change one specific attribute value\" /><Attrib name=\"item2\" description=\"\" /></SampleTwo>")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo", "<SampleTwo><Attrib name=\"item2\" description=\"\" /><Attrib name=\"item1\" description=\"Change one specific attribute value\" /></SampleTwo>")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item1\" description=\"Change one specific attribute value\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib description=\"Change one specific attribute value\" name=\"item1\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item1\" description=\"Change one specific attribute value\"></Attrib>")]
        [TestCase(@"TestData/SampleFileAlternateStructure.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item1\" description=\"Change one specific attribute value\" />")]
        public void DataEqual(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            var doc = new XmlDocument();
            doc.LoadXml(expectedValue);
            var expectedNode = doc.DocumentElement;
            node.DataEqual(expectedNode);
        }

        [ExpectedException(typeof(AssertionException))]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleOne", "<SampleOne>Change one node valu</SampleOne>")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item1\" description=\"1Change one specific attribute value\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item11\" descriptions=\"Change one specific attribute value\" />")]
        [TestCase(@"TestData/SampleFile.xml", "/ConfigDriver/SampleTwo/Attrib[@name='item1']", "<Attrib name=\"item1\" description=\"Change one specific attribute value\">Kevin</Attrib>")]
        public void DataEqualThows(string fileName, string xPathQuery, string expectedValue)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var node = xmlDoc.SelectSingleNode(xPathQuery);
            var doc = new XmlDocument();
            doc.LoadXml(expectedValue);
            var expectedNode = doc.DocumentElement;
            node.DataEqual(expectedNode);
        }

    }
}
