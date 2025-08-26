using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameManager gameManager;
    private GameObject lastExit;
    public ObjectListSO roomSet;
    


    // Spawn a room from the current room set
    public void addRoom()
    {

        Vector3 spawnLocation = Vector3.zero;
        GameObject randomRoom = roomSet[Random.Range(0, roomSet.Count)];

        if (lastExit == true)
        {
            spawnLocation = lastExit.transform.position;
        }

        GameObject newRoom = Instantiate(randomRoom, spawnLocation, Quaternion.identity);

        RoomBehavior roomBehavior = newRoom.GetComponent<RoomBehavior>(); // Get Room Behavior Script Component

        if (roomBehavior != null && roomBehavior.exit)
        {
            lastExit = roomBehavior.exit;
        }
        else
        {
            Debug.LogWarning("Missing Exit Object");
        }

    }

    // Change the room set with a different one
    public void changeRoomSet(ObjectListSO newRoomSet)
    {
        roomSet = newRoomSet;
    }
    
}
