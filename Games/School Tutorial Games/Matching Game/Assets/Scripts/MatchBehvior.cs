using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehvior : MonoBehaviour
{

    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;

    private IEnumerator OnTriggerEnter(Collider other){

            // Get other object component, and check if it exists
            var tempObj = other.GetComponent<IDContainerBehavior>();
            if (tempObj == null) {yield break;}

            var otherID = tempObj.idObj;

            if (otherID == idObj) {
                matchEvent.Invoke();
                Debug.Log(name);
            } else {
                noMatchEvent.Invoke();
                yield return new WaitForSeconds(0.5f);
                noMatchDelayedEvent.Invoke();
            }
    }
}
