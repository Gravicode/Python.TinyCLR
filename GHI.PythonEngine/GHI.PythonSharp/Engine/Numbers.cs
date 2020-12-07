﻿namespace GHI.PythonSharp
{
    using System;
    
    
    using System.Text;

    using Microsoft.VisualBasic.CompilerServices;
    using GHI.PythonSharp.Exceptions;

    public static class Numbers
    {
        public static object Add(object obj1, object obj2)
        {
            if (IsNumber(obj1) && IsNumber(obj2))
                return Operators.AddObject(obj1, obj2);

            return Operators.ConcatenateObject(obj1, obj2);
        }

        public static object Subtract(object obj1, object obj2)
        {
            return Operators.SubtractObject(obj1, obj2);
        }

        public static object Multiply(object obj1, object obj2)
        {
            return Operators.MultiplyObject(obj1, obj2);
        }

        public static object Divide(object obj1, object obj2)
        {
            if (IsFixnum(obj1) && IsFixnum(obj2) && (int)Operators.ModObject(obj1, obj2) == 0)
                return Operators.IntDivideObject(obj1, obj2);

            return Operators.DivideObject(obj1, obj2);
        }

        public static object Remainder(object obj1, object obj2)
        {
            if (!IsFixnum(obj1) || !IsFixnum(obj2))
                throw new InvalidOperationException("Remainder requires integer values");

            return Operators.ModObject(obj1, obj2);
        }

        public static long GreatestCommonDivisor(long n, long m)
        {
            long a = Math.Min(n, m);
            long b = Math.Max(n, m);

            long rest = b % a;

            while (rest != 0)
            {
                b = a;
                a = rest;

                rest = b % a;
            }

            return Math.Abs(a);
        }

        public static object Abs(object obj)
        {
            if ((bool)Operators.CompareObjectLess(obj, 0, false))
                return Operators.NegateObject(obj);

            return obj;
        }

        public static bool IsFixnum(object obj)
        {
            if (obj == null)
                return false;

            if (obj is short || obj is int || obj is long)
                return true;

            return false;
        }

        public static bool IsRealnum(object obj)
        {
            if (obj == null)
                return false;

            if (obj is float || obj is double)
                return true;

            return false;
        }

        public static bool IsNumber(object obj)
        {
            return IsFixnum(obj) || IsRealnum(obj);
        }

        public static object Negate(object obj)
        {
            return Operators.NegateObject(obj);
        }

        public static int ToInteger(object obj)
        {
            if (!IsFixnum(obj))
                throw new TypeError(string.Format("'{0}' object cannot be interpreted as an integer", Types.GetTypeName(obj)));

            return (int)obj;
        }
    }
}
