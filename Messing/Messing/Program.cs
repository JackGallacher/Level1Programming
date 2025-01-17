﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messing
{
    class Animal
    {
        public virtual void Sound()//The method is virtual, meaning it can be overriden in the child classes to alter its implementation.
        {
            Console.WriteLine("This is the generic Animal sound.");
        }
    }
    class Lion : Animal
    {
        public override void Sound()//This overrides the virtual void in the Animal class.
        {
            Console.WriteLine("This is the Lions Sound");
        }
    }
   
    class Node
    {
        public int NodeData;
        public Node NodeNext;
    }
    class LinkedList
    {
        private Node Head = null;//The top of our linked list.

        public void Add(int Data)
        {
            Node newNode = new Node();//Creates a new node that we will add to thise list.
            newNode.NodeData = Data;//Sets the data of this new node.
            newNode.NodeNext = Head;//Sets the next node of this node to the head of the list "linking the list" newNode.NodeNext ---> OriginalHead.
            Head = newNode;//Sets this node to the head of the list. So when we add ANOTHER item, it would look like this. secondnewNode.NodeNext --->newNode.NodeNext ---> OriginalHead.
        }

        public void PrintNodes()
        {
            int NodeCount = 0;

            Node CurrentNode = Head;
            while(CurrentNode != null)
            {
                Console.WriteLine("Node Position {0}: " + CurrentNode.NodeData, NodeCount);
                CurrentNode = CurrentNode.NodeNext;
                NodeCount++;
            }
        }

        public void Delete(int NodePosition)//Deletes a node from out linked list.
        {
            Node CurrentNode = Head;
            int NodeCount = 0;

            while(CurrentNode != null)
            {
                NodeCount++;
                if(NodeCount == NodePosition)
                {
                    Console.WriteLine("Deleting the Node in position {0}", NodeCount);
                    CurrentNode.NodeNext = CurrentNode.NodeNext.NodeNext;//Takes the current node, and sets its NodeNext to the NodeNext of the Node we want to delete. e.g. CurrentNode = 1 CurrentNode.NodeNext = 2 CurrentNode.NodeNext.NodeNext = 3
                }
                CurrentNode = CurrentNode.NodeNext;
            }            
        }
    }

    public class Person
    {
        private string _firstname;
        private string _lastname;

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if(!string.IsNullOrEmpty(value))//Checks to see of the string is not null.
                {
                    _firstname = value.Substring(0, 1).ToUpper() + value.Substring(1);//this takes the private string and applies setter conditions to it formatting the data when it is assigned to the FirstName string.
                }
            }
        }
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (!string.IsNullOrEmpty(value))//Checks to see of the string is not null.
                {
                    _lastname = value.Substring(0, 1).ToUpper() + value.Substring(1);//this takes the private string and applies setter conditions to it formatting the data when it is assigned to the FirstName string.
                }
            }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        //public string FullName()
        //{
        //    return FirstName + " " + LastName;
        //}
    }
    public class Student : Person
    {
        private string _studentid;
        public string StudentID
        {
            get { return _studentid; }
            set { _studentid = value; }//"value" is just whatever is passed to this variable when it is assigned. Error handling for incorrect type could be put here.
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //Animal myAnimal = new Lion();
            //Animal myAnimal2 = new Animal();

            //myAnimal.Sound();
            //myAnimal2.Sound();

            //Program myProgram = new Program();
            //myProgram.ReverseString("Hello, my name is Jack!");

            //LinkedList myList = new LinkedList();

            //myList.Add(5);
            //myList.Add(4);
            //myList.Add(3);
            //myList.Add(2);
            //myList.Add(1);

            //myList.PrintNodes();
            //myList.Delete(2);
            //myList.PrintNodes();

            //int[] ArrayOne = new int[5] { 1, 2, 3, 4, 5 };
            //int[] ArrayTwo = new int[5] { 2, 7, 4, 1, 9 };
            //FindMatching(ArrayOne, ArrayTwo);

            Person MyPerson = new Person();
            MyPerson.FirstName = "jack";
            MyPerson.LastName = "gallacher";
            
            Console.WriteLine(MyPerson.FullName);
            //Console.WriteLine(MyPerson.FullName());

            Student MyStudent = new Student();
            MyStudent.FirstName = "anna";
            MyStudent.LastName = "tuffs";
            MyStudent.StudentID = "TUFFS12345";
            Console.WriteLine("\n" + MyStudent.FullName);
            Console.WriteLine(MyStudent.StudentID);


                                  
            Console.ReadLine();
        }

        void ReverseString(string myString)
        {
            string ReversedString = "";
            foreach(char myChar in myString)
            {
                ReversedString = myChar + ReversedString;
            }
            Console.WriteLine(ReversedString);
        }

        static void FindMatching(int[] ArrayOne, int[] ArrayTwo)
        {
            string MatchingNumbers = "";
            for(int i = 0; i < ArrayOne.Length; i++)
            {
                for(int j = 0; j < ArrayTwo.Length; j++)
                {
                    if(ArrayOne[i] == ArrayTwo[j])
                    {
                        MatchingNumbers = Convert.ToString(ArrayOne[i]) + " " + MatchingNumbers;
                    }
                }
            }
            Console.WriteLine("Matching numbers in the two arrays are:" + MatchingNumbers);
        }
    }
}
