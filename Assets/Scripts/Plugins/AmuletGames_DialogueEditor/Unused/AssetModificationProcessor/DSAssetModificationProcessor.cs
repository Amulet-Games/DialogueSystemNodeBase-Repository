using System.Text;
using System.IO;
using UnityEditor;

namespace AG
{
    //public class DSAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    //{
    //    /// <summary>
    //    /// Did the user rename the asset inside the custom graph editor?
    //    /// </summary>
    //    public static bool IsRenamedOnGraph;


    //    /// <summary>
    //    /// The char count of ".asset".
    //    /// </summary>
    //    static int dotAssetSuffixCharCount = 6;


    //    // ----------------------------- Callbacks -----------------------------
    //    /// <summary>
    //    /// Unity calls this method when it is about to move an Asset on disk.
    //    /// <para></para>
    //    /// <br>Note that this gets called for any file move operation in the Project window.</br>
    //    /// <br>You'll have to use some string methods to check which asset is being moved.</br>
    //    /// <para></para>
    //    /// <br>Read More: https://docs.unity3d.com/ScriptReference/AssetModificationProcessor.OnWillMoveAsset.html</br>
    //    /// </summary>
    //    /// 
    //    /// <param name="sourcePath">
    //    /// The original directory path of the asset that we're about to save.
    //    /// </param>
    //    /// 
    //    /// <param name="destinationPath">
    //    /// The new directory path to save the asset to.
    //    /// <br>As for renaming the asset, this should be the same as its source path.</br>
    //    /// </param>
    //    /// 
    //    /// <returns>Result of asset move. You can learn more by peek definition on the method.</returns>
    //    static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
    //    {
    //        /* Returning different AssetMoveResult will invoke different actions.
    //         *  DidMove:
    //         *      - User have total controls of what they want to do when file is moved,
    //         *        file won't move to other directory or location in this case unless user suggests it to.
    //         *        
    //         *  DidNotMove:
    //         *      - Files will be moved to other locations just as usual. User don't control the result whatsoever.
    //         */

    //        // ---------------------------------------------------------------

    //        // We only want to interupt the moving operation when...
    //        //  - Editor graph is currently showing to the user.
    //        //  - File is DS Container SO asset.
    //        //  - File is in the same parent folder / directory after it's moved, meaning it was simply renamed.
    //        //  - User renamed the asset from editor's project window, NOT from the DSHeadBar's GraphTitleField.

    //        if (EditorWindow.HasOpenInstances<DialogueEditorWindow>())
    //        {
    //            // If the asset isn't renamed on the graph.
    //            if (!IsRenamedOnGraph)
    //            {
    //                // If the asset is DSContainerSO.
    //                if (sourcePath == AssetDatabase.GetAssetPath(DialogueEditorWindow.DSContainerId))
    //                {
    //                    // If the new directory path is the same as the previous one.
    //                    if (Directory.GetParent(sourcePath).FullName == Directory.GetParent(destinationPath).FullName)
    //                    {
    //                        // Retrieve the new asset's name and save it.
    //                        OnDidMove(destinationPath);

    //                        return AssetMoveResult.DidMove;
    //                    }
    //                }
    //            }
    //        }

    //        return AssetMoveResult.DidNotMove;
    //    }


    //    /// <summary>
    //    /// Perform some type of string operation to remove the parent's directory path and .asset suffix.
    //    /// </summary>
    //    static void OnDidMove(string destinationPath)
    //    {
    //        // StringBuilder.Remove()
    //        //  - Remove only work from lower char index to higher char index.
    //        //  - E.g. "ExampleContainerSO.asset"
    //        //  - Remove will start from '.'(outward) instead of 't'(inward).
            
    //        string newContainerSOName;

    //        RetrieveNewNameFromPath();

    //        UpdateGraphTitleField();
            
    //        InvokeGraphTitleChangedEvent();

    //        void RetrieveNewNameFromPath()
    //        {
    //            // GOAL: Get the new containerSO name from new path

    //            StringBuilder strBuilder = DSStringUtility.New(destinationPath);

    //            // +1 because of '/' at the end of parent path.
    //            int renamedSOParentPathCharCount = Directory.GetParent(destinationPath).ToString().Length + 1;

    //            // Remove the parent path string.
    //            strBuilder.Remove(0, renamedSOParentPathCharCount);

    //            // Remove the .asset suffix string.
    //            strBuilder.Remove(strBuilder.Length - dotAssetSuffixCharCount, dotAssetSuffixCharCount);

    //            // String operations are finished, convert it to string.
    //            newContainerSOName = strBuilder.ToString();
    //        }

    //        void UpdateGraphTitleField()
    //        {
    //            // Update the headbar's graph title field.
    //            DSHeadBar.UpdateGraphTitleFieldNonAlert(newContainerSOName);
    //        }

    //        void InvokeGraphTitleChangedEvent()
    //        {
    //            // Save the changes.
    //            DSGraphTitleChangedEvent.Invoke(newContainerSOName);
    //        }
    //    }
    //}
}