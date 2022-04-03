using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Vfx;
using DoGames.Entropy.Managers;

namespace DoGames.Entropy.Entities
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] protected BallSO ballData;
        [SerializeField] CameraShake cameraShaker;
        GameManager gameManager;

        public ColorTypeSO type
        {
            get
            {
                if (ballData != null)
                {
                    return ballData.type;
                }
                else
                {
                    Debug.LogError($"ballData missing in Ball {this.gameObject.name}");
                    return null;
                }
            }
        }

        protected void Start()
        {
         
            gameManager = GameManager.Instance;
            
            if (ballData == null)
            {
                Debug.LogError($"ballData is missing on {this.gameObject.name}");
            }


            if (cameraShaker == null)
            {
                cameraShaker = FindObjectOfType<CameraShake>();
            }
        }

        protected void OnEnable(){
            TransmitActive(1);

        }

        protected void OnDisable(){
            TransmitActive(-1);
        }


        /// <summary>
        /// Let gameManagers know this ball is contributing to the active 
        /// ball count (used to compute whether the game has reached an
        /// unwinnable state.
        /// </summary>
        /// <param name="value"></param>
        protected void TransmitActive(int value){
            if(type == null){
                Debug.LogError($"Missing type in Ball in {this.gameObject.name}");
            }
            type.activeCountChannel.RaiseEvent(value);
        }

        protected void OnCollisionEnter2D(Collision2D col)
        {
            if (ballData == null)
            {
                Debug.LogError($"Missing ballData on {this.gameObject.name}");
                return;
            }

            Ball otherBall;
            if (col.gameObject.TryGetComponent<Ball>(out otherBall))
            {
                AudioSource.PlayClipAtPoint(otherBall.ballData.ballToBallSound, Vector3.zero);
                if (otherBall.ballData != null && otherBall.ballData.type == this.ballData.type)
                {
                    // Balls are of the same type. Trigger cancel out behavior
                    otherBall.DestroyCancelOut();
                    this.DestroyCancelOut();
                }
            }
        }

        public void DestroyAbsorb(){
             if (ballData.cancelOutSound != null)
            {
                AudioSource.PlayClipAtPoint(ballData.cancelOutSound, transform.position);
            }
            gameManager.Score += ballData.absorbScore;
            Destroy();
        }

        public void DestroyCancelOut()
        {
            ApplyCancelOutScore();
            if (ballData.cancelOutPrefab != null)
            {
                Instantiate(ballData.cancelOutPrefab, transform.position, transform.rotation);
            }
            if (ballData.cancelOutSound != null)
            {
                AudioSource.PlayClipAtPoint(ballData.cancelOutSound, transform.position);
            }
            Destroy();
        }

        public void ApplyCancelOutScore(){
            gameManager.Score += ballData.cancelOutScore;
        }

        public void DestroyHitBoundary(Vector2 impactDirection)
        {
            if (ballData.boundaryDeathPrefab != null)
            {
                Instantiate(ballData.boundaryDeathPrefab, transform.position, Quaternion.LookRotation(-impactDirection));
            }

            if (cameraShaker != null)
            {
                cameraShaker.Shake(ballData.cameraShakeDuration, ballData.cameraShakeMagnitude);
            }

            if (ballData.boundaryDeathSound != null)
            {
                AudioSource.PlayClipAtPoint(ballData.boundaryDeathSound, transform.position);
            }

            Destroy();
        }

        protected void Destroy()
        {
            this.gameObject.SetActive(false);
        }
    }
}