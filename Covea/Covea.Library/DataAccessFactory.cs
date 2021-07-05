using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covea.Library
{
    public class DataAccessFactory
    {
        public static IInsuranceDataAccess GetInsuranceDataAccessObj()
        {
            return new InsuranceDataAccess();
        }
    }
}
