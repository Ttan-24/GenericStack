using System.IO;
using Microsoft.Win32;

namespace GenericStack
{  
    public static class FileHandler
    {
        /// <summary>
        /// Class Description
        /// This class is for handling file opening and saving
        /// </summary>

        // Opens a file using a user dialog
        public static string open()
        {
            // Read the file as string
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                return text;
            }
            return "";
        }
        // Saves a file using a user dialog
        public static void saveAs(string textInFile)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllTextAsync(saveFileDialog.FileName, textInFile);
            }
        }
    }
}
