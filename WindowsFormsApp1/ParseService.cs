using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    class ParseService
    {

        public static List<Structure> ParseFile(string filePath)
        {
            List<Structure> structures = new List<Structure>();
            Structure currentStructure = null;

            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1251")))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.StartsWith("//!"))
                    {
                        if (currentStructure != null)
                        {
                            structures.Add(currentStructure);
                        }

                        currentStructure = new Structure();

                        currentStructure.Description = line.Substring(3).Trim();
                    }
                    else if (line.StartsWith("typedef struct"))
                    {
                        currentStructure.Name = line.Substring(15).TrimEnd('{');
                        currentStructure.Lines = new List<Line>();
                    }
                    else if (line.Contains(":") && line.Contains("//"))
                    {
                        string[] parts = line.Split(':');
                        string name = parts[0].Trim();
                        string dataType = parts[1].Split(';')[0].Trim();

                        Line newLine = new Line();
                        newLine.DataType = dataType;
                        newLine.Name = name;

                        int startIndex = line.IndexOf("//!<") + 2; // или "//"
                        string descriptionNote = line.Substring(startIndex).Trim();
                        int noteStartIndex = descriptionNote.IndexOf("//(");

                        if (noteStartIndex != -1)
                        {
                            newLine.Description = descriptionNote.Substring(2, noteStartIndex).TrimEnd("//".ToCharArray());// вместо 0 ставим 2
                            newLine.Note = descriptionNote.Substring(noteStartIndex).TrimStart("//".ToCharArray()); //.Trim('(', ')')
                        }
                        else
                        {
                            newLine.Description = descriptionNote.Trim().TrimStart("!<".ToCharArray());//new char[] { '!','<'}
                            newLine.Note = "-";
                        }

                        currentStructure.Lines.Add(newLine);
                    }
                }

                if (currentStructure != null)
                {
                    structures.Add(currentStructure);
                }
            }

            structures.RemoveAll(str => str.Name == null);
            return structures;
        }
    }
}
