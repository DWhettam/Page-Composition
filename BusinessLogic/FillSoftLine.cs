using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class FillSoftLine : Line
    {

        internal FillSoftLine(FillSoftPage page) : base(page)
        {
        }

        /// <summary>
        /// Length method. GEts the length of a word
        /// </summary>
        /// <returns></returns>
        internal override int Length()
        {
            int result = 0;

            for (int i = 0; i < content.Count; i++)
            {
                String word = content[i];

                result += word.Length;

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

        internal bool WrapOverflow()
        {
            if (content.Count > 1)
            {
                //return true if length is greater than wrap
                return Length() > ((FillSoftPage)page).wrap;
            }
            return false;
        }
        internal bool WrapSoftOverflow()
        {
            if (content.Count > 1)
            {
                //return true if length is greater than wrap
                return Length() > ((FillSoftPage)page).wrapSoft;
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
