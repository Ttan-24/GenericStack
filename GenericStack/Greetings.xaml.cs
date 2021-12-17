﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GenericStackLibrary;
using System.Diagnostics;
using System.IO;

namespace GenericStack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenericStackClass<char> myStack = new GenericStackClass<char>();
        GenericStackClass<char> memoryStack = new GenericStackClass<char>();
        //DispatcherTimer timer = new DispatcherTimer();
        //int time = 0;
        Boolean checkControlKey;
        Boolean handled;

        public MainWindow()
        {
            InitializeComponent();

            MainGrid.Focus();

            //timer.Tick += HandleTick;
            //timer.Interval = TimeSpan.FromMilliseconds(100);
            //timer.Start();
        }

        

        private void HandleTick(object sender, EventArgs e)
        {
            //time += 1;
            //MainTextBlock.Text = time.ToString();
        }

        // key is pressed
        private void HandleKey(object sender, KeyEventArgs e)
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
                    while(myStack.top() != ' ' && myStack.size() > 1)
                    {
                        memoryStack.push(myStack.top());
                        Trace.WriteLine(myStack.top());
                        myStack.pop();
                    }
                    memoryStack.push(myStack.top());
                    myStack.pop();

                }
                if (e.Key.ToString() == "Y")
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
            MainTextBlock.Text = myStack.toString();
        }

        // key is released
        private void MainGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "LeftCtrl")
            {
                checkControlKey = false;
            }
        }

        private void ClearButtonEvent(object sender, RoutedEventArgs e)
        {
            
            while (!myStack.isEmpty())
            {
                // clear all the text in the text editor
                //MainTextBlock.Text.Remove(0);
                myStack.pop();
            }
            // print the whole stack 
            MainTextBlock.Text = myStack.toString();
            MainGrid.Focus(); 
        }

        private void OpenButtonEvent(object sender, RoutedEventArgs e)
        {
            // Read the file as one string.
            string text = System.IO.File.ReadAllText(FileTextBox.Text);
            MainTextBlock.Text = text;
        }

        private void SaveAsButtonEvent(object sender, RoutedEventArgs e)
        {
            File.WriteAllTextAsync(FileTextBox.Text, MainTextBlock.Text);

        }
    }
}
