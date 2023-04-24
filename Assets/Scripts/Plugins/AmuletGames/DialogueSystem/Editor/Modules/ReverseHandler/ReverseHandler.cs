using System.Collections.Generic;
using System;

namespace AG.DS
{
    public class UndoRedoHandler
    {
        /// <summary>
        /// Reference of the undo finite stack.
        /// </summary>
        FiniteStack<ReversibleData> undoStack;


        /// <summary>
        /// Reference of the redo finite stack.
        /// </summary>
        FiniteStack<ReversibleData> redoStack;


        /// <summary>
        /// Reference of the reversible data pool.
        /// </summary>
        Queue<ReversibleData> reversibleDataPool;


        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static UndoRedoHandler Instance;


        // ----------------------------- Undo / Redo -----------------------------
        /// <summary>
        /// Reverse the last edited reversible object's data to its before state.
        /// </summary>
        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                ReversibleData undoData = undoStack.Pop();

                redoStack.Push(SaveReversibleData(undoData));

                undoData.Reverse();

                reversibleDataPool.Enqueue(undoData);
            }
        }


        /// <summary>
        /// Reverse the last edited reversible object's data to its after state.
        /// </summary>
        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                ReversibleData redoData = redoStack.Pop();

                undoStack.Push(SaveReversibleData(redoData));

                redoData.Reverse();

                reversibleDataPool.Enqueue(redoData);
            }
        }


        // ----------------------------- Push Undo Stack -----------------------------
        /// <summary>
        /// Generate a new reversible data and apply the given reversible object's data to it.
        /// <br>Then push it to the undo / redo stack.</br>
        /// </summary>
        /// <param name="reversible">The reversible object to apply from.</param>
        /// <param name="dataReversedAction">The dataReversedAction to apply with.</param>
        public void PushUndo
        (
            IReversible reversible,
            Action dataReversedAction = null
        )
        {
            ReversibleData reversibleData = reversibleDataPool.Count > 0

                // Get data from pool.
                ? reversibleDataPool.Dequeue()

                // Create new data.
                : new();

            // Apply source.
            reversibleData.ApplyData(reversible, dataReversedAction);

            // Push to undo stack.
            undoStack.Push(SaveReversibleData(reversibleData));
        }


        // ----------------------------- Enqueue Reversible Data -----------------------------
        /// <summary>
        /// Enqueue the given reversible data to the inernal queue so that it can be reused later.
        /// </summary>
        /// <param name="target">The reversible data to enqueue for.</param>
        public void EnqueueReversibleData(ReversibleData target) =>
            reversibleDataPool.Enqueue(target);


        // ----------------------------- Create Reversible Data -----------------------------
        /// <summary>
        /// Generate a new reversible data and apply the given reversible data to it.
        /// </summary>
        /// <param name="source">The reversible data to apply from.</param>
        /// <returns>A new generated reversible data that contains the same data as the given ones.</returns>
        ReversibleData SaveReversibleData(ReversibleData source)
        {
            ReversibleData reversibleData = reversibleDataPool.Count > 0

                // Get data from pool.
                ? reversibleDataPool.Dequeue()

                // Create new data.
                : new();

            // Apply source.
            reversibleData.ApplyData(source);

            // Return it.
            return reversibleData;
        }
    }
}