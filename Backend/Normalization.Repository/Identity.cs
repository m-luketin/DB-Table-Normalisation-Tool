using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Normalization.Repository
{
    public static class Identity
    {
        public static void On(ICollection<string> entities,DbContext context)
        {
            foreach (var entity in entities)
            {
                context.Database.ExecuteSqlCommand((string)$"SET IDENTITY_INSERT dbo.{entity}s ON");
            }
        }
        public static void Off(ICollection<string> entities, DbContext context)
        {
            foreach (var entity in entities)
            {
                context.Database.ExecuteSqlCommand((string)$"SET IDENTITY_INSERT dbo.{entity}s OFF");
            }       
        }
    }
}
