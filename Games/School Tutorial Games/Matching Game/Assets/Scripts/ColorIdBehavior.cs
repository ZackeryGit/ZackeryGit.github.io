using UnityEngine;

public class ColorIdBehavior : IDContainerBehavior
{
    public ColorIDList colorIDListObj;

    private void Awake(){
        idObj = colorIDListObj.currentColor;
    }
}
