using Order.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Repository.SqlSugar.BASE
{
    public class BaseDBConfig
    {
        //   public static string ConnectionString = File.ReadAllText(@"D:\my-file\dbCountPsw1.txt").Trim();

        //正常格式是

        public static string ConnectionString = "Server=.;Database=GZMModel;User ID=sa;Password=123456;";// Appsettings.app("AppSettings", "SqlServer", "ConnectionString"); 

   

    }
}
