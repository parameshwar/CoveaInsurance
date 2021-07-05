using NUnit.Framework;
using System.Collections.Generic;

namespace Covea.Library.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(30000, 15)]
        [TestCase(500000, -30)]
        [TestCase(500000, 45)]
        [TestCase(20000, 10)]
        [TestCase(700000, 30)]
        [TestCase(700000, 70)]
        [Parallelizable(ParallelScope.All)]
        public void TestValidateInput(int sumAssured, int age)
        {
            bool result = Program.ValidateInput(sumAssured, age);
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(30000, 30)]
        public void TestValidateInput_InrangeSumAssured_Age(int sumAssured, int age)
        {
            bool result = Program.ValidateInput(sumAssured, age);
            Assert.True(result);
        }

        [Test]
        public void TestRiskRateForAge()
        {
            CoveaInsurance coveaInsurance = new CoveaInsurance(50000, 0.0165, 0.0999, 0.2565);
            double expectedRiskRate = 0.0999;
            Assert.AreEqual(expectedRiskRate, coveaInsurance.GetRiskRateForAge(40));
        }

        [Test]
        public void TestAllRiskRateForParticularAge()
        {
            List<CoveaInsurance> coveaInsurance = new List<CoveaInsurance>(){
                new CoveaInsurance(25000, 0.0172, 0.1043, 0.2677),
                new CoveaInsurance(50000, 0.0165, 0.0999, 0.2565),
                new CoveaInsurance(100000, 0.0154, 0.0932, 0.2393),
                new CoveaInsurance(200000, 0.0147, 0.0887, 0.2285),
                new CoveaInsurance(300000, 0.0144, 0.0872, 0),
                new CoveaInsurance(500000, 0.0146, 0, 0)
        };
            List<double> ageBelowThirty = new List<double>()
            {
                0.0172,0.0165,0.0154,0.0147,0.0144,0.0146
            };
            foreach (var a in coveaInsurance)
            {
                Assert.True(ageBelowThirty.Contains(a.GetRiskRateForAge(30)));
            }
        }

        [Test]
        public void TestCalculateRiskRate()
        {
            List<CoveaInsurance> coveaInsurance = new List<CoveaInsurance>(){
                new CoveaInsurance(25000, 0.0172, 0.1043, 0.2677),
                new CoveaInsurance(50000, 0.0165, 0.0999, 0.2565),
                new CoveaInsurance(100000, 0.0154, 0.0932, 0.2393),
                new CoveaInsurance(200000, 0.0147, 0.0887, 0.2285),
                new CoveaInsurance(300000, 0.0144, 0.0872, 0),
                new CoveaInsurance(500000, 0.0146, 0, 0)
        };
            InsuranceBusinessLogic insuranceBusinessLogic = new InsuranceBusinessLogic(new InsuranceDataAccess());
            double expectedRiskRate = 0.0166;
            Assert.AreEqual(expectedRiskRate, insuranceBusinessLogic.CalculateRiskRate(45000, 30, coveaInsurance));
        }

        [Test]
        public void TestCalculateGrossPremium()
        {
            InsuranceBusinessLogic insuranceBusinessLogic = new InsuranceBusinessLogic(new InsuranceDataAccess());
            int sumAssured = 30000;
            double expectedGrossPremium = 2.1111;
            int expectedSumAssured = 40000;
            Assert.AreEqual(expectedGrossPremium, insuranceBusinessLogic.CalculateGrossPremium(ref sumAssured, 30));
            Assert.AreEqual(expectedSumAssured, sumAssured);
        }
    }
}