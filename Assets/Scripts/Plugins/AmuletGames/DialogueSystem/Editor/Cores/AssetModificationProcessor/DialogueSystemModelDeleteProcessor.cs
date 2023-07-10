using System.IO;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueSystemModelDeleteProcessor : AssetModificationProcessor
    {
        /// <summary>
        /// Unity calls this method when it is about to delete an asset from disk.
        /// <br>Remember to not call any Unity AssetDatabase api from within this callback, preferably keep to file operations or VCS apis.</br>
        /// <para></para>
        /// <br>This method will be called for any file deletion in the Project window.</br>
        /// <br>You'll have to use some string methods to check which asset is being delete.</br>
        /// <para></para>
        /// <br>Read More: https://docs.unity3d.com/ScriptReference/AssetModificationProcessor.OnWillDeleteAsset.html</br>
        /// </summary>
        /// 
        /// <param name="assetPath">
        /// The directory path of the deleting asset to set for.
        /// </param>
        /// 
        /// <param name="options">
        /// The options for removing assets to set for.
        /// </param>
        /// 
        /// <returns>Result of asset move. You can learn more by peek definition on the method.</returns>
        static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            //Returning different AssetDeleteResult will invoke different actions.
            //*  DidDelete:
            //*      - Tells Unity that the asset was deleted by the callback.
            //*        Unity will not try to delete the asset, but will delete the cached version and preview file.
            //*        
            //*  DidNotDelete:
            //*      - Tells the internal implementation that the callback did not delete the asset.
            //*        The asset will be delete by the internal implementation.
            //*        
            //*  FailedDelete:
            //*      - Tells Unity that the file cannot be deleted and Unity should leave it alone.

            // ---------------------------------------------------------------

            // We only want to interrupt the delete operation when...
            //  - File is a dialogue system model asset.

            var assetDirectoryPath = Path.GetDirectoryName(assetPath);
            if (assetDirectoryPath == DialogueSystemModel.ASSET_DIRECTORY_PATH)
            {
                // The asset is inside the dialogue system model directory.
                var dsModel = AssetDatabase.LoadAssetAtPath<DialogueSystemModel>(assetPath);
                if (dsModel != null)
                {
                    // Confirmed it's a dialogue system model.
                    dsModel.DeleteOpenConfirmKey();
                }
            }

            // Let unity handle the deletion.
            return AssetDeleteResult.DidNotDelete;
        }
    }
}