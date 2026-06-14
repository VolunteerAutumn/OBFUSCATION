using System;

namespace ConsoleApp1
{
    class Stack<T>
    {         
        private T[] items;
        private int top;
        public Stack(int capacity)
        {
            items = new T[capacity];
            top = -1;
        }
        public void Push(T item)
        {
            if (top == items.Length - 1)
            {
                throw new InvalidOperationException("Stack is full.");
            }
            items[++top] = item;
        }
        public T Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return items[top--];
        }
        public T Peek()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return items[top];
        }
        public int Count()
        {
            return top + 1;
        }
        public override string ToString()
        {
            if (top == -1)
            {
                return "Stack is empty.";
            }
            string result = "Stack contents: ";
            for (int i = top; i >= 0; i--)
            {
                result += items[i] + " ";
            }
            return result;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine($"The stack: {stack}");
            Console.WriteLine($"Top item: {stack.Peek()}");
            Console.WriteLine($"Popped item: {stack.Pop()}");
            Console.WriteLine($"The stack after popping: {stack}");
            Console.WriteLine($"Stack count: {stack.Count()}");

        }
    }
}
