using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    [SerializeField] private BulletControl bulletPrefab;

    public float Delay =>delay;
    [SerializeField] private float delay;

    public void Shoot(Vector3 direction,Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }
}
