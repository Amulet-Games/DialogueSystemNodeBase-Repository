using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    using DS;

    public class LanguageHandler : MonoBehaviour
    {
        [Header("Config")]
        public LanguageType languageType;

        [Header("Static")]
        public static LanguageHandler singleton;

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
    }
}