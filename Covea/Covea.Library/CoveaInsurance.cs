using System;

namespace Covea.Library
{
    public class CoveaInsurance
    {
        public double AgeBelowThirty { get; private set; }
        public double AgeBtwThirtyFifty { get; private set; }
        public double AgeAboveFifty { get; private set; }
        public int SumAssured { get; private set; }
        public CoveaInsurance(int sumAssured, double ageBelowThirty, double ageBwThirtyFifty, double ageAboveFifty)
        {
            SumAssured = sumAssured;
            AgeBelowThirty = ageBelowThirty;
            AgeBtwThirtyFifty = ageBwThirtyFifty;
            AgeAboveFifty = ageAboveFifty;
        }
        public double GetRiskRateForAge(int age)
        {
            double Riskrate= 0;
            if(age <=30)
            {
                Riskrate = AgeBelowThirty;
            }
            else if( age > 30 && age <=50)
            {
                Riskrate = AgeBtwThirtyFifty;
            }
            else if( age > 50)
            {
                Riskrate = AgeAboveFifty;
            }
            return Riskrate;
        }
    }
}
