using UnityEngine;

namespace CustomHitSound;

public static class Extensions
{
    public static Transform GetChild(this Transform transform, params int[] indexes)
        => indexes.Aggregate(transform, (current, index) => current.GetChild(index));
}