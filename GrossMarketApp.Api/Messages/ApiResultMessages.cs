using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Messages
{
    public static class ApiResultMessages
    {
        public static string ResultMessage(bool isSuccess)
        {
            if (isSuccess)
                return "Başarılı İşlem!";
            else
                return "Hatalı İşlem!";
        }
    }
}
