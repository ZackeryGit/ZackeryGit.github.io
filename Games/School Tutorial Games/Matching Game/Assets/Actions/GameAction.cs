using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu]
public class GameAction : ScriptableObject
{

public UnityAction raise;

    // Start is called before the first frame update
    public void RaiseAction(){
        raise?.Invoke();
    }


}
