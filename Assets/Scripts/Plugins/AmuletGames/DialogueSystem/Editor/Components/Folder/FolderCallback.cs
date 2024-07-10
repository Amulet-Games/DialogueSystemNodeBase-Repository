using UnityEngine.UIElements;

namespace AG.DS
{
    public static class FolderCallback
    {
        /// <summary>
        /// The callback to invoke when the folder is created on the graph by the user.
        /// </summary>
        /// <param name="folder">The folder element to set for.</param>
        public static void OnCreateByUser(Folder folder)
        {
            folder.Expanded = true;
            folder.ExecuteOnceOnGeometryChanged(_ExecuteOnceOnGeometryChangedEvent);

            FolderTitleTextFieldCallback.OnCreateByUser(folder.FolderTitleFieldView);
        }


        /// <summary>
        /// Register GeometryChangedEvent to the folder, and unregistered it once it's invoked.
        /// </summary>
        /// <param name="folder">The folder element to set for.</param>
        static void _ExecuteOnceOnGeometryChangedEvent(GeometryChangedEvent evt)
        {
            ((Folder)evt.target).StartEditingFolderTitle();
        }
    }
}