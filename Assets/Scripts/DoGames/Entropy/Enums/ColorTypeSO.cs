using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Events;

namespace DoGames.Entropy.Entities
{
    [CreateAssetMenu(fileName = "ColorTypeSO", menuName = "Entropy/ColorTypeSO")]
    public class ColorTypeSO : ScriptableObject
    {
        public Color color;
        [Tooltip("Transmits the number of colored balls counting towards level goals")]
        public IntEventChannelSO receivedCountChannel;
        [Tooltip("Transmits the number of active colors (balls or ball prisons)")]
        public IntEventChannelSO activeCountChannel;
    }
}