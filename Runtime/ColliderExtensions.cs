
using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public static class ColliderExtensions
    {
        private static Collider[] _resultColliders = new Collider[4];

        public static Vector3 GetRandomPointInCollider(BoxCollider areaCollider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = areaCollider.bounds;
            Vector3 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return GetRandomPoint(areaCollider);
                case SpawnAccuracyLevel.MustBeInCollider:
                    do
                    {
                        randomPoint = GetRandomPoint(areaCollider);
                    } while (!IsPointInCollider(randomPoint, areaCollider));
                    return randomPoint;
            }
            return Vector3.zero;
        }

        private static Vector3 GetRandomPoint(BoxCollider boxCollider)
        {
            Bounds bounds = boxCollider.bounds;
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            return new Vector3(randomX, randomY, randomZ);
        }

        private static bool IsPointInCollider(Vector3 point, BoxCollider collider)
        {
            return collider.bounds.Contains(point);
        }

        public static bool IsObjectOverlap(Collider objectCollider)
        {
            if (Physics.OverlapSphereNonAlloc(objectCollider.transform.position, 3, _resultColliders) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
