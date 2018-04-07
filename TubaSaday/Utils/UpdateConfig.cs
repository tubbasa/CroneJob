using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TubaSaday.Utils
{
    public static class UpdateConfig
    {
       

        public static object update(string connection)
        {
            try
            {
                var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                section.ConnectionStrings["SchoolContext"].ConnectionString = connection;
                configuration.Save();
                return "ok";
            }
            catch (Exception e)
            {

                return "error";
            }
        }
    }
}