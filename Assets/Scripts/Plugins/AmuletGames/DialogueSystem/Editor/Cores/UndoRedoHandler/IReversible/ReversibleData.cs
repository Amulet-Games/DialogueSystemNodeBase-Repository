using System;

namespace AG.DS
{
    public class ReversibleData
    {
        /// <summary>
        /// The data to reverse back to.
        /// </summary>
        byte[] data;


        /// <summary>
        /// Reversible object.
        /// </summary>
        IReversible reversible;


        /// <summary>
        /// Action that invoked after the redo / undo process.
        /// </summary>
        public Action DataReversedAction;


        /// <summary>
        /// Apply the data from the given reversible object.
        /// </summary>
        /// <param name="reversible">The reversible object to apply from.</param>
        /// <param name="dataReversedAction">The dataReversedAction to apply with.</param>
        public void ApplyData
        (
            IReversible reversible,
            Action dataReversedAction = null
        )
        {
            this.reversible = reversible;
            data = reversible.StashData();
            DataReversedAction = dataReversedAction;
        }


        /// <summary>
        /// Apply the data from another reversible data.
        /// </summary>
        /// <param name="source">The reversible data to apply from.</param>
        public void ApplyData(ReversibleData source)
        {
            reversible = source.reversible;
            data = source.reversible.StashData();
            DataReversedAction = source.DataReversedAction;
        }


        /// <summary>
        /// Start the redo / undo process and invoke the cached dataReversedAction once it's done.
        /// </summary>
        public void Reverse()
        {
            reversible.ReverseTo(data);
            DataReversedAction?.Invoke();
        }
    }
}