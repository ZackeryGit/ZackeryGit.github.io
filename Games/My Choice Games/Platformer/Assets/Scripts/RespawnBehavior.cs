using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RespawnBehavior : MonoBehaviour
{

    public GameObject respawnPointObj;
    public UnityEvent respawnEvent, delayedRespawnEvent;
    private WaitForSeconds wfsObj;

    private void Awake(){
        wfsObj = new WaitForSeconds(3);
    }

    public void StartRespawn(){
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn(){
        
        transform.position = respawnPointObj.transform.position;
        respawnEvent.Invoke();
        yield return wfsObj;
        delayedRespawnEvent.Invoke();
        
    }
}
