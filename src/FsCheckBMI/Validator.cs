using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsCheckBMI
{
    public class Validator
    {
        /// <summary>
        /// 入力値の検証を行う
        /// </summary>
        public bool IsValid(string text)
        {
            return LengthRule(text) & NumberRule(text);
        }

        public bool NumberRule(string text)
        {
            int temp;
            return int.TryParse(text, out temp);
        }

        public bool LengthRule(string text)
        {
            return (text.Length < 4);
        }
    }
}
