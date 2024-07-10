using UnityEngine;

namespace AG.DS
{
    public class LanguageObjectFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the language object field view is created on the graph by the user.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The language field view to set for.</param>
        public static void OnCreateByUser<TObject>(LanguageObjectFieldView<TObject> view)
            where TObject : Object
        {
            view.CurrentLanguageValue = null;
        }
    }
}