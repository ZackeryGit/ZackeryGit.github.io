
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;
    // Start is called before the first frame update
    private void Awake()
    {
        gameActionObj.raise += OnAction;
    }

    private void OnAction()
    {
        onRaiseEvent.Invoke();
    }
    
}
