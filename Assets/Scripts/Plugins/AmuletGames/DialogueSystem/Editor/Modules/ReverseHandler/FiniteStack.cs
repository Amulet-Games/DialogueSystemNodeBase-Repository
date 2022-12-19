using System.Collections.Generic;
using System;

namespace AG.DS
{
    [Serializable]
    public class FiniteStack<T> : LinkedList<T>
    {
        /// <summary>
        /// Size of the finite stack.
        /// </summary>
        private const int stackSize = 10;


        /// <summary>
        /// Returns the typed object at the top of the stack without removing it.
        /// <para>The method is similar to the Pop method, but it does not modify the stack.</para>
        /// </summary>
        /// <returns>The typed object at the of the stack.</returns>
        public T Peek() => Last.Value;


        /// <summary>
        /// Removes and returns the typed object at the top of the stack.
        /// <para>This method is similar to the Peek method, but Peek does not modify the stack.</para>
        /// </summary>
        /// <returns>The typed object removed from the top of the stack.</returns>
        public T Pop()
        {
            // Cache the latest node's value from the stack.
            T lastValue = Last.Value;

            // Remove the latest node.
            RemoveLast();

            // Return the cached value.
            return lastValue;
        }


        /// <summary>
        /// Inserts an typed object at the top of the stack.
        /// </summary>
        /// <param name="value">The typed object to push onto the stack.</param>
        public void Push(T value)
        {
            // Create a new node for the typed object that is going to be inserted to the stack.
            AddLast(new LinkedListNode<T>(value));

            if (Count > stackSize)
            {
                // Cache the earliest node's value from the stack.
                T firstValue = First.Value;

                // Remove the earliest node.
                RemoveFirst();

                // Convert the value as reversible data and enqueue it to the pool.
                UndoRedoHandler.Instance.EnqueueReversibleData(firstValue as ReversibleData);
            }
        }
    }
}