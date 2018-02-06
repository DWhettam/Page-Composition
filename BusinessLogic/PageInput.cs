using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public enum Format { Fill, FillSoft, FillAdjust, LineMoment, FillSet };

    public class PageInput
    {

        public Format format;

        public int wrap = 0;

        public int wrapSoft = 0;

        public int columnMoment = 0;

        public List<String> words;

        public PageInput()
        {
            words = new List<String>();
        }

        public PageInput(Format format, int wrap, int wrapSoft, int columnMoment, List<String> words)
        {
            this.format = format;
            this.wrap = wrap;
            this.wrapSoft = wrapSoft;
            this.columnMoment = columnMoment;
            this.words = words;
        }

        public Page Compose()
        {
            try
            {
                //switch on format
                switch (format)
                {
                    case Format.Fill:
                        {
                            //Create new page                        
                            FillPage page = new FillPage(wrap);

                            //Add words to page
                            page.Add(words);
                            return page;
                        }
                    case Format.FillSoft:
                        {
                            //Create new page
                            FillSoftPage page = new FillSoftPage(wrap, wrapSoft);

                            //Add words to page
                            page.Add(words);
                            page.FormatPage();
                            return page;
                        }
                    case Format.FillAdjust:
                        {
                            //Create new page
                            FillAdjustPage page = new FillAdjustPage(wrap);

                            //Add words to page
                            page.Add(words);
                            page.FormatPage();
                            return page;
                        }
                    case Format.LineMoment:
                        {
                            //Create new page
                            LineMomentPage page = new LineMomentPage(wrap, columnMoment);

                            //Add words to page
                            page.Add(words);
                            page.FormatPage();
                            return page;
                        }
                    case Format.FillSet:
                        {
                            //Create new page
                            FillSetPage page = new FillSetPage(wrap);

                            //Add words to page
                            page.Add(words);
                            return page;
                        }
                    default:
                        {
                            throw new Exception("Unknown format.");
                        }
                }
            }
            catch (Exception)
            {
                return null;                
            }            
        }
    }

}
