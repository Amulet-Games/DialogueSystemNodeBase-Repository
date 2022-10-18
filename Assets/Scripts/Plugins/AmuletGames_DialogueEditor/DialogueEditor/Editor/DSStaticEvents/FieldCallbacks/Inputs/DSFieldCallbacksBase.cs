namespace AG
{
    public class DSFieldCallbacksBase
    {
        /// <summary>
        /// Invoke DSWindowChangedEvent. Learn more about the event in it's own class.
        /// </summary>
        protected static void InvokeDSWindowChangedEvent()
        {
            DSWindowChangedEvent.Invoke();
        }
    }
}