using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class VariableFrameBase<T> : ScriptableObject
    {
        /// <summary>
        /// Value of the variable object.
        /// </summary>
        [SerializeField] public T VariableValue;


        // ----------------------------- Comparison Methods -----------------------------
        /// <summary>
        /// Returns true if the variable's value is equal to the comparing variable.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to the given value.</returns>
        public virtual bool Equal(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is equal to or bigger than the comparing variable.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to or bigger than the given value.</returns>
        public virtual bool EqualOrBigger(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is equal to or smaller than the comparing variable.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is equal to or smaller than the given value.</returns>
        public virtual bool EqualOrSmaller(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is bigger than the comparing variable.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is bigger than the given value.</returns>
        public virtual bool Bigger(T value) => false;


        /// <summary>
        /// Returns true if the variable's value is smaller than the comparing variable.
        /// </summary>
        /// <param name="value">The given value to compare to.</param>
        /// <returns>True if the value from this variable is smaller than the given value.</returns>
        public virtual bool Smaller(T value) => false;


        /// <summary>
        /// Returns true if the variable's boolean value's status is true.
        /// </summary>
        /// <returns>For Boolean variable, returns true if its value is in true status. For others this simply returns false.</returns>
        public virtual bool True() => false;


        /// <summary>
        /// Returns true if the variable's boolean value's status is false.
        /// </summary>
        /// <returns>For Boolean variable, returns true if its value is in false status. For others this simply returns false.</returns>
        public virtual bool False() => false;
    }
}