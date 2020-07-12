using UnityEngine;

namespace Assets.GMTKGameJam2020.Scripts.Helpers
{
    public static class Helpers
    {
        public static Vector3 GetRandomVelocity(Vector3 max, Vector3 min)
        {
            return new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
            );
        }
    }
}