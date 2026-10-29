using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Utilities
{
    public static class BasicTokenAuth
    {
        private static string TokenString = "$#739533ad2ca2d0df62770aef5191834e#$";
        public static bool IsTokenMatched(string tk)
        {
            if(TokenString == tk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}