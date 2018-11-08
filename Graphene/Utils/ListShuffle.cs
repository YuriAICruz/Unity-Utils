using System.Collections.Generic;
using UnityEngine;

namespace Graphene.Utils
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = Random.Range(0, n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }

            return list;
        }
    }

    public static class Vector3Extensions
    {
        public static bool Intersection(this Vector3 linePoint1, Vector3 a, Vector3 linePoint2, Vector3 b, out Vector3 intersection)
        {
            var c = linePoint2 - linePoint1;
            var crossVec1and2 = Vector3.Cross(a, b);
            var crossVec3and2 = Vector3.Cross(c, b);
 
            var planarFactor = Vector3.Dot(c, crossVec1and2);
            
            //is coplanar, and not parrallel
            if (Mathf.Abs(planarFactor) > 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
            {
                float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
                intersection = linePoint1 + (a * s);
                return true;
            }
            else
            {
                intersection = Vector3.zero;
                return false;
            }
        } 
    }
}