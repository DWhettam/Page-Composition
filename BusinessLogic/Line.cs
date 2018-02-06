using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public abstract class Line
    {

        internal List<String> content = new List<String>();

        internal Page page;

        internal Line(Page page)
        {
            this.page = page;
        }

        internal abstract int Length();

        internal abstract bool Overflow();

        /// <summary>
        /// Line Add method. Adds a word to the line
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        internal bool Add(String word)
        {
           
                //add the word to content
                content.Add(word);
                //check if overflows
                if (!Overflow())
                {
                    //if no overflow, return true
                    return true;
                }
                //if overflowed
                else
                {
                    //remove last item from content and return false
                    content.RemoveAt(content.Count - 1);
                    return false;
                }
  
           
        }

        internal void Replace(string line)
        {
            content.Clear();
            string word = "";

            for (int i = 0; i < line.Length; i++)
            {                
                if (!(line[i] == ' ' && Char.IsLetter(line[i+1])))
                {
                    word += line[i];
                }
                else
                {
                    content.Add(word);
                    word = "";
                }
            }
            content.Add(word);
        }

        internal abstract void IntoText(StringBuilder text);

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();
            this.IntoText(text);
            return text.ToString();
        }

    }
}
