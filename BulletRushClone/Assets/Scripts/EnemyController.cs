using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : mCharacterController
{
    [SerializeField] private ControlPlayer player;
    private void FixedUpdate() 
    {
        var delta =  player.transform.position - transform.position;
        delta.y = 0;
        var direction = delta.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag($"Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
