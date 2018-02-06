using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic {

  public class FillPage : Page {

    internal int wrap;

    /// <summary>
    /// FillPage constructor
    /// </summary>
    /// <param name="wrap"></param>
    internal FillPage(int wrap) {
      //sets wrap
      this.wrap = wrap;
      content = new List<Line>();
      //create blank line
      AddLine();
    }

    /// <summary>
    /// AddLine method
    /// </summary>
    internal override void AddLine() {
      //create new fill line, add line to content
      currentLine = new FillLine(this);
      content.Add(currentLine);
    }

    internal override bool Overflow() {
      foreach (Line line in content) {
        if (line.Overflow()) {
          return true;
        }
      }
      return false;
    }
  }
}
