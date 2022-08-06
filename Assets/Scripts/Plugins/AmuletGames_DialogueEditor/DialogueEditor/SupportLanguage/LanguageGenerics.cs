using System;

namespace AG
{
    [Serializable]
    public class LanguageGenerics<T>
    {
        /// <summary>
        /// Language type of the generics object.
        /// </summary>
        public G_LanguageType LanguageType;


        /// <summary>
        /// Content of the generic object.
        /// <br>T value can be either struct or object type.</br>
        /// </summary>
        public T GenericsContent;
    }
}