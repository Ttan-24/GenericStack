using System.Windows.Controls;
using System.Windows.Input;
using GenericStackLibrary;
using System.Diagnostics;

namespace GenericStack
{
    // input handler
    public static class InputHandler
    { 
        static bool checkControlKey;

        public static void Input(KeyEventArgs e, TextBlock mytext, GenericStackClass<char> myStack, GenericStackClass<char> memoryStack)
        {

            Trace.WriteLine(e.Key.ToString());

            // if control is pressed then set boolean to true allowing you to press control z later
            if (e.Key.ToString() == "LeftCtrl")
            {
                checkControlKey = true;
            }
            else if (checkControlKey)
            {
                // control z press for undo and redo
                if (e.Key.ToString() == "Z")
                {
                    StackHandler.CltrlZ();

                }
                if (e.Key.ToString() == "Y")
                {
                    StackHandler.CltrlY();
                }
            }
            else if (e.Key.ToString() == "Space")
            {
                myStack.push(' ');
            }
            else if (e.Key.ToString() == "Back")
            {
                myStack.pop();
            }
            else
            {
                // Normal characters
                char character = e.Key.ToString()[0];
                myStack.push(character);
            }

            // print the whole stack
            mytext.Text = myStack.toString();
        }

        // key is released
        public static void KeyUp(KeyEventArgs e)
        {
            if (e.Key.ToString() == "LeftCtrl")
            {
                checkControlKey = false;
            }
        }
    }
}
