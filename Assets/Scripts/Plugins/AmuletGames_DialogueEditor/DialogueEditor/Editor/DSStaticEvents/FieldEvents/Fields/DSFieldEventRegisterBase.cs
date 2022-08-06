using UnityEngine.UIElements;

namespace AG
{
    public class DSFieldEventRegisterBase
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