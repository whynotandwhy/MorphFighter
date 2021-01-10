using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Factory;

namespace Tests
{
    /// <summary>
    /// Factory Testing 0.5
    /// 
    /// </summary>
    public class FactoryTesting
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreationOfIPart()
        {
            IPart testpart = FactoryConfig.CoreFactory.NewPart(1, 2, 3);
            Assert.AreEqual(1, testpart.Focus);
            Assert.AreEqual(2, testpart.Effort);
            Assert.AreEqual(3, testpart.Strength);
            Assert.AreEqual((1+2+3)/3, testpart.Rank);
        }

    }
}
