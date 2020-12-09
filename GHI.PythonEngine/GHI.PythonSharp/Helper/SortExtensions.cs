using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace GHI.PythonSharp.Helper
{
    public class SortExtensions
    {
        public enum SortOrder
        {
            ASC,DESC
        }
        public static IList SortStringAsc(IList arr1,SortOrder Mode=SortOrder.ASC)
        {
            var l = arr1.Count;
            var temp = "";
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    if ((Mode == SortOrder.ASC && string.Compare(arr1[j].ToString() , arr1[j + 1].ToString())>0) ||
                        (Mode == SortOrder.DESC && string.Compare(arr1[j].ToString(), arr1[j + 1].ToString()) < 0))
                    {
                        temp = arr1[j].ToString();
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                    }
                }
            }
            //Console.Write("\n\nAfter sorting the array appears like : \n");
            return arr1;
        }
    }
}
