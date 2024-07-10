using UnityEngine;

namespace AG.DS
{
    public class CommonObjectFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the common object field view is created on the graph by the user.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The object field view to set for.</param>
        public static void OnCreateByUser<TObject>(CommonObjectFieldView<TObject> view)
            where TObject : Object
        {
            view.Value = null;
        }
    }
}