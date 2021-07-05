using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covea.Library
{
   public class InsuranceBusinessLogic
    {
       private IInsuranceDataAccess _InsuranceDataAccess;

       public InsuranceBusinessLogic(IInsuranceDataAccess insuranceDataAccess)
        {
            _InsuranceDataAccess = insuranceDataAccess; 
        }

        public double CalculateRiskRate(int sumAssured, int age, List<CoveaInsurance> coveaInsurance)
        {
            double riskRate=0;
            CoveaInsurance coveaInsuranceLowerBand = coveaInsurance.OrderByDescending(x => x.SumAssured).FirstOrDefault(x => x.SumAssured < sumAssured);

            CoveaInsurance coveaInsuranceUpperBand = coveaInsurance.OrderBy(x => x.SumAssured).FirstOrDefault(x => x.SumAssured > sumAssured);
            
            int lowerBandSumAssured = coveaInsuranceLowerBand.SumAssured;
            int upperBandSumAssured = coveaInsuranceUpperBand.SumAssured;
            double upperBandRiskRate = coveaInsuranceUpperBand.GetRiskRateForAge(age);
            double lowerBandRiskRate = coveaInsuranceLowerBand.GetRiskRateForAge(age);
            riskRate = (double)(sumAssured - lowerBandSumAssured) / (double)(upperBandSumAssured - lowerBandSumAssured) * upperBandRiskRate + (upperBandSumAssured - sumAssured) / (double)(upperBandSumAssured - lowerBandSumAssured) * lowerBandRiskRate;
            return Math.Round(riskRate,4);
        }

        public double CalculateGrossPremium(ref int sumAssured, int age)
        {
            double grossPremimum = 0;
            double riskRate = 0;
            int sumAssuredLocal = sumAssured;
            int j=0;

            List<CoveaInsurance> coveaInsurance = _InsuranceDataAccess.GetInsuranceDetails();
            while (grossPremimum < 2)
            {
                 
                CoveaInsurance result = coveaInsurance.Find(x => x.SumAssured == sumAssuredLocal);
                if (result != null)
                {
                    riskRate = result.GetRiskRateForAge(age);
                }
                else if (result == null)
                {
                    riskRate = CalculateRiskRate(sumAssuredLocal, age, coveaInsurance);
                }

                double riskPremium = riskRate * (sumAssuredLocal / 1000);
                double renewalCommission = (3 * riskPremium) / 100;
                double netPremium = riskPremium + renewalCommission;
                double initialCommission = (netPremium * 205) / 100;
                grossPremimum = netPremium + initialCommission;
                //debugging
                //Console.WriteLine("{0},{1},{2}", grossPremimum,sumAssuredLocal,riskRate);
                j = sumAssuredLocal;
                sumAssuredLocal = sumAssuredLocal + 5000;
            }
            sumAssured = j;
            return Math.Round(grossPremimum,4);
        }
    }
}
