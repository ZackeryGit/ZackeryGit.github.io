using Cinemachine;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Vector2 minBounds, maxBounds; // X/Z movement limits
    public float moveSpeed = 0.1f; // Adjust the camera movement sensitivity
    
    public bool running;

    public bool Running
    {
        get { return running; }
        set { running = value; }
    }

    private Vector2 lastTouchPosition;
    private int activeFingerId = -1;
    private bool isDragging;

    void Update()
    {
        HandleSwipeInput();
    }

    void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            // Loop through all touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Start tracking when a touch begins
                if (touch.phase == TouchPhase.Began)
                {
                    activeFingerId = touch.fingerId;
                    lastTouchPosition = touch.position;
                    isDragging = true;
                }

                // If this is the finger we're tracking...
                if (touch.fingerId == activeFingerId)
                {
                    if (touch.phase == TouchPhase.Moved && isDragging && running)
                    {
                        Vector2 delta = touch.position - lastTouchPosition;
                        lastTouchPosition = touch.position;

                        float moveX = delta.x * moveSpeed * Camera.main.orthographicSize / Screen.height;
                        float moveZ = delta.y * moveSpeed * Camera.main.orthographicSize / Screen.height;

                        transform.position -= new Vector3(moveX, 0, moveZ);

                        // Clamp to bounds
                        transform.position = new Vector3(
                            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                            transform.position.y,
                            Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y)
                        );
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {
                        isDragging = false;
                        activeFingerId = -1;
                    }
                }
            }
        }
    }
    public void SetCameraPosition(Vector3 newPosition)
    {
        transform.position = new Vector3(
            Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x),
            transform.position.y, // Keep Y the same
            Mathf.Clamp(newPosition.z, minBounds.y, maxBounds.y)
        );
    }

    public void SetCameraZoom(float newSize)
    {
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }
}
