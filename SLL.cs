using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node Head { get; set; }
        [DataMember]
        private int _count = 0;

        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            int _count = 0;
            Node current = Head;
            while (current != null)
            {
                _count++;
                current = current.Next;
            }
        }

        public void Add(User value, int index)
        {

            if (index < 0 || (_count != 0 && index >= _count))
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }

            Node newNode = new Node(value);

            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                _count++;
                return;
            }

            Node current = Head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            _count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
            }
            
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            _count++;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }

            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            
            _count++;
        }

        public void Clear()
        {
            Head = null;
            _count = 0;
        }

        public bool Contains(User value)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Value != null && current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }

            return IndexOf(value) >= 0;
        }

        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }

            Node current = Head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }

            return current.Value;
        }

        public int IndexOf(User value)
        {
            Node current = Head;
            int index = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }

            return -1;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Indes out of Range");
            }

            if (index == 0)
            {
                RemoveFirst();
            }

            Node previous = null;
            Node current = Head;

            for (int i = 0; i < index && current != null; i++)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }

            previous.Next = current.Next;

            _count--;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new NotImplementedException("List is empty");
            }
            Head = Head.Next;
            _count--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new NotImplementedException();
            }
            if (_count == 1)
            {
                Head = null;
                _count--;
            }
            else
            {
                Node current = Head;
                Node previous = null; 


                while (current.Next != null)
                {
                    previous = current; 
                    current = current.Next;
                }

                previous.Next = null;
                _count--;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is negative or past the size of the list");
            }
            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }
        public void Join(SLL other)
        {
            if (other == null)
            {
                return;
            }
            if (Head == null)
            {
                Head = other.Head;
                return;
            }
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = other.Head;
            Node countCurrent = Head;
            _count = 0;
            while (countCurrent != null)
            {
                countCurrent = countCurrent.Next;
                _count++;
            }
        }
    }
}
