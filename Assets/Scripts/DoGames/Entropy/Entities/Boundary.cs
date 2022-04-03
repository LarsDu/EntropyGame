using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Entropy.Managers;
using DoGames.Vfx;
namespace DoGames.Entropy.Entities
{
    public class Boundary : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        protected void Start(){
            if(gameManager == null){
                // Get gameManager singleton
                gameManager = GameManager.Instance;
            }
        }
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            Ball ball;
            if(collision.gameObject.TryGetComponent<Ball>(out ball)){
                ball.DestroyHitBoundary(collision.relativeVelocity.normalized);
                gameManager.GameOver();
            }
        }
    }
}