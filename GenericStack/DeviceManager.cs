using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;


namespace GenericStack
{
    public class DeviceManager
    {
        /// <summary>
        /// Device manager for handling hardware devices
        /// Currently used for printing services for the
        /// stack in the WPF document
        /// </summary>


        ///// Member Variables /////
        private static string mText;


        ///// Member Functions /////
        
        // Function for printing using a printer dialog
        private static void Print(string text, string path)
        {
            // Create print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.PageRangeSelection = PageRangeSelection.AllPages;
            printDialog.UserPageRangeEnabled = true;

            // Display print dialog
            bool? print = printDialog.ShowDialog();
            if (print == true)
            {
                XpsDocument doc = new XpsDocument(path, FileAccess.ReadWrite);
                FixedDocumentSequence fixedDocumentSequence = doc.GetFixedDocumentSequence();
                printDialog.PrintDocument(fixedDocumentSequence.DocumentPaginator, text);
            }
        }

        // Function for printing directly to PDF
        public static void PrintPDF(string text, string path)
        {
            // Set file name and text
            string fileName = "OOMStackPrinted.pdf";
            mText = text;

            // Print document
            PrintDocument printDocument = new PrintDocument();

            // Printer settings
            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = System.IO.Path.Combine(path, fileName);

            // Print page
            printDocument.PrintPage += new PrintPageEventHandler(Print_Page);
            printDocument.Print();
        }

        // Event handler function for PDF printing
        private static void Print_Page(object sender, PrintPageEventArgs e)
        {
            // Create font
            Font font = new Font("Arial", 16);

            // Print text into designated PDF
            e.Graphics.DrawString(mText, font, System.Drawing.Brushes.Black, 0, 0);
        }
    }
}
