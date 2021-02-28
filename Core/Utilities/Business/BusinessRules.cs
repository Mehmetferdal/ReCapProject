using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var login in logics)
            {
                if (!login.Success)
                {
                    return login;
                }
            }
            return null;
        }
            
    }
}
