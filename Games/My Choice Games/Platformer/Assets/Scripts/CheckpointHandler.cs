using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RespawnBehavior))]
public class CheckpointHandler : MonoBehaviour
{
    public RespawnBehavior respawnBehavior;
    public CheckpointID currentCheckpoint;
    public UnityEvent onCheckpointSuccess;

    private void Start(){
        respawnBehavior = GetComponent<RespawnBehavior>();
    }

    private void OnTriggerEnter(Collider other){
        var otherObj = other.gameObject;
        var tempObj = otherObj.GetComponent<CheckpointIDContainer>();

        // Return if other component doesnt exist
        if (tempObj == null) {
            return;
        }

        // Set checkpoint if checkpoint is the next checkpoint
        if (otherObj.tag == "Checkpoint" && tempObj.checkpointID.value == currentCheckpoint.value + 1){
            currentCheckpoint = tempObj.checkpointID;
            respawnBehavior.respawnPointObj = other.gameObject;
            onCheckpointSuccess.Invoke();
        }
    }    
}
