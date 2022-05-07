using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//IResult türünde aldığımız tüm parametrelerı diziye atarak tutuyoruz - logics = iş kuralları
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)// gelen logicler hatalıysa
                {
                    return logic;
                }
            }
            return null;
        }//eğer ki gelen logiclerden hatalı olan varsa bize o logici döndür diyoruz
    }
}
