using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AG.DS
{
    public class GameObjectUtility
    {
        /// <summary>
        /// Retrieve all the game objects from the active scene.
        /// </summary>
        /// <returns>An array of game objects from the active scene.</returns>
        public static GameObject[] GetActiveSceneGameObjects() => SceneManager.GetActiveScene().GetRootGameObjects();


        /// <summary>
        /// Retrieve all the game objects from the loaded scene.
        /// </summary>
        /// <param name="sceneIndex">The loaded scene's index to set for.</param>
        /// <returns>An array of game objects from the loaded scene.</returns>
        public static GameObject[] GetGameObjectsFromScene(int sceneIndex) => SceneManager.GetSceneAt(sceneIndex).GetRootGameObjects();


        /// <summary>
        /// Retrieve all the game objects from every loaded scene.
        /// </summary>
        /// <returns>An array of game objects from every loaded scene.</returns>
        public static IEnumerable<GameObject> GetAllSceneGameObjects()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                GameObject[] rootObjs = SceneManager.GetSceneAt(i).GetRootGameObjects();
                foreach (GameObject obj in rootObjs)
                {
                    yield return obj;
                }
            }
        }
    }
}