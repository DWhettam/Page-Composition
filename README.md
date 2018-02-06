# Page-Composition
University of Hull Software Engineering module coursework. Page Composition formats a page of text in a according to 5 defined specifications. The project specification was given as follows:

Write a program to compose a page of text given a sequence of alphanumeric strings as
input. Some of the strings may be words. A word consists of a non-empty sequence of
lower case letters from a-z. A word must contain a vowel and words of length greater
than 3 must contain at least two. All the vowels of a word must appear in alphabetical
order. A line is a sequence of characters. The input words only must be placed on lines.
A sequence of lines constitutes a page. All lines should end with the line termination
character (i.e. ‘\n’). The length of a line is the sum of the characters on that line
excluding the final ‘\n’. The various text formats required are listed below:  

1. Fill – The position of any character on a line defines a column. The first word on any
line must begin at the first column. The words should be concatenated, preserving the
input order, together with a single space separating any two words on the same line.
No other spaces should be present on the line. A wrap column is a non-negative
integer used to limit the length of a line. No line containing two or more words may
be longer than the wrap column. Only when no additional words may be placed on a
line should the additional words should be placed on the next line.  

2. FillSoft – The page should be formatted as in Fill, above, but in addition to the wrap
column, there is a soft wrap column that is less than or equal to the wrap column. A
line containing two or more words may not have a length greater than the soft wrap
column unless the position of the line on the page is less than or equal to half the
number of lines on the page.  

3. FillAdjust - the words should be formatted as in Fill, above, except that for lines with
two or more words, one or more spaces must separate any two words on the same
line and the last letter of the last word on any line must be on the wrap column. The
number of spaces between words should, as far as possible, be equal. Where the
inter-word space counts are not equal, as far as possible, the larger space counts
should separate the words with the highest total number of vowels.  

4. LineMoment - The moment of a letter in a word about a column is the product of the
distance of a letter from the column and the value of the letter. The distance of a
letter from a given column is the column of the letter less the given column. The
value of a letter is the position of the letter in the alphabet, i.e. a = 1, b = 2, etc. The
moment of a word is the sum of the moments of the letters in the word. The moment
of a line about a given column is the sum of the moments of the words on that line.
The page should be formatted as in Fill, above except that words may be separated by
one or more spaces and the absolute value of the moment of each line about a given
column should be minimal. and the most separated words should be at the front of the
line  

5. FillSet – The page should be formatted as in Fill, above except that the order of the
words on the page need not correspond to the order of the words in the input. The
number of lines on the page should be minimal.
