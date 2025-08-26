
using UnityEngine;

public class ColorMatchBehavior : MatchBehvior {
    public ColorIDList colorIDListObj;

    private void Awake(){
        idObj = colorIDListObj.currentColor;
    }

    public void ChangeColor(SpriteRenderer renderer)
    {
        var newColor = idObj as ColorID;
        renderer.color = newColor.value;
    }
}

