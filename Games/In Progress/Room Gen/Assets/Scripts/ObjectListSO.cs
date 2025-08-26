using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectList", menuName = "Scriptable Objects/Data/Lists/ObjectList")]
public class ObjectListSO : ScriptableObject
{
    public List<GameObject> objects;

    public int Count => objects != null ? objects.Count : 0;
    public GameObject this[int index] => objects[index];
}
