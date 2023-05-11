using UnityEngine;

namespace Environment.Games.Shooter
{
    public interface IShootable
    {

        public void GetShot(Vector3 origin, Vector3 direction, int damage);

    }
}
