using UnityEngine;
using System;
namespace Myextensions
{
    public static class Extensions
    {

        public static int GetInverse()
        {
            return 0;
        }

        public static float RaisedtoZero(this float val)
        {
            if (val >= 0)
                return 1;
            else
                return -1;
        }
        
        //fuck this solution
        /// <summary>
        /// applies direction to a passed scalar value
        /// </summary>
        /// <param name="ScalarValue">scalar value that's going to be converted to vector</param>
        /// <param name="SourceDirection">vector direction</param>
        /// <returns></returns>
        public static float ScalarVectApply(this float ScalarValue, float SourceDirection)
        {
            if(ScalarValue >=0)
            {
                if(SourceDirection>=0)
                    return ScalarValue;
                else
                    return ScalarValue * -1;
            }
            else
            {
                if (SourceDirection >= 0)
                    return ScalarValue;
                else 
                    return ScalarValue*-1;
            }
        }
        public static bool isGrounded(this Rigidbody2D body, float Distance = 1)
        {
            RaycastHit2D hit = Physics2D.Raycast(body.transform.position, Vector2.down,1, 1);
            if (hit.collider != null)
            {
                    return true;
            }
            return false;
        }
        public static int UnicodetoInt(this int number)
        {
            return number - 48;
        }




    }
}