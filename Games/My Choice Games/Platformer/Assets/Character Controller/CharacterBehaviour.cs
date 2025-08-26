using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    public CharacterPattern characterPattern;
    public UnityEvent awakeEvent, triggerEnterEvent, triggerExitEvent;
    private bool canRun = true;
    public bool CanRun{
        get{
            return canRun;
        }
        set{
            canRun = value;
        }
    }

    private void Awake()
    {
        awakeEvent.Invoke();
        
        controller = GetComponent<CharacterController>();
    }

    public void SwapPattern(CharacterPattern pattern)
    {
        characterPattern = pattern;
    }
    
    public void Update()
    {
        if(canRun == true){
            characterPattern.Move(controller);
            
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}