using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DeathBehavior : MonoBehaviour
{

    public UnityEvent onDeathEvent, delayedDeathEvent;
    private WaitForSeconds wfsObj;

    private void Awake(){
        wfsObj = new WaitForSeconds(3);
    }
    private IEnumerator OnTriggerEnter(Collider other){
        if (other.tag == "Death"){
            Debug.Log("Deaded");
            onDeathEvent.Invoke();
            yield return wfsObj;
            delayedDeathEvent.Invoke();
        }
    }
}
