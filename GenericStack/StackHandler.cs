using System.Windows.Controls;
using GenericStackLibrary;
using System.Diagnostics;

namespace GenericStack
{
    // stack handler
    public class StackHandler
    {
        /* Class Description
	     * This class is for handling the stack which
	     * reads into the main text block.
	     */

        ///// Member Variables /////
        public static GenericStackClass<char> myStack = new GenericStackClass<char>();
        public static GenericStackClass<char> memoryStack = new GenericStackClass<char>();

        ///// Member Functions /////
        // Clears the stack
        public static void clear(TextBlock textBlock)
        {

            while (!myStack.isEmpty())
            {
                // clear all the text in the text editor
                myStack.pop();
            }
        }

        // Undoes the previously entered word in the stack
        public static void cltrlZ ()
        {
            while (myStack.top() != ' ' && myStack.size() > 1)
            {
                memoryStack.push(myStack.top());
                Trace.WriteLine(myStack.top());
                myStack.pop();
            }
            memoryStack.push(myStack.top());
            myStack.pop();
        }

        // Redoes the previously undone word in the stack
        public static void cltrlY ()
        {
            myStack.push(memoryStack.top());
            memoryStack.pop();
            while (memoryStack.top() != ' ' && memoryStack.size() > 1)
            {
                myStack.push(memoryStack.top());
                memoryStack.pop();
            }
            myStack.push(memoryStack.top());
            memoryStack.pop();
        }
    }
}
