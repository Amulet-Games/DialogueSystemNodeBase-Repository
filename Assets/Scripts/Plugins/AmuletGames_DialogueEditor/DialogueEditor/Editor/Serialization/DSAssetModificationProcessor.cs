using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AG
{
    public class DSAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        public static DSHeadBar headBar;

        #region OnWillMoveAsset Fields.
        private static string renamedSOPath;

        private static int renamedSOParentPathCharCount;
        private static int dotAssetSuffixCharCount = 6;             /// Char of ".asset"
        #endregion

        #region Callbacks.
        /// Unity calls this method when it is about to move an Asset on disk.
        /// Noted that this gets called for any file move operation in the Project window. 
        /// You'll have to use some string methods to check the asset being moved.
        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            /* Returning the AssetMoveResult in different result will perform different actions.
             *  DidMove:
             *      - User have total controls of what they want to do when file is moved,
             *        file won't move to other directory or location in this case unless user suggests it to.
             *        
             *  DidNotMove:
             *      - Files will be moved to other locations just as usual. User don't control the result whatsoever.
             *  
             */

            /*< --------------------------------------------------------------------------------------------------------- >*/

            // We only want to interupt the moving operation when...
            //  - Editor graph is currently showing to the user.
            //  - File is a Dialogue Container SO.
            //  - File is in the same parent folder / directory after it's moved, meaning it get renamed.
            //  - User renamed the Container SO from "Asset Folder" NOT from the "TextField".

            if (EditorWindow.HasOpenInstances<DialogueEditorWindow>())
            {
                if (!DialogueEditorWindow.isRenameChangesApplied)
                {
                    if (sourcePath == AssetDatabase.GetAssetPath(DialogueEditorWindow.ContainerID))
                    {
                        if (Directory.GetParent(sourcePath).FullName == Directory.GetParent(destinationPath).FullName)
                        {
                            renamedSOPath = destinationPath;

                            // +1 because of '/' at the end of parent path.
                            renamedSOParentPathCharCount = Directory.GetParent(destinationPath).ToString().Length + 1;

                            OnDidMove();

                            return AssetMoveResult.DidMove;
                        }
                    }
                }
            }

            return AssetMoveResult.DidNotMove;
        }

        private static void OnDidMove()
        {
            // GOAL: Perform some type of string operation to remove the parent path and .asset suffix.

            // StringBuilder.Remove()
            //  - Remove only work from lower char index to higher char index.
            //  - E.g. "ExampleContainerSO.asset"
            //  - Remove will start from '.'(outward) instead of 't'(inward).

            /*< --------------------------------------------------------------------------------------------------------- >*/
            string newContainerSOName;

            
            ExtractNewNameFromPath();

            SetNewContainerSOName();
            
            ApplyChanges();

            void ExtractNewNameFromPath()
            {
                // GOAL: Get the new containerSO name from new path

                StringBuilder strBuilder = DSStringBuilder.AppendNew(renamedSOPath);

                // Remove the parent path string.
                strBuilder.Remove(0, renamedSOParentPathCharCount);

                // Remove the .asset suffix string.
                strBuilder.Remove(strBuilder.Length - dotAssetSuffixCharCount, dotAssetSuffixCharCount);

                // String operations are finished, convert it to string.
                newContainerSOName = strBuilder.ToString();
            }

            void SetNewContainerSOName()
            {
                // Set containerSO's name to the new one.

                headBar.UpdateTitleTextField(newContainerSOName);
            }

            void ApplyChanges()
            {
                // GOAL: Save the changes

                DSTitleChangedEvent.Invoke(newContainerSOName);
            }
        }
        #endregion
    }
}