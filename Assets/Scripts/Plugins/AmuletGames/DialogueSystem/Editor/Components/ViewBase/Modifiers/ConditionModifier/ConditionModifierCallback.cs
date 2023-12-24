using UnityEngine;

namespace AG.DS
{
    public class ConditionModifierCallback
    {
        /// <summary>
        /// The callback to invoke when the modifier is created on the graph by the system or user.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="byUser">Is the modifier created by the user.</param>
        public void OnCreate
        (
            ConditionModifierView view,
            bool byUser
        )
        {
            if (byUser)
            {
                FolderCallback.OnCreateByUser(view.Folder);

                ReflectableObjectFieldCallback<Object>.OnCreateByUser(view.SecondReflectableObjectFieldView);
                BindingFlagsCallback.OnCreateByUser(view.SecondBindingFlags);

                OnCreateByUser(view);
            }
        }


        /// <summary>
        /// The callback to invoke when the modifier is created on the graph by the user.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        static void OnCreateByUser(ConditionModifierView view)
        {
            view.OperationType = ConditionModifierOperationType.String;
        }
    }
}