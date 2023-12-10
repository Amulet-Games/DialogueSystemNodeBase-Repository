using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class VariableFrameBase<T> : ScriptableObject
    {
        /// <summary>
        /// The serializable value of the variable scriptable object.
        /// </summary>
        [SerializeField] public T Value;


        /// <summary>
        /// Returns true if the variable's value is equal to the comparing value.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to the given value.</returns>
        public virtual bool Equal(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is equal to or bigger than the comparing value.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to or bigger than the given value.</returns>
        public virtual bool EqualOrBigger(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is equal to or smaller than the comparing value.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to or smaller than the given value.</returns>
        public virtual bool EqualOrSmaller(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is bigger than the comparing value.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is bigger than the given value.</returns>
        public virtual bool Bigger(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is smaller than the comparing value.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is smaller than the given value.</returns>
        public virtual bool Smaller(T value) => false;
    }
}