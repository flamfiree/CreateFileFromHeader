using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Table = Microsoft.Office.Interop.Word.Table;

namespace WindowsFormsApp1
{
    class FileService
    {
        //private static int tableCounter = 1; // Счетчик таблиц

        public static void DocxCreate(string path, List<Structure> ChosenStructures)
        {
            int tableCounter = 1;
            using (DocX document = DocX.Create(path))
            {
                foreach (Structure structure in ChosenStructures)
                {
                    document.InsertParagraph($"Таблица {tableCounter} - {structure.Name}").Bold().FontSize(14d).SpacingAfter(20d);
                    tableCounter++;

                    var table = document.AddTable(structure.Lines.Count + 1, 4);
                    table.Design = TableDesign.TableGrid;
                    table.Alignment = Alignment.center;

                    // Заполнение заголовков таблицы
                    table.Rows[0].Cells[0].Paragraphs.First().Append("Название элемента структуры");
                    table.Rows[0].Cells[1].Paragraphs.First().Append("Код параметра");
                    table.Rows[0].Cells[2].Paragraphs.First().Append("Наименование параметра (сигнала)");
                    table.Rows[0].Cells[3].Paragraphs.First().Append("Примечание");

                    for (int i = 0; i < structure.Lines.Count; i++)
                    {
                        Line line = structure.Lines[i];

                        table.Rows[i + 1].Cells[0].Paragraphs.First().Append(line.Name);
                        table.Rows[i + 1].Cells[1].Paragraphs.First().Append(line.DataType);
                        table.Rows[i + 1].Cells[2].Paragraphs.First().Append(line.Description);
                        table.Rows[i + 1].Cells[3].Paragraphs.First().Append(line.Note);
                    }

                    document.InsertTable(table);
                    document.InsertParagraph();
                }

                document.Save();
            }
        }
        public static void PdfCreate(string path, List<Structure> ChosenStructures)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            int tableCounter = 1;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                foreach (Structure structure in ChosenStructures)
                {
                    //document.Add(
                    //    new iTextSharp.text.Paragraph(
                    //        $"Таблица {tableCounter} - {structure.Name}", 
                    //        new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD)
                    //        )
                    //    );

                    document.Add(
                        new iTextSharp.text.Paragraph($"Таблица {tableCounter} - {structure.Name}",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)
                        )
                        );

                    tableCounter++;

                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 2f, 1f, 3f, 2f });

                    // Заполнение заголовков таблицы
                    table.AddCell(GetPdfCell("Название элемента структуры"));
                    table.AddCell(GetPdfCell("Код параметра"));
                    table.AddCell(GetPdfCell("Наименование параметра (сигнала)"));
                    table.AddCell(GetPdfCell("Примечание"));

                    foreach (Line line in structure.Lines)
                    {
                        table.AddCell(GetPdfCell(line.Name));
                        table.AddCell(GetPdfCell(line.DataType));
                        table.AddCell(GetPdfCell(line.Description));
                        table.AddCell(GetPdfCell(line.Note));
                    }

                    document.Add(table);
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                }

                document.Close();
                writer.Close();
                fileStream.Close();
            }
        }

        private static PdfPCell GetPdfCell(string text)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            return cell;
        }
    }
}
