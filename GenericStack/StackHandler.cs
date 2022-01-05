using System.Windows.Controls;
using GenericStackLibrary;
using System.Diagnostics;

namespace GenericStack
{
    // stack handler
    public class StackHandler
    {
        public static GenericStackClass<char> myStack = new GenericStackClass<char>();
        public static GenericStackClass<char> memoryStack = new GenericStackClass<char>();

        public static void Clear(TextBlock textBlock)
        {

            while (!myStack.isEmpty())
            {
                // clear all the text in the text editor
                myStack.pop();
            }
            // print the whole stack 
            textBlock.Text = myStack.toString();
        }

        public static void CltrlZ ()
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

        public static void CltrlY ()
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
