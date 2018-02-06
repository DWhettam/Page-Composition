using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BusinessLogic
{

    public class FillSoftPage : Page
    {
        internal int wrap;
        internal int wrapSoft;

        /// <summary>
        /// FillPage constructor
        /// </summary>
        /// <param name="wrap"></param>
        internal FillSoftPage(int wrap, int wrapSoft)
        {
            //sets wrap
            this.wrap = wrap;
            if (wrapSoft <= wrap)
            {
                this.wrapSoft = wrapSoft;
            }
            else
            {
                this.wrapSoft = wrap;
            }
            content = new List<Line>();
            //create blank line
            AddLine();
        }

        internal override void Add(List<string> words)
        {
            base.Add(words);                
        }

        internal override bool Add(string word)
        {
            return base.Add(word);
        }

        internal void FormatPage()
        {
            bool pageUpdated = false;
            bool lineUpdated = false;

            do
            {
                pageUpdated = false;

                //loop through lines
                for (int i = 0; i < content.Count; i++)
                {
                    //if in 1st half             
                    if (i <= content.Count / 2)
                    {
                        do
                        {
                            //apply standard overflow
                            if (((FillSoftLine)content[i]).Overflow())
                            {
                                lineUpdated = true;
                                pageUpdated = true;

                                var currentLine = content[i].content;
                                var nextLine = content[i + 1].content;

                                //insert last item of current line onto next line
                                nextLine.Insert(0, currentLine[currentLine.Count - 1]);
                                currentLine.Remove(currentLine.Last());
                            }
                            else
                            {
                                lineUpdated = false;
                            }
                        } while (lineUpdated);
                    }
                    //2nd half
                    else
                    {
                        do
                        {
                            //apply WrapSoftOverflow
                            if (((FillSoftLine)content[i]).WrapSoftOverflow())
                            {
                                lineUpdated = true;
                                pageUpdated = true;

                                //if last line, add new line
                                if (i == content.Count - 1)
                                {
                                    AddLine();
                                }

                                var currentLine = content[i].content;
                                var nextLine = content[i + 1].content;

                                //insert last item of current line onto next line
                                nextLine.Insert(0, currentLine[currentLine.Count - 1]);
                                currentLine.Remove(currentLine.Last());
                            }
                            else
                            {
                                lineUpdated = false;
                            }
                        } while (lineUpdated);
                    }
                }
            } while (pageUpdated);
        }

        /// <summary>
        /// AddLine method
        /// </summary>
        internal override void AddLine()
        {
            //create new fill line, add line to content
            currentLine = new FillSoftLine(this);
            content.Add(currentLine);
        }

        internal override bool Overflow()
        {
            foreach (Line line in content)
            {
                if (line.Overflow())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
