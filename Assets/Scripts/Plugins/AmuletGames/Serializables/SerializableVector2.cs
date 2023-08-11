using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public struct SerializableVector2
    {
        /// <summary>
        /// The x axis value of the vector2.
        /// </summary>
        public float x;


        /// <summary>
        /// The y axis value of the vector2.
        /// </summary>
        public float y;


        /// <summary>
        /// Constructor of the serializable vector2 struct.
        /// </summary>
        public SerializableVector2
        (
            float x,
            float y
        )
        {
            this.x = x;
            this.y = y;
        }


        // ----------------------------- Operators -----------------------------
        /// <summary>
        /// Allows explicit conversion from variable type serializable vector2 value to vector2.
        /// </summary>
        /// <param name="v">The serializable vector2 variable to convert from.</param>
        public static explicit operator Vector2(SerializableVector2 v)
        {
            return new Vector2(v.x, v.y);
        }


        /// <summary>
        /// Allows explicit conversion from variable type vector2 to serializable vector2.
        /// </summary>
        /// <param name="v">The vector2 variable to convert from.</param>
        public static explicit operator SerializableVector2(Vector2 v)
        {
            return new SerializableVector2(v.x, v.y);
        }


        /// <summary>
        /// Serializable vector2 struct's == operator.
        /// </summary>
        /// <param name="a">The serializable vector2 variable to compare from.</param>
        /// <param name="b">The serializable vector2 variable to compare to.</param>
        /// <returns>Returns true if the two variables' value are equal.</returns>
        public static bool operator ==(SerializableVector2 a, SerializableVector2 b)
        {
            return a.x == b.x
                && a.y == b.y;
        }


        /// <summary>
        /// Serializable vector2 struct's != operator.
        /// </summary>
        /// <param name="a">The serializable vector2 variable to compare from.</param>
        /// <param name="b">The serializable vector2 variable to compare to.</param>
        /// <returns>Returns true if the two variables' value are not equal.</returns>
        public static bool operator !=(SerializableVector2 a, SerializableVector2 b)
        {
            return a.x != b.x
                || a.y != b.y;
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Serializable vector2 struct's Equals method.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>Return true if the value of the comparing object this variable is equal.</returns>
        public override bool Equals(object obj)
        {
            // return true if the given object isn't null
            return obj != null

                // and the given object is a serializable vector2 variable 
                && obj is SerializableVector2 serializableVector2

                // and its value equals to this variable's value.
                && serializableVector2 == this;
        }


        /// <summary>
        /// Serializable vector2 struct's GetHashCode method.
        /// </summary>
        /// <returns>Returns the hash code of the serializable vector2 variable.</returns>
        public override int GetHashCode()
        {
            return x.GetHashCode() * 1610612741
                 ^ y.GetHashCode();
        }
    }
}
