using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Entities
{
    /// <summary>
    /// Spawner blocks keep spawning and don't die on hit
    /// </summary>
    public class ProjectileSpawnerBlock : BaseBlock
    {
        protected override void BallHit(Ball otherBall)
        {
            Vector2 launchDirection = (this.transform.position - otherBall.transform.position).normalized;
            LaunchDeathPrefab(otherBall.transform.position, launchDirection);
            Death();
        }


        protected void LaunchDeathPrefab(Vector2 origin, Vector2 launchDirection)
        {
            if (blockData.deathPrefab != null)
            {
                GameObject newObj = Instantiate(blockData.deathPrefab, origin, this.transform.rotation);
                Rigidbody2D newRb;
                if(newObj.TryGetComponent<Rigidbody2D>(out newRb)){
                    newRb.AddRelativeForce(blockData.launchSpeed * launchDirection);
                }
            }
        }

    }
}