using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num = 1;
    public void CreateInstance() 
    {
        Instantiate(prefab);
    }

    public void CreateInstance(Vector3Data obj)
    {
        Instantiate(prefab, obj.value, Quaternion.identity);
    }

    public void CreateInstanceFromList(Vector3DataList list)
    {
        for (int i = 0; i < list.vector3DList.Count; i++)
        {
            Instantiate(prefab, list.vector3DList[i].value, Quaternion.identity);
        }
    }

    public void CreateInstanceFromListCounting (Vector3DataList list)
    {
        Instantiate(prefab, list.vector3DList[num - 1].value, Quaternion.identity);
        num++;
        if (num > list.vector3DList.Count) {
            num = 1;
        }
    }
    public void CreateInstanceFromListRandom (Vector3DataList list)
    {
        num = Random.Range(0, list.vector3DList.Count);
        Debug.Log(num);
        Instantiate(prefab, list.vector3DList[num].value, Quaternion.identity);
    }

}
