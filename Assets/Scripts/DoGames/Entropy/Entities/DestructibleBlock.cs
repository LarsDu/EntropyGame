using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DoGames.Entropy.Entities
{
    public class DestructibleBlock : BaseBlock
    {
        protected override void BallHit(Ball otherBall){
            SpawnDeathPrefab();
            Death();
        }

    }
}