using UnityEngine;

namespace AG.DS
{
    public static class ReflectableObjectFieldCallback<TObject>
        where TObject : Object
    {
        /// <summary>
        /// The callback to invoke when the reflectable object field is created on the graph by the user.
        /// </summary>
        /// <param name="view">The reflectable object field view to set for.</param>
        public static void OnCreateByUser(ReflectableObjectFieldView<TObject> view)
        {
            view.Value = null;
        }
    }
}