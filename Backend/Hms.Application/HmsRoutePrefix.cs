using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hms.Shared.Constant.Constants;

namespace Hms.Application
{
    public static class HmsRoutePrefix
    {
        private const string HMSRoutePrefixBase = ApiRoutePrefix.RoutePrefixBase + "hms/";

        #region BasicSetup
        public const string BloodGroup = HMSRoutePrefixBase + "bloodGroup";
        public const string CategoryType = HMSRoutePrefixBase + "categoryType";
        public const string Gender = HMSRoutePrefixBase + "gender";
        public const string Country = HMSRoutePrefixBase + "country";
        public const string EmployeeType = HMSRoutePrefixBase + "employeeType";
        public const string City = HMSRoutePrefixBase + "city";

        #endregion

        #region GuestInfo
        public const string GuestInfo = HMSRoutePrefixBase + "guestInfo";
        #endregion
    }
}
