using System.ComponentModel;
using System.Xml;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FuNunit
{
    public class XmlAssert
    {
        static public void InnerTextIsEqual(string expectedText, XmlNode actual)
        {
            Assert.That(actual.InnerText, Is.EqualTo(expectedText), string.Empty, null);
        }

    }
}
