using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class LineMomentPage : FillPage
    {
        internal int columnMoment;

        /// <summary>
        /// LineMomentPage constructor
        /// </summary>
        /// <param name="wrap"></param>
        internal LineMomentPage(int wrap, int columnMoment):base(wrap)
        {
            //sets wrap
            this.wrap = wrap;
            this.columnMoment = columnMoment;
            content = new List<Line>();
            //create blank line
            AddLine();
        }

        /// <summary>
        /// Get letter moment
        /// </summary>
        /// <param name="currentChar"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        internal int GetLetterMoment(char currentChar, int column)
        {
            int moment = 0;
            int value = (int)currentChar % 32;
            int distance = column - columnMoment;

            moment = value * distance;
            return moment;
        }

        /// <summary>
        /// Get word moment
        /// </summary>
        /// <param name="currentWord"></param>
        /// <param name="startingColumn"></param>
        /// <returns></returns>
        internal int GetWordMoment(string currentWord, int startingColumn)
        {
            int moment = 0;
            int column = startingColumn;

            foreach (char letter in currentWord)
            {
                moment += GetLetterMoment(letter, column);
                column++;
            }

            return moment;
        }

        /// <summary>
        /// Get line moment
        /// </summary>
        /// <param name="currentLine"></param>
        /// <returns></returns>
        internal int GetLineMoment(Line currentLine)
        {
            int moment = 0;
            int startingColumn = 1;

            foreach (String word in currentLine.content)
            {                
                moment += GetWordMoment(word, startingColumn);
                startingColumn += word.Length + 1;
            }

            return moment;
        }

        /// <summary>
        /// Format page
        /// </summary>
        internal void FormatPage()
        {
            for (int i = 0; i < content.Count; i++)
            {
                bool nextLine = false;
                int bestValue;
                int oldMoment = GetLineMoment(content[i]);
                int workingMoment;
                string bestValueState = "";
                Line workingLine = content[i];

                //while more than 1 item on line, still working on same line and line less than wrap
                while (workingLine.content.Count > 1 && !nextLine && (workingLine.ToString().Length < wrap))
                {
                    //get moment for line before alteration
                    oldMoment = GetLineMoment(workingLine);

                    //if moment >= 0, this is the smallest possible moment, go to next line
                    if (oldMoment >= 0)
                    {                        
                        nextLine = true;
                        break;
                    }

                    //add space after first word, get moment
                    workingLine.content[0] += " ";
                    workingMoment = GetLineMoment(workingLine);

                    //if hit wrap, or moment = 0, go to next line
                    if (workingLine.ToString().Length == wrap || workingMoment == 0)
                    {                        
                        nextLine = true;
                        break;
                    }

                    //if moment has switched base
                    if ((oldMoment < 0 && workingMoment > 0))
                    {
                        int iterator = 1;
                        int maxSpaces = content[i].content[0].Count(f => f == ' ') + 1;
                        int currentSpaces = 1;

                        //if moment before base switch is smaller, set best value
                        if (Math.Abs(oldMoment) < Math.Abs(workingMoment))
                        {
                            bestValue = Math.Abs(oldMoment);                           
                        }
                        //if moment after base switch is smaller, set best value
                        else
                        {                            
                            bestValue = Math.Abs(workingMoment);                           
                        }

                        //store state of best value, restore line to previous state
                        bestValueState = workingLine.ToString();
                        content[i].content[0] = workingLine.content[0].Remove(workingLine.content[0].Length - 1);
                        workingLine = content[i];

                        while (iterator < workingLine.content.Count - 1)
                        {
                            //add space in between next 2 words
                            workingLine.content[iterator] += " ";
                            currentSpaces++;

                            //if moment = 0, go to next line
                            if (GetLineMoment(workingLine) == 0)
                            {                              
                                nextLine = true;
                                break;
                            }

                            //get new moment after adding space
                            int newMoment = Math.Abs(GetLineMoment(workingLine));

                            //if new moment is better than previous, assign new best
                            if (newMoment < bestValue)
                            {
                                bestValue = newMoment;
                                bestValueState = workingLine.ToString();
                            }
                            //otherwise, remove last space, restore best value state, go to new line
                            else
                            {
                                content[i].Replace(bestValueState);                               

                                nextLine = true;
                                break;
                            }

                            //once no more spaces can be added, add spaces between next set of words
                            if (currentSpaces == maxSpaces)
                            {
                                iterator++;
                                currentSpaces = 1;
                            }
                        }

                        content[i].Replace(bestValueState);                        

                        //go to next line
                        nextLine = true;
                        break;
                    }

                    //if positive starting moment, go to next line
                    else if (oldMoment > 0 && workingMoment > oldMoment)
                    {
                        nextLine = true;
                        break;
                    }

                    oldMoment = workingMoment;
                }
            }
        }
    }
}
