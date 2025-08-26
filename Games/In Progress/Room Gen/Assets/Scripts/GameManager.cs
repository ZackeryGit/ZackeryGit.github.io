using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onRoundStart, onRoundEnd;

    public RoomManager roomManager;
    public BiomeManager biomeManager;

    public void StartRound()
    {
        onRoundStart.Invoke();
    }

    public void EndRound()
    {
        onRoundEnd.Invoke();
    }

    public void OnRoomSpawned()
    {
        biomeManager.OnRoomSpawned();
        // Add other logic if needed
    }
}
