using DATA.EF_CORE;
using DATA.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Extensions
{
    public static class GlobalQueryFillter
    {
        public static ModelBuilder BuilCustomFillter(ModelBuilder builder)
        {
            builder.Entity<User>().HasQueryFilter(e => !e.Status.Equals(STATUS.DELETED));

            return builder;
        }
    }
}
