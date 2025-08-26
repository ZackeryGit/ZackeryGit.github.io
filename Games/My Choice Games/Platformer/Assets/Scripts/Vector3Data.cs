using UnityEngine;

[CreateAssetMenu(menuName = "Data/VectorData")]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void UpdateTransform(Transform location){
        value = location.position;
    }

    public void SetObjectToPosition(GameObject obj){
        obj.transform.position = value;
    }

}
