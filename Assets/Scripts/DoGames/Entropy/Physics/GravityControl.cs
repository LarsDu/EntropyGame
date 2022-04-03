using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Entropy.Inputs;

namespace DoGames.Entropy.Phys
{
    public class GravityControl : MonoBehaviour
    {
        [SerializeField] protected EntropyInputChannelSO inputChannel;
        [SerializeField] protected float gravity = 10f;

        // This can be set in inputActions. this deadzone is specific to gravity control
        private const float DEADZONE = 0.5f;
        protected void OnEnable()
        {
            if (inputChannel != null)
            {
                inputChannel.directionAction += TryAlterGravity;
            }
            else
            {
                Debug.LogError($"Missing inputChannel for GravityControl in {this.gameObject.name}");
            }
        }

        protected void OnDisable()
        {
            if (inputChannel != null)
            {
                inputChannel.directionAction -= TryAlterGravity;
            }
            else
            {
                Debug.LogError($"Missing inputChannel for GravityControl in {this.gameObject.name}");
            }
        }

        /// <summary>
        /// Try to alter global gravity settings
        /// left and right has precedence over up and down if hit at the same time
        /// </summary>
        /// <param name="direction"></param>
        protected void TryAlterGravity(Vector2 direction)
        {

            void _SetGravity(Vector2 newGravity)
            {
                
                Physics2D.gravity = newGravity;
                // For particle physics
                Physics.gravity = newGravity;
            }

            //Debug.Log($"Gravity input set to {direction}");
            if (direction.x > DEADZONE)
            {
                // Gravity right
                _SetGravity(new Vector2(10, 0));
            }
            else if (direction.x < -DEADZONE)
            {
                // Gravity left
                _SetGravity(new Vector2(-10, 0));
            }
            else if (direction.y > DEADZONE)
            {
                _SetGravity(new Vector2(0, 10));
            }
            else if (direction.y < -DEADZONE)
            {
               _SetGravity(new Vector2(0, -10));
            }
        }

    }
}