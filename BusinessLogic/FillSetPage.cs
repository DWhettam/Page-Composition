using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class FillSetPage : FillPage
    {

        /// <summary>
        /// FillPage constructor
        /// </summary>
        /// <param name="wrap"></param>
        internal FillSetPage(int wrap) :base(wrap)
        {
            //sets wrap
            this.wrap = wrap;
            content = new List<Line>();
            //create blank line
            AddLine();
        }

        /// <summary>
        /// Add words override method
        /// </summary>
        /// <param name="words"></param>
        internal override void Add(List<string> words)
        {
            int iterator = 0;
            while (iterator < words.Count)
            {
                if (!validWord(words[iterator]))
                {
                    words.Remove(words[iterator]);
                    continue;
                }
                iterator++;
            }
                  

            //sorts words into descending order
            var sortedWords = words
                .OrderByDescending(x => x.Length).ToList();

            do
            {
                int i = 0;
                while (i < sortedWords.Count)
                {
                    //Attempt to add word
                    if (this.Add(sortedWords[i]))
                    {                 
                        //if added, remove word from list       
                        sortedWords.Remove(sortedWords[i]);
                        continue;
                    }
                    //increment interator
                    i++;
                }        
                //Add new line       
                AddLine();                
            } while (sortedWords.Count != 0);            
        }

        internal override bool validWord(string word)
        {
            return base.validWord(word);
        }

        /// <summary>
        /// Add word override method
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        internal override bool Add(string word)
        {
            //Attempt to add word to current line
            if (currentLine.Add(word))
            {
                return true;
            }
            return false;     
        }
    }
}

