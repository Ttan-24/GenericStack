using System.Windows;
using System.Windows.Input;

namespace GenericStack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainGrid.Focus();
        }

        // key is pressed
        private void HandleKey(object sender, KeyEventArgs e)
        {
            InputHandler.Input(e, MainTextBlock, StackHandler.myStack, StackHandler.memoryStack);
        }

        // key is released
        private void MainGrid_KeyUp(object sender, KeyEventArgs e)
        {
            InputHandler.KeyUp(e);
        }

        private void ClearButtonEvent(object sender, RoutedEventArgs e)
        {
            StackHandler.Clear(MainTextBlock);
            MainGrid.Focus(); 
        }

        private void OpenButtonEvent(object sender, RoutedEventArgs e)
        {
            // Read the file as one string.
            MainTextBlock.Text = FileHandler.Open(); 
        }

        private void SaveAsButtonEvent(object sender, RoutedEventArgs e)
        {
            FileHandler.SaveAs(MainTextBlock.Text);
        }
    }
}
