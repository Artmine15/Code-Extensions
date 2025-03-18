using UnityEngine;

namespace Artmine15.Toolkit
{
    public static class RandomExtensions
    {
        public static bool ChanceOf(float percent, float maxChance = 100)
        {
            float num = Random.Range(0, maxChance);
            if (num <= percent)
                return true;
            else
                return false;
        }
    }
}
