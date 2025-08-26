using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Character Patterns/Character Move"))]
public class CharacterMove2d : CharacterPattern
{

    public UnityEvent doubleJumpEvent, walkEvent, jumpEvent, landEvent, startRun, endRun, fallEvent, leftEvent, rightEvent;
    public bool onGround = false;
    public bool running = false;
    public string direction = "None";

    private float minfalltime = .05f; // This number makes sure the player is off the ground, and the controller isnt disconnecting from the ground for .001 second

    public override void Move( CharacterController controller)
    {
        positionDirection.x = Input.GetAxis("Horizontal")* speed;
        // Get player direction (left or right)
        if (Input.GetKeyDown(KeyCode.D) && direction != "Right"){
            rightEvent.Invoke();
            direction = "Right";
        } else if (Input.GetKeyDown(KeyCode.A) && direction != "Left"){
            leftEvent.Invoke();
            direction = "Left";
        }

        if (controller.isGrounded)
        {
            positionDirection.y = 0;
            jumpCount = 0;
            coyoteTimer = coyoteTime;

        } else {

            if (coyoteTimer > 0) {
                coyoteTimer -= Time.deltaTime;
            }

            if (jumpCount == 0 && coyoteTimer <= 0){
                jumpCount = 1;
            }

        }

        if (jumpCount < jumpCountMax && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            jumpEvent.Invoke();
            positionDirection.y = jumpForce;
            if (jumpCount != 0){
                doubleJumpEvent.Invoke();
            }
            jumpCount++;
            
        }
        
        // Detect Landing
        if (controller.isGrounded == true && onGround == false){
            Debug.Log("Land");
            landEvent.Invoke();
        } else if (controller.isGrounded == false && coyoteTimer <= coyoteTime - minfalltime && onGround == true){
            Debug.Log("Fall");
            fallEvent.Invoke();
        }

        if (coyoteTimer > coyoteTime - minfalltime){
            onGround = true;
        }else {
            onGround = false;
        }

        // Detect run stop/start
        if (running == false && positionDirection.x != 0) {
            Debug.Log("StartRun");
            startRun.Invoke();
        } else if (running == true && positionDirection.x == 0){
            Debug.Log("StopRun");
            endRun.Invoke();
        }

        if (positionDirection.x == 0){
            running = false;
        } else {
            running = true;
        }

        
        positionDirection.y -= gravity * Time.deltaTime;
        

        //if (!Input.anyKey)
        //{
        //    positionDirection.x = 0f;
        //}
  

        // ChatGPT Code NOT MINE
        // Apply movement
        controller.Move(positionDirection * Time.deltaTime);

        // Freeze Z position by resetting it to a fixed value, e.g., starting position's Z.
        Vector3 fixedPosition = controller.transform.position;
        fixedPosition.z = 0; // Set to the desired Z value, like starting Z
        controller.transform.position = fixedPosition;
        
    }
}