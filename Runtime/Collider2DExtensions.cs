using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public enum SpawnAccuracyLevel { None, MustBeInCollider }

    public class Collider2DExtensions
    {
        private static Collider2D[] _resultColliders = new Collider2D[1];

        private static Vector2 GetRandomPoint(Bounds bounds, BoxCollider2D collider)
        {
            //float randomX = Random.Range(bounds.min.x, bounds.min.x);
            //float randomY = Random.Range(bounds.min.y, bounds.min.y);
            //return new Vector2(randomX, randomY);

            float randomX = Random.Range(collider.transform.position.x - collider.size.x / 2, collider.transform.position.x + collider.size.x / 2);
            float randomY = Random.Range(collider.transform.position.y - collider.size.y / 2, collider.transform.position.y + collider.size.y / 2);
            return new Vector2(randomX, randomY);
        }

        public static Vector2 GetRandomPointInCollider(BoxCollider2D areaCollider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = areaCollider.bounds;
            Vector2 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return GetRandomPoint(bounds, areaCollider);
                case SpawnAccuracyLevel.MustBeInCollider:
                    do
                    {
                        randomPoint = GetRandomPoint(bounds, areaCollider);
                    } while (!IsPointInCollider(randomPoint, areaCollider));
                    return randomPoint;
            }
            return Vector2.zero;
        }

        private static bool IsPointInCollider(Vector2 point, BoxCollider2D collider)
        {
            return collider.OverlapPoint(point);
        }

        public static bool IsObjectOverlap(Collider2D objectCollider)
        {
            if (Physics2D.OverlapCircleNonAlloc(objectCollider.transform.position, 3, _resultColliders) >= 0)
            {
                //Debug.Log("True");
                return true;
            }
            else
            {
                //Debug.Log("False");
                return false;
            }

        }
    }
}
