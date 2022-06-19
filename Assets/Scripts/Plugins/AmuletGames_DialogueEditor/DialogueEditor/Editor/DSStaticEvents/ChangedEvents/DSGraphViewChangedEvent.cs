using System;

namespace AG
{
    public class DSGraphViewChangedEvent
    {
        public static event Action mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        /// Invoke.
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}