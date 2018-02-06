using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class FillLine : Line
    {

        internal FillLine(FillPage page) : base(page)
        {
        }

        /// <summary>
        /// Length method. Gets the length of a word
        /// </summary>
        /// <returns></returns>
        internal override int Length()
        {
            int result = 0;

            for (int i = 0; i < content.Count; i++)
            {
                result += content[i].Length;

                if (i != content.Count - 1)
                {
                    result += 1;
                }
            }
           
            //return word length
            return result;
        }

        internal override bool Overflow()
        {
            return this.WrapOverflow();
        }

        internal virtual bool WrapOverflow()
        {
            if (content.Count > 1)
            {
                //return true if length is greater than wrap
                return Length() > ((FillPage)page).wrap;
            }

            return false;
        }

        internal override void IntoText(StringBuilder text)
        {
            foreach (String word in content)
            {
                text.Append(word.ToString());
                text.Append(" ");
            }
            text.Remove(text.Length - 1, 1);
        }
    }
}
