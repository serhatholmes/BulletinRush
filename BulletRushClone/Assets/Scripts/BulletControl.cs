using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 movement;
    public void Fire(Vector3 direction){
        movement = direction * speed * Time.deltaTime;
    }

    private void FixedUpdate() {
        
        transform.position += movement;

    }
}
