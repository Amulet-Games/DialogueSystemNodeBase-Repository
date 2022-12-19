namespace AG.DS
{
    public class FieldCallbacksBase
    {
        /// <summary>
        /// Invoke WindowChangedEvent. Learn more about the event in it's own class.
        /// </summary>
        protected static void InvokeWindowChangedEvent()
        {
            WindowChangedEvent.Invoke();
        }
    }
}