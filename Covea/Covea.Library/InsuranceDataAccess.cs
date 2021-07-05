using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covea.Library
{
    public class InsuranceDataAccess:IInsuranceDataAccess
    {
        public List<CoveaInsurance> GetInsuranceDetails()
        {
            List<CoveaInsurance> coveaInsurance = new List<CoveaInsurance>(){
                new CoveaInsurance(25000, 0.0172, 0.1043, 0.2677),
                new CoveaInsurance(50000, 0.0165, 0.0999, 0.2565),
                new CoveaInsurance(100000, 0.0154, 0.0932, 0.2393),
                new CoveaInsurance(200000, 0.0147, 0.0887, 0.2285),
                new CoveaInsurance(300000, 0.0144, 0.0872, 0),
                new CoveaInsurance(500000, 0.0146, 0, 0)
        };
            return coveaInsurance;
        }
    }
}
