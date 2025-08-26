using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorIDList : ScriptableObject
{

    public List<ColorID> colorIdList;

    public ColorID currentColor;
    private int num;

    public void SetCurrentColorRandomly(){
        int num = Random.Range(0, colorIdList.Count);
        currentColor = colorIdList[num];
    }

}
