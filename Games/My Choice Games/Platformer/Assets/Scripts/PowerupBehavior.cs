using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PowerupBehavior : MonoBehaviour
{

    public UnityEvent powerup, powerdown, powerRespawn;
    public float duration = 3;
    public float respawnTime = 5;
    private WaitForSeconds durationWait, respawnWait;

    private void Awake(){
        durationWait = new WaitForSeconds(duration);
        respawnWait = new WaitForSeconds(respawnTime);
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){

            StartCoroutine(pickUp(other));
            StartCoroutine(respawn(other));
            
        }
    }

    private IEnumerator pickUp(Collider other){

        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        Debug.Log("Power Up!");
        powerup.Invoke();
        yield return durationWait;

        powerdown.Invoke();
        Debug.Log("Power Down!");

    }

    private IEnumerator respawn(Collider other){

        
        Debug.Log("Start Respawn Timer");

        yield return respawnWait;

        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        powerdown.Invoke();
        Debug.Log("Respawn Power Up");

    }
}
