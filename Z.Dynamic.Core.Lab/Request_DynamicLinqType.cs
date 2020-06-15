﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;
using System.Text;

namespace Z.Dynamic.Core.Lab
{
    public class Request_DynamicLinqType
    {

        [DynamicLinqType]
        public static class Utils
        {
            public static string[] ConvertToArray(params string[] values)
            {
                if (values == null)
                {
                    return new string[0];
                }

                return values.ToArray();
            }
        }

        public static void Execute()
        {
            var externals = new Dictionary<string, object>
            {
                {"Users", false},
                {"x", new[] {"a", "b", "c"}},
                {"y", 2},
            };

            var t1 = Utils.ConvertToArray(null);

            string query = "Utils.ConvertToArray(null)";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(null, query, externals);
            Delegate del = expression.Compile();
            var result = del.DynamicInvoke();
          
        }
    }
}
