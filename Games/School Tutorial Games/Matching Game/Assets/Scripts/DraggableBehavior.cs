using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehavior : MonoBehaviour
{
    public UnityEvent startDragEvent, endDragEvent;
    private Camera cameraObj;
    public bool draggable;
    public Vector3 position, offest;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = Camera.main;
    }

    public IEnumerator OnMouseDown()
    {
            offest = transform.position - cameraObj.ScreenToWorldPoint(Input.mousePosition);
            draggable = true;
            startDragEvent.Invoke();
            yield return new WaitForFixedUpdate();
            
            while (draggable)
            {
                yield return new WaitForFixedUpdate();
                position = cameraObj.ScreenToWorldPoint(Input.mousePosition) + offest;
                transform.position = position;
            }
    }

    private void OnMouseUp()
    {
        draggable = false;
        endDragEvent.Invoke();
    }
}
