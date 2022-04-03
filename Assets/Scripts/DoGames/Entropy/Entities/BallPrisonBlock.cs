using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Entities
{
    /// <summary>
    /// A ball prison needs to let its corresponding color manager know that
    /// it counts towards active balls in play (based on its type)
    /// </summary>
    public class BallPrisonBlock : ProjectileSpawnerBlock
    {
        [Header("--BALL PRISON--")]
        [SerializeField] protected ColorTypeSO type;

        protected override void OnEnable()
        {
            base.OnEnable();
            IncrementActiveCount();
        }
        protected override void OnDisable()
        {
            DecrementActiveCount();
            base.OnDisable();
        }
        protected void IncrementActiveCount()
        {
            if (type == null)
            {
                Debug.LogError($"Missing type in BallPrisonBlock in {this.gameObject.name}");
            }
            type.activeCountChannel.RaiseEvent(1);
        }

        protected void DecrementActiveCount()
        {
            if (type == null)
            {
                Debug.LogError($"Missing type in BallPrisonBlock in {this.gameObject.name}");
            }
            type.activeCountChannel.RaiseEvent(-1);
        }


    }
}