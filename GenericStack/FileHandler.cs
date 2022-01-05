using System.IO;
using Microsoft.Win32;

namespace GenericStack
{
    // file handler
    public static class FileHandler
    {
        public static string Open()
        {
            // Read the file as one string.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                return text;
            }
            return "";
        }

        public static void SaveAs(string textInFile)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllTextAsync(saveFileDialog.FileName, textInFile);
            }
        }
    }
}
