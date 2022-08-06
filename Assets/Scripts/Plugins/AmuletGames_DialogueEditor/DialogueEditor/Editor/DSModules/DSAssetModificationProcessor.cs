using System.Text;
using System.IO;
using UnityEditor;

namespace AG
{
    public class DSAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// Reference of the dialogue system's headBar module.
        /// </summary>
        public static DSHeadBar HeadBar;

        
        /// <summary>
        /// The directory path of the dialogueContainerSO asset.
        /// </summary>
        static string renamedSOPath;


        /// <summary>
        /// The char count of asset's parent directory path. 
        /// </summary>
        static int renamedSOParentPathCharCount;


        /// <summary>
        /// The char count of ".asset".
        /// </summary>
        static int dotAssetSuffixCharCount = 6;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Unity calls this method when it is about to move an Asset on disk.
        /// <para></para>
        /// <br>Note that this gets called for any file move operation in the Project window.</br>
        /// <br>You'll have to use some string methods to check if the asset is moved.</br>
        /// </summary>
        /// 
        /// <param name="sourcePath">
        /// The directory path of the dialogueContainerSO asset that we're about to save.
        /// </param>
        /// 
        /// <param name="destinationPath">
        /// The desination directory path of which the asset it's going to save to.
        /// <br>But as for renaming the asset, this should be the same as it's sourcePath.</br>
        /// </param>
        /// 
        /// <returns>Result of asset move. You can learn more by peek definition on the method.</returns>
        static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            /* Returning the AssetMoveResult in different result will perform different actions.
             *  DidMove:
             *      - User have total controls of what they want to do when file is moved,
             *        file won't move to other directory or location in this case unless user suggests it to.
             *        
             *  DidNotMove:
             *      - Files will be moved to other locations just as usual. User don't control the result whatsoever.
             */

            // ---------------------------------------------------------------

            // We only want to interupt the moving operation when...
            //  - Editor graph is currently showing to the user.
            //  - File is a Dialogue Container SO.
            //  - File is in the same parent folder / directory after it's moved, meaning it get renamed.
            //  - User renamed the Container SO from editor's "Project Window", NOT from the "Title TextField".

            if (EditorWindow.HasOpenInstances<DialogueEditorWindow>())
            {
                if (!DialogueEditorWindow.IsRenameChangesApplied)
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


        /// <summary>
        /// Perform some type of string operation to remove the parent's directory path and .asset suffix.
        /// </summary>
        static void OnDidMove()
        {
            // StringBuilder.Remove()
            //  - Remove only work from lower char index to higher char index.
            //  - E.g. "ExampleContainerSO.asset"
            //  - Remove will start from '.'(outward) instead of 't'(inward).
            
            string newContainerSOName;

            ExtractNewNameFromPath();

            SetNewContainerSOName();
            
            ApplyChanges();

            void ExtractNewNameFromPath()
            {
                // GOAL: Get the new containerSO name from new path

                StringBuilder strBuilder = DSStringUtility.New(renamedSOPath);

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
                HeadBar.UpdateGraphTitleAction(newContainerSOName);
            }

            void ApplyChanges()
            {
                // Save the changes.
                DSTitleChangedEvent.Invoke(newContainerSOName);
            }
        }
    }
}