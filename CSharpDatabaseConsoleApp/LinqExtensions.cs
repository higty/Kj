﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDatabase
{
    public static class LinqExtensions
    {
        public static List<T> Filter<T>(this List<T> list, Func<T, Boolean> filter)
        {
            var l = new List<T>();

            foreach (var item in list)
            {
                if (filter(item) == true)
                {
                    l.Add(item);
                }
            }
            return l;
        }
    }
}
