using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDatabase
{
    public static class SqlCommandExtensions
    {
        public static SqlParameter AddParameter(this SqlCommand command
            , String parameterName, SqlDbType sqlDbType, Object value)
        {
            var p = new SqlParameter(parameterName, sqlDbType);
            p.Value = value;
            command.Parameters.Add(p);
            return p;
        }
        public static SqlParameter AddParameter(this SqlCommand command
            , String parameterName, SqlDbType sqlDbType, Int32 size, Object value)
        {
            var p = new SqlParameter(parameterName, sqlDbType, size);
            p.Value = value;
            command.Parameters.Add(p);
            return p;
        }
    }
}
