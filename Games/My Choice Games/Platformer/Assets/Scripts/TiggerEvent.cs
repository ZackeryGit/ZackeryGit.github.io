using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TiggerEvent : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerDelayedEvent;
    public int delayedSeconds = 5;
    private WaitForSeconds waitForSeconds;

    private void Awake(){
        waitForSeconds = new WaitForSeconds(delayedSeconds);
    }
    
    private IEnumerator OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
        yield return waitForSeconds;
        triggerDelayedEvent.Invoke();
    }
}
