using GoogleSheet.Type;
using System;
using UnityEngine;
namespace Hamster.ZG.Type
{
    [Type(typeof(Array), new string[] { "Array", "array" })]
    public class ArrayType : IType
    {
        public object DefaultValue => null;
        /// <summary>
        /// value는 스프레드 시트에 적혀있는 값
        /// </summary> 
        public object Read(string value)
        {
            // value : [[1,2,3], [1,2,3], [1,2,3]]
            var values = ReadUtil.GetBracketValueToArray(value);
            int[] array = new int[values.Length];
            for(int i = 0; i < values.Length; i++)
            {
                array[i] = int.Parse(values[i]);
            }
            return array;
        }

        /// <summary>
        /// value write to google sheet
        /// </summary> 
        public string Write(object value)
        {
            int[] v = (int[])value;
            return $"{v}";
        }

    }
}