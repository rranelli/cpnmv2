using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NUnit.Framework;

namespace CPNMv2.Tests
{
    class PropValueFixture
    {
        [Test]
        public void CannotConvert()
        {
            var propValue = new PropValue();
            propValue.Value = "foo";
            Assert.IsFalse(propValue.IsConvertible());
        }

        [Test]
        public void CanConvert()
        {
            
        }
    }
}
