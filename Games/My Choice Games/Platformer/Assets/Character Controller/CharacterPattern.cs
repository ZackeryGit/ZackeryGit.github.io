using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class CharacterPattern : ScriptableObject
{
    [HideInInspector] public Vector3 inputs;
    protected Vector3 positionDirection;
    public string hAxis = "Horizontal", vAxis = "Vertical";
    public float defaultspeed = 10f, speed = 10f, gravity = 3f, jumpForce = 30f, coyoteTimer, coyoteTime = .2f;
    public int jumpCount = 0, jumpCountMax = 2;

    public float JumpCount
    {
        get => jumpCount;
        set => jumpCount =  Convert.ToInt32(value);
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public void SpeedReset(){
        speed = defaultspeed;
    }

    public abstract void Move(CharacterController controller);
}