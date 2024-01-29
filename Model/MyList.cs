using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfL_Walking_Distance_Version2.Model
{
    class MyList
    {
        protected MyNode head = null;
        protected int length = 0;

        public MyList()
        {
            head = null;
            length = 0;
        }

        public bool IsEmpty()
        {
            return (length == 0);
        }

        public int IsCount()
        {
            return (length);
        }

        public MyNode GetHead()
        {
            if (!IsEmpty())
            { 
                return head;
            }
            else
            {
                return null;
            }
        }

        public void InsertAtHead(Object item)
        {
            MyNode newItem = new MyNode(item, head);

            head = newItem;

            length++;
        }

        public MyNode FindItem(Object item)
        {
            if (!IsEmpty())
            {
                MyNode current = new MyNode();

                current = head;

                while ((current != null) && (!(item.Equals(current.getItem()))))
                {
                    Console.WriteLine("findItem: current.item = " + current.getItem().ToString());

                    current = current.getNext();
                }
                return current;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("findItem: afterNode = null");
                Console.WriteLine();

                return null;
            }
        }

        public bool InsertAfter(Object newItem, Object afterItem)
        {
            MyNode afterNode = FindItem(afterItem);

            if (afterNode != null)
            {
                MyNode newItemNode = new MyNode(newItem, afterNode.getNext());
                afterNode.setNext(newItemNode);
                length++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Object DeleteHead()
        {
            if (!IsEmpty())
            {
                Object headItem = head.getItem();

                head = head.getNext();

                length--;
                
                return head;
            }
            else
            {
                return null;
            }
        }

        public void InsertAtTail(Object item)
        {
            MyNode newTail = new MyNode(item);

            if (IsEmpty())
            {
                head = newTail;
                length++;
            }
            else
            {
                MyNode current = new MyNode();
                current = head;

                while (current.getNext() != null)
                {
                    current = current.getNext();
                }
                current.setNext(newTail);
                length++;
            }
        }

        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                MyNode current = new MyNode();

                current = head;

                Console.WriteLine("Items in the list are:");

                while (current != null)
                {
                    current.print();
                    current = current.getNext();
                }
            }
        }
    }
}
