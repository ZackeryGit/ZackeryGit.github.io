using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BiomeListSO", menuName = "Scriptable Objects/BiomeListSO")]
public class BiomeListSO : ScriptableObject
{
    public List<BiomeSO> biomes;
}
