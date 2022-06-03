using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mCharacterController : MonoBehaviour
{
    //[SerializeField] private ScreenTouchController input;
    [SerializeField] private Rigidbody mRb;
    [Range(200,1500)][SerializeField] private float moveSpeed;

    protected void Move(Vector3 direction){

        mRb.velocity = direction * moveSpeed * Time.fixedDeltaTime;
    }
}
