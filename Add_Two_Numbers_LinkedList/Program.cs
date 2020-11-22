using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Two_Numbers_LinkedList
{

        class Program
        {
            public class Node
            {
                public int val;
                public Node next;
                public Node(int data)
                {
                    val = data;
                    next = null;
                }
            }

            public class LinkedList
            {
                Node root;

                public LinkedList()
                {
                    root = null;
                }

                public void insertRoot(int data)
                {
                    Node newNode = new Node(data);
                    if (this.root != null)
                    {
                        newNode.next = root;
                    }
                    this.root = newNode;
                }

                public void showList()
                {
                    showList_func(root);
                }

                public void showList_func(Node root)
                {
                    Node temp = root;
                    while (temp != null)
                    {
                        Console.Write(temp.val + " ");
                        temp = temp.next;
                    }
                }
                
                public Node returnNode()
                {
                  return root;
                }
            //Revese Function
              public Node Reverse_func(Node root)
              {
                if (root ==null || root.next == null)
                    return root;
                
                    Node newNode = Reverse_func(root.next);
                    root.next.next = root;
                    root.next = null;

                    return newNode;
              }
            ///////////////////
            

            public Node AddTwoNumber(Node first, Node second)
            {
                if (first == null) { return second; }
                else if (second == null) { return first; }
                else
                {
                    Node final = null;
                    int carry = 0;
                    int sum = 0;
                    while (first != null || second != null)
                    {
                        if (first != null && second != null)
                        {
                            if (carry != 0)
                            {
                                sum = first.val + second.val + carry;
                                carry = 0;
                            }
                            else
                            { sum = first.val + second.val; }

                            first = first.next;
                            second = second.next;
                        }
                        else if (first == null && second != null)
                        {
                            if (carry != 0)
                            {
                                sum = second.val + carry;
                                carry = 0;
                            }
                            else
                            { 
                                sum = second.val; 
                            }
                            
                            second = second.next;
                        }
                        else if (first != null && second == null)
                        {
                            if (carry != 0)
                            {
                                sum = first.val + carry;
                                carry = 0;
                            }
                            else
                            {
                                sum = first.val;
                            }

                            first = first.next;
                        }
                        if (sum > 9)
                        {
                            sum = sum - 10;
                            carry = 1;
                        }

                        Node newNode = new Node(sum);
                        sum = 0;
                        if (final != null)
                        {
                            newNode.next = final;
                        }
                        final = newNode;
                    }

                   
                    if (carry > 0)
                    {
                        sum = sum + carry;
                         Node newNode = new Node(sum);
                         if (final != null)
                         {
                             newNode.next = final;
                          }
                          final = newNode;
                    }
                    return final;
                }

            }
        }
            static void Main(string[] args)
            {
                LinkedList ls = new LinkedList();
                ls.insertRoot(9);
                ls.insertRoot(9);
                ls.insertRoot(9);
                ls.insertRoot(9);
                ls.insertRoot(9);
                ls.insertRoot(9);
                ls.insertRoot(9);
            
                ls.showList();
                Node List1=ls.returnNode();
                List1 = ls.Reverse_func(List1);
               
                Console.WriteLine("");
                LinkedList ls1 = new LinkedList();
                ls1.insertRoot(9);
                ls1.insertRoot(9);
                ls1.insertRoot(9);
                ls1.insertRoot(9);

               ls1.showList();
                Console.WriteLine("");
                Node List2 = ls1.returnNode();
                List2 = ls.Reverse_func(List2);

                Node final=ls.AddTwoNumber(List1, List2);
                ls.showList_func(final);
                Console.ReadLine();

            }
        }
    }


