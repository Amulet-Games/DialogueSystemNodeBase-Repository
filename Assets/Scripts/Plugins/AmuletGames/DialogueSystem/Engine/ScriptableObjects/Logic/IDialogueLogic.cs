namespace AG.DS
{
    public interface IDialogueLogic
    {
        /// <summary>
        /// Proceed to the next dialogue system graph's node when the method returns true.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        bool CheckDialogueLogic();
    }
}