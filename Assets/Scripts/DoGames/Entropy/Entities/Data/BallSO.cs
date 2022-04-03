using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Entities
{
    [CreateAssetMenu(fileName = "BallSO", menuName = "Entropy/BallSO")]
    public class BallSO : ScriptableObject
    {
        [Tooltip("For color interactions")]
        public ColorTypeSO type;
        
        [Header("Ball to ball interactions")]
        [Tooltip("For when the ball hits a ball of like color and cancels out")]
        public GameObject cancelOutPrefab;
        public int cancelOutScore = 50;
        public AudioClip cancelOutSound;
        public AudioClip ballToBallSound;

        [Header("Boundary interactions")]
        [Tooltip("For when the ball hits the outer boundary")]
        public GameObject boundaryDeathPrefab;
        public AudioClip boundaryDeathSound;
        public float cameraShakeDuration = 0.1f;
        public float cameraShakeMagnitude = 0.1f;

        [Header("Absorb interactions")]
        public AudioClip absorbSound;
        public int absorbScore = 500;
    }
}
