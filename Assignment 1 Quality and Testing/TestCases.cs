using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Quality_and_Testing
{
    [TestFixture]
    public class TestCases
    {
        readonly Program pro = new Program();

        [TestCase]
        public void SelectCoverTest()
        {
            //Arrange
            Driver driver = new Driver();

            //Act
            string comp = "1";
            string thirdParty = "0";

            //Assert
            Assert.AreEqual(Cover.Comprehensive, pro.SelectCoverType(comp, driver));
            Assert.AreEqual(Cover.ThirdParty, pro.SelectCoverType(thirdParty, driver));
        }

        [TestCase]
        public void CalculatePremiumAgeTest()
        {
            //Arrange
            Driver driver18 = new Driver
            {
                Age = 18,
                CarValue = 100f
            };

            Driver driver25 = new Driver
            {
                Age = 25,
                CarValue = 100f
            };

            Driver driver40 = new Driver
            {
                Age = 40,
                CarValue = 100f
            };

            //Act
            float result18 = pro.CalculatePremiumForAge(driver18);
            float result25 = pro.CalculatePremiumForAge(driver25);
            float result40 = pro.CalculatePremiumForAge(driver40);

            //Assert
            Assert.AreEqual(110f, result18);
            Assert.AreEqual(110f, result25);
            Assert.AreEqual(100f, result40);
        }

        [TestCase]
        public void CalculatePremiumCoverTypeTest()
        {
            //Arrange
            Driver compDriver = new Driver
            {
                CoverKind = Cover.Comprehensive,
                CarValue = 100f
            };
            
            Driver thirdPartyDriver = new Driver
            {
                CoverKind = Cover.ThirdParty,
                CarValue = 100f
            };

            //Act
            float comp = pro.CalculatePremiumForCoverType(compDriver);
            float thirdParty = pro.CalculatePremiumForCoverType(thirdPartyDriver);

            //Assert
            Assert.AreEqual(104f, comp);
            Assert.AreEqual(102.5f, thirdParty);
        }

        [TestCase]
        public void CalculateQuoteFromPenaltyPoints()
        {
            //Arrange
            Driver driver1 = new Driver
            {
                CarValue = 100f,
                PenaltyPoints = 0
            };
            
            Driver driver2 = new Driver
            {
                CarValue = 100f,
                PenaltyPoints = 3
            };

            Driver driver3 = new Driver()
            {
                CarValue = 100f,
                PenaltyPoints = 6
            };
            
            Driver driver4 = new Driver()
            {
                CarValue = 100f,
                PenaltyPoints = 9
            };

            Driver driver5 = new Driver()
            {
                CarValue = 100f,
                PenaltyPoints = 11
            };

            //Act
            float noCharge = pro.CalculatePenaltyPointCharge(driver1);
            float firstTier = pro.CalculatePenaltyPointCharge(driver2);
            float secondTier = pro.CalculatePenaltyPointCharge(driver3);
            float thirdTier = pro.CalculatePenaltyPointCharge(driver4);
            float fourthTier = pro.CalculatePenaltyPointCharge(driver5);

            //Assert
            Assert.AreEqual(100f, noCharge);
            Assert.AreEqual(200f, firstTier);
            Assert.AreEqual(300f, secondTier);
            Assert.AreEqual(400f, thirdTier);
            Assert.AreEqual(500f, fourthTier);
        }
    }
}
