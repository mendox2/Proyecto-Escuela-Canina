using System.Web;
using System.Web.Mvc;

namespace Proyecto_Escuela_canina
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
