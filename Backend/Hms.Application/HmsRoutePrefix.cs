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

        #endregion
    }
}
