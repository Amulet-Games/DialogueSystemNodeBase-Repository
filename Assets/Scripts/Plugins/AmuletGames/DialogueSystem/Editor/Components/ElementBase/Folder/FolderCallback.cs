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
            folder.ExecuteOnceOnGeometryChanged(GeometryChangedEvent);

            void GeometryChangedEvent(GeometryChangedEvent evt) =>
                folder.StartEditingFolderTitle();
        }
    }
}