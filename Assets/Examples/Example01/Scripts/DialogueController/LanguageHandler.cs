using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    using DS;

    public class LanguageHandler : MonoBehaviour
    {
        [Header("Config")]
        public G_LanguageType languageType;

        [Header("Static")]
        public static LanguageHandler singleton;

        #region Callbacks.
        private void Awake()
        {
            if (singleton != null)
            {
                Destroy(gameObject);
            }
            else
            {
                singleton = this;
            }
        }
        #endregion
    }
}