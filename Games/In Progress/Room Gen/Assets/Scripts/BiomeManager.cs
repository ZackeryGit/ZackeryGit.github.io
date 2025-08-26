using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    public List<BiomeSO> biomes;
    public RoomManager roomManager;

    private BiomeSO currentBiome;
    private int roomsSpawnedInBiome;
    private int targetRoomsInBiome;

    private void Start()
    {
        
    }

    public void OnRoomSpawned()
    {
        
    }


}
