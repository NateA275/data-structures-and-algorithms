﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Classes
{
    public class MyLinkedList
    {
        public Node Head { get; set; }
        public Node Current { get; set; }


        //Linked List constructor
        public MyLinkedList(Node node)
        {
            Head = node;
            Current = node;
        }

        /// <summary>
        /// Merge - Combines two linked lists in a zipper-like fashion
        /// </summary>
        /// <param name="list1"> MyLinkedList - First node in resultant list will be from this list</param>
        /// <param name="list2"> MyLinkedList - List to be merged with first list</param>
        /// <returns> Node - Head of resualtant MyLinkedList </returns>
        public Node Merge(MyLinkedList list1, MyLinkedList list2)
        {
            list1.Current = list1.Head;
            list2.Current = list2.Head;
            Node runner1 = list1.Head;
            Node runner2 = list2.Head;
            while (runner1.Next != null && runner2.Next != null)
            {
                runner1 = runner1.Next;
                runner2 = runner2.Next;
                list2.Current.Next = list1.Current.Next;
                list1.Current.Next = list2.Current;
                list1.Current = runner1;
                list2.Current = runner2;
            }
            if (list2.Current.Next == null)
                list2.Current.Next = list1.Current.Next;
            list1.Current.Next = list2.Current;
            return list1.Head;
        }


        /// <summary>
        /// KthElement - Select an element that is k elements from the end of the linked list
        /// </summary>
        /// <param name="k"> int - number from last element to be selected </param>
        /// <returns> Node - node that is k elements from the end </returns>
        public Node KthElement(int k)
        {
            Current = Head;
            Node runner = Head;
            int counter = 0;

            while (runner.Next != null)
            {
                counter++;
                runner = runner.Next;
                if (counter > k)
                    Current = Current.Next;
            }
            if (k > counter)
            {
                throw new NullReferenceException();
            }
            return Current;
        }


        /// <summary>
        /// Add - adds a node to the front of the linked list
        /// </summary>
        /// <param name="newNode"> Node - node to be added </param>
        public void Add(Node newNode)
        {
            Current = Head;
            newNode.Next = Head;
            Head = newNode;
            Current = newNode;
        }


        /// <summary>
        /// Find - Finds a specific value in the linked list
        /// </summary>
        /// <param name="value"> int - Value of desired node </param>
        /// <returns></returns>
        public Node Find(int value)
        {
            Current = Head;
            while (Current.Next != null)
            {
                if (Current.Value == value)
                {
                    return Current;
                }
                Current = Current.Next;
            }
            return (Current.Value == value) ? Current : null;
        }


        /// <summary>
        /// Print - Displays all of the values within the linked list
        /// </summary>
        public void Print()
        {
            Current = Head;
            while(Current.Next != null)
            {
                Console.Write($"{Current.Value} => ");
                Current = Current.Next;
            }
            Console.Write(Current.Value);
        }


        /// <summary>
        /// AddBefore - Adds a node before an existing node
        /// </summary>
        /// <param name="newNode"> Node - node to be added to linked list </param>
        /// <param name="existingNode"> Node - specified node to be found </param>
        public void AddBefore(Node newNode, Node existingNode)
        {
            Current = Head;
            if (Head.Value == existingNode.Value)
            {
                Add(newNode);
                return;
            }
            while (Current.Next != null)
            {
                if (Current.Next.Value == existingNode.Value)
                {
                    newNode.Next = Current.Next;
                    Current.Next = newNode;
                    return;
                }
                Current = Current.Next;
            }
        }


        /// <summary>
        /// AddAfter - Adds a node after a specified existing node
        /// </summary>
        /// <param name="newNode"> Node - node to be added after a specified node </param>
        /// <param name="existingNode"> Node - specified node to be found </param>
        public void AddAfter(Node newNode, Node existingNode)
        {
            Current = Head;
            while (Current.Next != null)
            {
                if (Current == existingNode)
                {
                    newNode.Next = Current.Next;
                    Current.Next = newNode;
                    return;
                }
                Current = Current.Next;
            }
            if (Current == existingNode)
            {
                Current.Next = newNode;
                return;
            }
        }


        /// <summary>
        /// AddLast - Adds a node to the end of a linked list
        /// </summary>
        /// <param name="node"> Node - node to be appended to the end of linked list </param>
        public void AddLast(Node node)
        {
            Current = Head;
            while (Current.Next != null)
                Current = Current.Next;

            Current.Next = node;
        }
    }
}
