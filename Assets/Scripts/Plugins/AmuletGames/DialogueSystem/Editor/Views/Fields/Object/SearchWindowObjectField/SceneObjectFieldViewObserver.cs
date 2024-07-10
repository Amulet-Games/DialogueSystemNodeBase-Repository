using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class SceneObjectFieldObserver
    {
        /// <summary>
        /// The targeting scene object field view;
        /// </summary>
        SceneObjectFieldView view;


        /// <summary>
        /// The event to invoke when the scene object field's serializable value has changed.
        /// </summary>
        Action valueChangedEvent;


        /// <summary>
        /// Constructor of the scene object field observer class.
        /// </summary>
        /// <param name="view">The scene object field view to set for.</param>
        /// <param name="valueChangedEvent">The ValueChangedEvent to set for.</param>
        public SceneObjectFieldObserver
        (
            SceneObjectFieldView view,
            Action valueChangedEvent
        )
        {
            this.view = view;
            this.valueChangedEvent = valueChangedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the scene object field view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterMouseDownEvent();

            RegisterValueChangedEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => view.Field.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register MouseDownEvent to the field.
        /// </summary>
        void RegisterMouseDownEvent() => view.Field.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        /// <summary>
        /// Register ValueChangedEvent to the view.
        /// </summary>
        void RegisterValueChangedEvent() => view.ValueChangedEvent += valueChangedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<Object> evt)
        {
            var field = view.Field;

            // Unbind the previous value.
            field.Unbind();

            // Check if the new value is from the current active scene.
            //var newValue = (DialogueObject)evt.newValue;
            //if (newValue.scene.name != "")
            //{
            //    //if (SceneManager.GetActiveScene().name != "" && newValue.scene.name.Equals(SceneManager.GetActiveScene().name)) { }
            //    view.Value = newValue;
            //}
            //else
            //{
            //    view.Value = null;
            //    Debug.LogError("Attempted to assign a gameObject value that isn't from the current active scene.");
            //}

            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(
            //    reversible: objectContainer,
            //    dataReversedAction: containerValueChangedAction
            //);

            WindowChangedEvent.Invoke();
        }


        /// <summary>
        /// The event to invoke when the mouse button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}