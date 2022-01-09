using System;
using System.Windows;
using System.Windows.Input;


namespace GenericStack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initialise main window component
        public MainWindow()
        {
            InitializeComponent();

            MainGrid.Focus();
        }

        // Handle keypresses via InputHandler
        private void handleKey(object sender, KeyEventArgs e)
        {
            try
            {
                InputHandler.Input(e.Key, MainTextBlock);
            }
            catch (IndexOutOfRangeException exception)
            {
                ErrorTextBox.Text = exception.ToString();
            }
        }

        // Handle key releases via InputHandler
        private void mainGrid_KeyUp(object sender, KeyEventArgs e)
        {
            InputHandler.KeyUp(e.Key);
        }

        // Clear MainTextBlock
        private void clearButtonEvent(object sender, RoutedEventArgs e)
        {
            StackHandler.clear(MainTextBlock);
            MainTextBlock.Text = StackHandler.myStack.toString();
            MainGrid.Focus(); 
        }

        // Open text from a file and fill MainTextBlock
        private void openButtonEvent(object sender, RoutedEventArgs e)
        {
            // Read the file as one string.
            MainTextBlock.Text = FileHandler.open(); // Exception here
        }

        // Save MainTextBlock text in a text file
        private void saveAsButtonEvent(object sender, RoutedEventArgs e)
        {
            FileHandler.saveAs(MainTextBlock.Text);
        }

        // Print MainTextBlock text (as a PDF or open a dialog)
        private void printButtonEvent(object sender, RoutedEventArgs e)
        {
            // Create print dialog
            DeviceManager.PrintPDF(MainTextBlock.Text, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }
    }
}
