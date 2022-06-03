using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPlayer : mCharacterController
{
    [SerializeField] private ScreenTouchController input;
    private void FixedUpdate() {
        
        var directionP = new Vector3(input.direction.x,0,input.direction.y);
        Move(directionP);
    } 
}



