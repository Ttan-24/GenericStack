using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace GenericStack
{
    public static class InputHandler
    {
        /* Class Description
         * This class is a Last-In/First-Out (LIFO) stack
         * implemented with a generic type (T)
         */
        ///// Member Data /////
        static bool checkControlKey;

        ///// Member Functions /////
        // Handles general key press input from the keyboard
        public static void Input(Key key, TextBlock mytext)
        {

            Trace.WriteLine(key.ToString());

            // if control is pressed then set boolean to true allowing you to press control z later
            if (key.ToString() == "LeftCtrl")
            {
                checkControlKey = true;
            }
            else if (checkControlKey)
            {
                // control z press for undo and redo
                if (key.ToString() == "Z")
                {
                    StackHandler.cltrlZ();

                }
                if (key.ToString() == "Y")
                {
                    StackHandler.cltrlY();
                }
            }
            else if (key.ToString() == "Space")
            {
                StackHandler.myStack.push(' ');
            }
            else if (key.ToString() == "Back")
            {
                StackHandler.myStack.pop();
            }
            else
            {
                HandleRegularKeypress(key);
            }

            // print the whole stack
            mytext.Text = StackHandler.myStack.toString();
        }

        public static void HandleRegularKeypress(Key key)
        {
            // Normal characters
            char character = key.ToString()[0];
            try
            {
                StackHandler.myStack.push(character);
            }
            catch (System.IndexOutOfRangeException exception)
            {
                throw new System.IndexOutOfRangeException("Stack is full and cannot accept further input");
            }
        }

        // Handles key depresses
        public static void KeyUp(Key key)
        {
            if (key.ToString() == "LeftCtrl")
            {
                checkControlKey = false;
            }
        }
    }
}
