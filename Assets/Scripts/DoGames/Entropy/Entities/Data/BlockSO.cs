using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Entities
{
    [CreateAssetMenu(fileName = "BlockSO", menuName = "Entropy/BlockSO")]
    public class BlockSO : ScriptableObject
    {
        [Tooltip("Score yielded by this block when it is destroyed")]
        public int deathScore = 0;
        public float launchSpeed = 0;
        public GameObject deathPrefab;
        public AudioClip deathSound;
    }
}