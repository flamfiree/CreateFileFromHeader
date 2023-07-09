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
                        currentStructure.Name = line.Substring(15).TrimEnd(' ');
                        currentStructure.Lines = new List<Line>();
                    }
                    else if (line.Contains(":") && line.Contains("//"))
                    {
                        string[] parts = line.Split(':');
                        string dataType = parts[0].Trim();
                        string name = parts[1].Split(';')[0].Trim();

                        Line newLine = new Line();
                        newLine.DataType = dataType;
                        newLine.Name = name;

                        int startIndex = line.IndexOf("//") + 2;
                        string descriptionNote = line.Substring(startIndex).Trim();
                        int noteStartIndex = descriptionNote.IndexOf('(');

                        if (noteStartIndex != -1)
                        {
                            newLine.Description = descriptionNote.Substring(0, noteStartIndex).Trim();
                            newLine.Note = descriptionNote.Substring(noteStartIndex).Trim('(', ')');
                        }
                        else
                        {
                            newLine.Description = descriptionNote.Trim();
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

            return structures;
        }




        //public static List<Structure> ParseStructures(string filePath)
        //{
        //    List<Structure> structures = new List<Structure>();

        //    string fileContent = File.ReadAllText(filePath);

        //    string pattern = @"typedef struct([\s\S]*?)\}([\s\S]*?);";

        //    MatchCollection matches = Regex.Matches(fileContent, pattern);

        //    foreach (Match match in matches)
        //    {
        //        string structureContent = match.Groups[1].Value;
        //        string structureName = match.Groups[2].Value.Trim();

        //        Structure structure = new Structure
        //        {
        //            Name = structureName,
        //            Lines = ParseLines(structureContent),
        //            Description = ""
        //        };

        //        structures.Add(structure);
        //    }
        //    return structures;
        //}


        //private static List<Line> ParseLines(string structureContent)
        //{
        //    List<Line> lines = new List<Line>();

        //    string pattern = @"(\w+)\s+(\w+)\s*:\s*(\d+)\s*;\s*\/\/!<\s*\[(.*?)\]\s*(.*)";

        //    MatchCollection matches = Regex.Matches(structureContent, pattern);

        //    foreach (Match match in matches)
        //    {
        //        string dataType = match.Groups[1].Value;
        //        string lineName = match.Groups[2].Value;
        //        string bitSize = match.Groups[3].Value;
        //        string description = match.Groups[4].Value.Trim();
        //        string note = match.Groups[5].Value.Trim();

        //        Line line = new Line
        //        {
        //            Name = lineName,
        //            DataType = dataType,
        //            Description = description,
        //            Note = note
        //        };

        //        lines.Add(line);
        //    }

        //    return lines;
        //}

    }
}
