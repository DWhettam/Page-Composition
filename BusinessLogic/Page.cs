using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BusinessLogic
{

    public abstract class Page
    {

        internal List<Line> content;

        internal Line currentLine;

        internal abstract bool Overflow();

        /// <summary>
        /// Page Add method. Adds words to a page
        /// </summary>
        /// <param name="words"></param>
        internal virtual void Add(List<String> words)
        {      
            foreach (String w in words)
            {
                this.Add(w);
            }
        } 

        /// <summary>
        /// Page Add method. Adds word to a page
        /// </summary>
        /// <param name="word"></param>
        internal virtual bool Add(String word)
        {                       
            if (validWord(word))
            {
                //tries to add a word to the current line
                if (!currentLine.Add(word))
                {
                    //if fails to add word to line, create new line, and attempt to add word to new line
                    AddLine();
                    Add(word);
                }
                return true;
            }
            return false;            
        }

        internal virtual bool validWord(String word)
        { 
            var vowels = word
                .Where(c => "aeiou".Contains(c));

            bool inOrder = vowels.SequenceEqual(vowels.OrderBy(c => c));

            if (inOrder && !(word.Any(Char.IsUpper)) && !(word.Any(Char.IsPunctuation)) && !(word.Any(Char.IsDigit)))
            {
                if (word.Length > 3)
                {
                    if (vowels.Count() >= 2)
                    {
                        return true;
                    }
                }
                else if (vowels.Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal abstract void AddLine();

        internal void IntoText(StringBuilder text)
        {
            foreach (Line line in content)
            {
                if (line.content.Count > 0)
                {
                    line.IntoText(text);
                    text.Append("\n");
                }                                                           
            }
        }

        public virtual void ToFile(String fileName)
        {
            StringBuilder outText = new StringBuilder();
            IntoText(outText);
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(outText.ToString());
                }
            }
            catch (Exception e)
            {
                String message = "Failed to write output file: " + e.Message;
                Console.WriteLine(message);
                throw new Exception(message);
            }
        }

        public override String ToString()
        {
            StringBuilder outText = new StringBuilder();
            IntoText(outText);
            return outText.ToString();
        }

    }
}
