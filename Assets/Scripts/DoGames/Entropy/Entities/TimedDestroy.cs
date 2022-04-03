using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Entities
{
    /// <summary>
    /// Attach to things like particle effects to destroy them after some time.
    /// </summary>
    public class TimedDestroy : MonoBehaviour
    {
        [SerializeField] protected float seconds = 10f;
        protected void OnEnable()
        {
            Destroy(this, seconds);
        }

    

    }
}