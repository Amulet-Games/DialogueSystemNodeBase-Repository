using System;

namespace AG
{
    [Serializable]
    public class LanguageGenerics<T>
    {
        public G_LanguageType languageType;
        public T genericsContent;
    }
}