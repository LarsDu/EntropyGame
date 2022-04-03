using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Events;
using TMPro;

namespace DoGames.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ReadoutUI : MonoBehaviour
    {
        [SerializeField] IntEventChannelSO valueChannel;
        TextMeshProUGUI textField;

        protected void Start(){
            textField = GetComponent<TextMeshProUGUI>();
        }

        protected void OnEnable()
        {
            if (valueChannel != null)
            {
                valueChannel.eventAction += UpdateReadout;
            }
            else
            {
                Debug.LogError($"Error missing totalScoreChannel in {this.gameObject.name}.");
            }
        }

        protected void OnDisable()
        {
            if (valueChannel != null)
            {
                valueChannel.eventAction -= UpdateReadout;
            }
            else
            {
                Debug.LogError($"Error missing totalScoreChannel in {this.gameObject.name}.");
            }

        }

        protected void UpdateReadout(int value){
            textField.text = $"{value}";
        }   
    }
}