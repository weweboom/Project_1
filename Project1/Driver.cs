﻿//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Driver.cs
//	Description:    Displays the menu loop and provides examples of the classes in the project
//	Course:			CSCI 2210-001 - Data Structures
//	Authors:		Chance Reichenberg, reichenberg@etsu.edu, Duncan Perkins, perkinsdt@goldmail.etsu.edu, Chris Harris, harriscr1@goldmail.etsu.edu  Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 5, 2015
//	Copyright:		Chance Reichenberg, Duncan Perkins 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace Project1
{
    /// <summary>
    /// Driver class for Project 1 
    /// </summary>
    class Driver
    {
        /// <summary>
        /// Main method to demonstrate various classes and functionality of Project 1
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "CSCI2210 - Project 1 by Chance Reichenberg, Duncan Perkins and Chris Harris";
            Console.Clear();

            Utility.WelcomeMessage("Computer Science 2210 Project 1", " Chance Reichenberg", " Duncan Perkins", " Chris Harris");
            //Variables to temporarily hold user information to be passed
            string name, email, phone;

            //Variable used to end user input
            bool isValid = true;
            User person = null;

            try
            {

                Console.WriteLine("What is the name of the user?");
                name = Console.ReadLine();
                Console.WriteLine("\nWhat is {0}'s phone number?", name);
                phone = Console.ReadLine();
                Console.WriteLine("\nWhat is {0}'s email address?", name);
                email = Console.ReadLine();

                //User object created using values user entered.
                person = new User(name, phone, email);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isValid = false;
                Console.WriteLine("\nThe Data you entered was not valid. Try Again.");
                Console.WriteLine("\n\n");
            }
            while (!isValid)
            {
                isValid = true;
                try
                {
                    //Retrieve user information
                    Console.WriteLine("What is the name of the user?");
                    name = Console.ReadLine();
                    Console.WriteLine("\nWhat is {0}'s phone number?", name);
                    phone = Console.ReadLine();
                    Console.WriteLine("\nWhat is {0}'s email address?", name);
                    email = Console.ReadLine();

                    //User object created using values user entered.
                    person = new User(name, phone, email);


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    isValid = false;
                    Console.WriteLine("\nThe Data you entered was not valid. Try Again.");
                    Console.WriteLine("\n\n");
                }


            }//End While

            Text textData;
            Menu menu = new Menu("Project 1 Options");

            menu = menu + "Words from the File" + "Sentences from the File" + "Paragraphs from the File" + "Quit";

            string line, inputText;
            int textChoice;
            Choices choice = (Choices)menu.GetChoice();

            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                    //Case that displays Distinct Word and Words classes
                    case Choices.WORDS:

                        Utility.Skip(2);

                        //Output to ask for user input
                        Console.WriteLine("\nEnter a '0' if you wish to open a file.\n\nEnter '1' if you wish to enter a text string.");
                        line = Console.ReadLine();

                        //Takes user input and determines if it is valid or not
                        while (!Int32.TryParse(line, out textChoice) || Int32.Parse(line) < 0 || Int32.Parse(line) > 1)
                        {
                            Console.WriteLine("You did not enter a '0' or '1'. Try Again.");
                            line = Console.ReadLine();
                        }//End While

                        //Decision statement to ask for a string input or to open a file
                        if (textChoice == 0)
                        {
                            textData = new Text();

                        }
                        else
                        {
                            Console.WriteLine("Please enter the string you wish to evaluate below.");
                            inputText = Console.ReadLine();
                            textData = new Text(inputText, 1);
                        }//End if

                        Utility.Skip(2);

                        
                        //Create the text object
                        Words textWords = new Words(textData);

                        //Outputs the words class
                        textWords.Display();

                        Console.ReadKey();
                        break;

                    case Choices.SENTENCES:
                    Utility.Skip(2);

                        //Output to ask for user input
                        Console.WriteLine(" Enter a '0' if you wish to open a file.\n Enter '1' if you wish to enter a text string.");
                        line = Console.ReadLine();

                        //Takes user input and determines if it is valid or not
                        while (!Int32.TryParse(line, out textChoice) || Int32.Parse(line) < 0 || Int32.Parse(line) > 1)
                        {
                            Console.WriteLine("You did not enter a '0' or '1'. Try Again.");
                            line = Console.ReadLine();
                        }//End While

                        //Decision statement to ask for a string input or to open a file
                        if (textChoice == 0)
                        {
                            textData = new Text();

                        }
                        else
                        {
                            Console.WriteLine("Please enter the string you wish to evaluate below.");
                            inputText = Console.ReadLine();
                            textData = new Text(inputText, 0);
                        }//End if

                        Utility.Skip(2);

                        //Creates the SentenceList passing in the text object
                        SentenceList s = new SentenceList(textData);

                        //Outputs the SentenceList and it's stats 
                        s.Display();

                        Console.ReadKey();
                        break;


                    //Case that displays the paragraph and paragraphlist classes
                    case Choices.PARAGRAPHS:
                        Utility.Skip(2);

                        //Output to ask for user input
                        Console.WriteLine(" Enter a '0' if you wish to open a file.\n Enter '1' if you wish to enter a text string.");
                        line = Console.ReadLine();

                        //Takes user input and determines if it is valid or not
                        while (!Int32.TryParse(line, out textChoice) || Int32.Parse(line) < 0 || Int32.Parse(line) > 1)
                        {
                            Console.WriteLine("You did not enter a '0' or '1'. Try Again.");
                            line = Console.ReadLine();
                        }//End While

                        //Decision statement to ask for a string input or to open a file
                        if (textChoice == 0)
                        {
                            textData = new Text();

                        }
                        else
                        {
                            Console.WriteLine("Please enter the string you wish to evaluate below.");
                            inputText = Console.ReadLine();
                            textData = new Text(inputText, 1);
                        }//End if

                        Utility.Skip(2);

                        //Creates the paragraph object passing in the text object
                        ParagraphList paragraph = new ParagraphList(textData);

                        //Outputs the paragraph and the paragraph stats
                        Console.WriteLine(paragraph.Display());

                        Console.ReadKey();
                        break;
                }  // end of switch

                choice = (Choices)menu.GetChoice();
            }  // end of while

            try
            {
                Console.WriteLine(person.ToString());
            }
            catch(NullReferenceException e) //Catches if the user did not try to re-enter their incorrect User Data
            {
                Console.WriteLine("You did not enter appropriate user data at the start of the program when prompted to try again.");
            }
            Utility.GoodbyeMessage();
            Console.ReadKey();
        }
    }
}

