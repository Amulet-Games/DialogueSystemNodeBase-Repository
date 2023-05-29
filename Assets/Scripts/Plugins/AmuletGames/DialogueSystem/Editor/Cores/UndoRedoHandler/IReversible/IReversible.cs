namespace AG.DS
{
    public interface IReversible
    {
        /// <summary>
        /// Serialize the desired undo / redo data by using binary formatter and store it as byte array. 
        /// </summary>
        /// <returns>The byte array of the serialized undo / redo data.</returns>
        byte[] StashData();


        /// <summary>
        /// Deserialize the byte array to convert it back to the desired undo / redo data, and reverse
        /// <br>the reversible object to its before / after state.</br>
        /// </summary>
        /// <param name="array">The byte array to deserialize with.</param>
        void ReverseTo(byte[] array);
    }
}