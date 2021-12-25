using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, PlayerActions.IPlayerControlsActions
{
    PlayerActions Actions;
    public bool jumpedThisFrame{get; private set;}
    public float moveValue{get; private set;}

    private void Awake()
    {
        Actions = new PlayerActions();
        Actions.PlayerControls.SetCallbacks(this);
        Actions.Enable();
    }

    private void OnEnable() => Actions.Enable();
    private void OnDisable() => Actions.Disable();
    public void OnMovements(InputAction.CallbackContext context) => moveValue = context.ReadValue<float>(); 
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
            jumpedThisFrame = true;
        else if(context.canceled)
            jumpedThisFrame = false;    
    }
   
}
