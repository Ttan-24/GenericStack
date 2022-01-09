using System;
using System.ComponentModel.DataAnnotations;

namespace GenericStackLibrary
{
	public class GenericStackClass<T>
	{
		/* Class Description
		 * This class is a Last-In/First-Out (LIFO) stack
		 * implemented with a generic type (T)
		 */

		///// Member Data /////
		public T[] arr = new T[50];
		public int countIndex = 0;

		///// Member Functions /////
		// Push new values to stack
		public void push(T value)
		{
			if (countIndex > 49)
			{
				throw new IndexOutOfRangeException("Index out of bounds! Stack is full");
			}
			else
			{
				arr[countIndex] = value;
				countIndex++;
			}
		}
		// Get the top variable in the stack (the last to be pushed and first to be popped)
		public T top()
		{
			return arr[countIndex - 1]; // since array start from zero index 
		}
		// Pop the top member variable from the stack
		public void pop()
		{
			if (isEmpty())
			{
				Console.WriteLine("The array is already empty");
				throw new IndexOutOfRangeException("Array empty!");
			}
			else
			{
				countIndex--;
			}
		}
		// Get the size of the stack
		public int size()
		{
			return countIndex;
		}
		// Check if there is no data in the stack
		public bool isEmpty()
		{
			if (countIndex == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		// Convert the stack to a string. This function can be overridden for display purposes
		public virtual string toString()
		{
			string emptyString = "";
			for (int i = 0; i < countIndex; i++)
			{
				emptyString += arr[i];
			}
			return emptyString;
		}
		// Get the stack variable at a specific index
		public T get(int i)
		{
			return arr[i];
		}
	}
}
