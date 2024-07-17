using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class BlackboardObserver
    {
        /// <summary>
        /// The targeting blackboard element.
        /// </summary>
        Blackboard blackboard;


        /// <summary>
        /// The targeting blackboard element.
        /// </summary>
        /// <param name="blackboard">The blackboard element to set for.</param>
        public BlackboardObserver(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }


        // ----------------------------- Register Events -----------------------------
        public void RegisterEvents()
        {
            RegisterAddItemRequestedEvent();
        }


        void RegisterAddItemRequestedEvent() => blackboard.addItemRequested = AddItemRequestedEvent;


        void RegisterGenericMenuStringItemSelectedEvent() =>
            blackboard.GenericMenuStringItemSelectedEvent = GenericMenuStringItemSelectedEvent;


        void RegisterGenericMenuFloatItemSelectedEvent() =>
            blackboard.GenericMenuFloatItemSelectedEvent = GenericMenuFloatItemSelectedEvent;


        void RegisterGenericMenuBooleanItemSelectedEvent() =>
            blackboard.GenericMenuBooleanItemSelectedEvent = GenericMenuBooleanItemSelectedEvent;


        // ----------------------------- Event -----------------------------
        void AddItemRequestedEvent(UnityEditor.Experimental.GraphView.Blackboard blackboard)
        {
            // Create a new generic menu, populate it and show it
            {
                var menu = new GenericMenu();

                menu.AddItem(new GUIContent(StringConfig.Blackboard.GenericMenu.StringLabelText), false, GenericMenuStringItemSelectedEvent);
                menu.AddItem(new GUIContent(StringConfig.Blackboard.GenericMenu.FloatLabelText), false, GenericMenuFloatItemSelectedEvent);
                menu.AddItem(new GUIContent(StringConfig.Blackboard.GenericMenu.BooleanLabelText), false, GenericMenuBooleanItemSelectedEvent);

                menu.ShowAsContext();
            }
        }


        void GenericMenuStringItemSelectedEvent()
        {

        }


        void GenericMenuFloatItemSelectedEvent()
        {

        }


        void GenericMenuBooleanItemSelectedEvent()
        {

        }


        void GenericMenuEventItemSelectedEvent()
        {

        }
    }
}