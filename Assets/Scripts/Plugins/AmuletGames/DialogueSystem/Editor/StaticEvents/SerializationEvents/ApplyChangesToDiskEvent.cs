using System;
using UnityEditor;

namespace AG.DS
{
    public class ApplyChangesToDiskEvent
    {
        /// <summary>
        /// ApplyChangesToDiskEvent, which'll be invoked immediately after saved Data or load data
        /// <br>event has finished, also it'll be invoked if the graph's title has changed to a new one.</br>
        /// </summary>
        static event Action mEvent;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void Clear()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register the given action to the event.
        /// </summary>
        /// <param name="action">The action to register with.</param>
        public static void Register(Action action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}