using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace DoGames.Entropy.Inputs
{
    /// <summary>
    /// Route all inputs through this scriptable object. 
    /// Attach this input channel to all gameobjects that respond to player input,
    /// and subscribe to actions accordingly.
    /// </summary>
    [CreateAssetMenu(fileName = "EntropyInputChannel", menuName = "Entropy/EntropyInputChannel")]
    public class EntropyInputChannelSO : ScriptableObject, EntropyInputActions.ILauncherActions
    {
        EntropyInputActions gameInputActions;
        public event UnityAction<Vector2> directionAction;
        public event UnityAction<float> aimAction;
        public event UnityAction fireAction;

        private void OnEnable()
        {
            if (gameInputActions == null)
            {
                gameInputActions = new EntropyInputActions();
                gameInputActions.Launcher.SetCallbacks(this);
            }
            gameInputActions.Launcher.Enable();
        }

        private void OnDisable()
        {
            gameInputActions.Launcher.Disable();
        }

        public void OnDirection(InputAction.CallbackContext context){
            Vector2 dir = context.ReadValue<Vector2>();
            if(directionAction != null){
                directionAction.Invoke(dir);
            }
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            if (aimAction != null)
            {
                aimAction.Invoke(value);
            }
        }

        
        public void OnFire(InputAction.CallbackContext context)
        {
            if (fireAction != null
                     && context.phase == InputActionPhase.Performed)
                fireAction.Invoke();
        }
        
    }
}