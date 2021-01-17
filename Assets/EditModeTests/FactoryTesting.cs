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

        [Test]
        public void CreationOfCombatant()
        {
            /*
                note the combatant currently works on the following formulas
                StartingConcentration   =  2*S0S 
                StartingConsciousness   =  1*S0E
                StartingEnergy          =  2*S1F
                StartingStamina         =  1*S1E +.1*S2F +.1*S3F +.1*S4F +.1*S5F 
                StartingHP              = 50*S1S + 5*S2S + 5*S3S + 5*S4S + 5*S5S  
                MaximumConcentration    =  5*S0F
                MaximumConsciousness    =  1*S0E
                MaximumEnergy           =  1*S2F + 1*S3F + 1*S4F + 1*S5F
                MaximumStamina          =  1*S1E +.1*S2F +.1*S3F +.1*S4F +.1*S5F
                MaximumHP               = 50*S1S + 5*S2S + 5*S3S + 5*S4S + 5*S5S  
             */
            float S0S = 10, S0E = 10, S0F = 10;
            float S1S = 10, S1E = 10, S1F = 10;
            float S2S = 10, S2E = 10, S2F = 10;
            float S3S = 10, S3E = 10, S3F = 10;
            float S4S = 10, S4E = 10, S4F = 10;
            float S5S = 10, S5E = 10, S5F = 10;

            ICombatant testCombatant = 
                FactoryConfig.CoreFactory.NewCombatant( new Dictionary<int, IPart>()
                {
                    {0, FactoryConfig.CoreFactory.NewPart(S0F,S0E,S0S) },
                    {1, FactoryConfig.CoreFactory.NewPart(S1F,S1E,S1S) },
                    {2, FactoryConfig.CoreFactory.NewPart(S2F,S2E,S2S) },
                    {3, FactoryConfig.CoreFactory.NewPart(S3F,S3E,S3S) },
                    {4, FactoryConfig.CoreFactory.NewPart(S4F,S4E,S4S) },
                    {5, FactoryConfig.CoreFactory.NewPart(S5F,S5E,S5S) }
                },default);

            Assert.AreEqual(2 * S0S, testCombatant.StartingCombats.Concentration);
            Assert.AreEqual(1 * S0E, testCombatant.StartingCombats.Consciousness);
            Assert.AreEqual(2 * S1F, testCombatant.StartingCombats.Energy);
            Assert.AreEqual(1 * S1E + .1 * S2F + .1 * S3F + .1 * S4F + .1 * S5F, testCombatant.StartingCombats.Stamina);
            Assert.AreEqual(50 * S1S + 5 * S2S + 5 * S3S + 5 * S4S + 5 * S5S, testCombatant.StartingCombats.HP);

            Assert.AreEqual(5 * S0F, testCombatant.MaxCombatStats.Concentration);
            Assert.AreEqual(1 * S0E, testCombatant.MaxCombatStats.Consciousness);
            Assert.AreEqual(1 * S2F + 1 * S3F + 1 * S4F + 1 * S5F, testCombatant.MaxCombatStats.Energy);
            Assert.AreEqual(1 * S1E + .1 * S2F + .1 * S3F + .1 * S4F + .1 * S5F, testCombatant.MaxCombatStats.Stamina);
            Assert.AreEqual(50 * S1S + 5 * S2S + 5 * S3S + 5 * S4S + 5 * S5S, testCombatant.MaxCombatStats.HP);

        }

    }
}
