using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Events;
using DoGames.Entropy.Managers;

namespace DoGames.Entropy.Entities
{
    /// <summary>
    /// Indestructible block that absorbs balls if 
    /// of the same color
    /// </summary>
    public class ReceiverBlock : BaseBlock
    {
        [Header("--RECEIVER--")]
        [SerializeField] protected ColorTypeSO type;

        protected override void BallHit(Ball otherBall)
        {
            if (otherBall.type == this.type)
            {
                // Note DestroyAbsorb() increments the score counter as well.
                // As well as the receivedCountChannel
                TransmitReceived();
                otherBall.DestroyAbsorb();
            }
        }

        protected void TransmitReceived()
        {
            if (type == null)
            {
                Debug.LogError($"Missing type in {this.gameObject.name}");
                return;
            }
            type.receivedCountChannel.eventAction.Invoke(1);

        }



    }
}