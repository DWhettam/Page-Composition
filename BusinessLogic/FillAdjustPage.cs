using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class FillAdjustPage : FillPage
    {
        /// <summary>
        /// FillPage constructor
        /// </summary>
        /// <param name="wrap"></param>
        internal FillAdjustPage(int wrap):base(wrap)
        {
            //sets wrap
            this.wrap = wrap;
            content = new List<Line>();
            //create blank line
            AddLine();
        }

        internal void FormatPage()
        {
            foreach (Line line in content)
            {
                if (line.content.Count >=2 && line.ToString().Length != wrap)
                {
                    while (line.ToString().Length <= wrap - (line.content.Count - 1))
                    {
                        for (int i = 0; i < line.content.Count - 1; i++)
                        {
                            line.content[i] += " ";
                        }
                        if (line.ToString().Length == wrap)
                        {
                            break;
                        }
                    }

                    if (line.ToString().Length < wrap)
                    {
                        List<string> inputOrderedByVowelCount = vowelCount(line);

                        bool incremented = false;
                        int wordIndex = 0;

                        while (wordIndex < line.content.Count && line.ToString().Length < wrap)
                        {
                            string currentWord = line.content[wordIndex];

                            if (currentWord == inputOrderedByVowelCount[0])
                            {
                                if (line.content.Count - 1 != wordIndex)
                                {
                                    currentWord += " ";
                                }
                                else
                                {
                                    currentWord = currentWord.Insert(0, " ");
                                }

                                inputOrderedByVowelCount.RemoveAt(0);
                                line.content[wordIndex] = currentWord;
                                wordIndex++;
                                incremented = true;
                                break;
                            }
                            
                            if (!incremented)
                            {
                                wordIndex++;
                            }                                                      
                        }                           
                    }
                }                                
            }
        }

        internal List<string> vowelCount(Line line)
        {         
            List<string> inputOrderedByVowelCount = new List<string>();

            //populate list with line           
            foreach (string word in line.content)
            {
                inputOrderedByVowelCount.Add(word);
            }            

            //sort line in order of vowel count
            inputOrderedByVowelCount = inputOrderedByVowelCount.OrderByDescending(x => x.ToCharArray().Count(y => "aeoui".ToCharArray().Contains(y)).ToString()).ToList();

            return inputOrderedByVowelCount;
        }
    }
}
