using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Entropy.Managers;

namespace DoGames.Entropy.Entities
{
    public class BaseBlock : MonoBehaviour
    {
        [SerializeField] protected BlockSO blockData;
        protected GameManager gameManager;


        protected virtual void Start()
        {
           
            gameManager = GameManager.Instance;
            
            if (blockData == null)
            {
                Debug.LogError($"blockData is missing on {this.gameObject.name}");
            }
        }

        protected virtual void OnEnable(){}

        protected virtual void OnDisable(){}
        protected virtual void OnCollisionEnter2D(Collision2D col)
        {
            Ball otherBall;
            if (col.gameObject.TryGetComponent<Ball>(out otherBall))
            {
                BallHit(otherBall);
            }
        }

        protected virtual void BallHit(Ball otherBall)
        {

        }

        protected virtual void Death()
        {
            PlayDeathSound();
            IncrementScore();
            this.gameObject.SetActive(false);
        }

        
        protected virtual void SpawnDeathPrefab()
        {
            if (blockData.deathPrefab != null)
            {
                Instantiate(blockData.deathPrefab, this.transform.position, this.transform.rotation);
            }
        }
        

    

        protected void PlayDeathSound()
        {

            AudioSource.PlayClipAtPoint(blockData.deathSound, Vector3.zero);

        }

        protected void IncrementScore(){
            gameManager.Score += blockData.deathScore;
        }
    }
}