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
        [Test]
        public void CreationofICombatStats()
        {
            ICombatStats testComStat = FactoryConfig.CoreFactory.NewCombatStats(1, 2, 3, 4, 10);
            Assert.AreEqual(1, testComStat.Concentration);
            Assert.AreEqual(2, testComStat.Consciousness);
            Assert.AreEqual(3, testComStat.Energy);
            Assert.AreEqual(4, testComStat.Stamina);
            Assert.AreEqual(10, testComStat.HP);

            //TODO: finish testing creating an interface based on a ICombatStat and an IAblityEffect
            ICombatStats MaxValues = FactoryConfig.CoreFactory.NewCombatStats(14, 12, 4, 123, 300);
        }
        [Test]
        public void CreationOfIAbilityEffects()
        {
            IAbilityEffect testAbilityEffects = FactoryConfig.CoreFactory.NewAbilityEffect(1, -2, 40);
            
            Assert.AreEqual(1, testAbilityEffects.Concentration);
            Assert.AreEqual(-2, testAbilityEffects.Energy);
            Assert.AreEqual(40, testAbilityEffects.HP);
        }
    }
}
