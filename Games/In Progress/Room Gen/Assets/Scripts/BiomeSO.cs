using UnityEngine;

[CreateAssetMenu(fileName = "BiomeSO", menuName = "Scriptable Objects/BiomeSO")]
public class BiomeSO : ScriptableObject
{
    public string biomeName;
    public ObjectListSO roomSet;
    public int minRooms = 15;
    public int maxRooms = 25;
    
    public BiomeListSO possibleNextBiomes;
}
