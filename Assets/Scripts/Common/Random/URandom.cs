using UnityEngine;

namespace RaruLib
{
    public class URandom : IRandom
    {
        public int Range(int min, int max)
            => Random.Range(min, max);

        public float Value()
            => Random.value;
    }
}