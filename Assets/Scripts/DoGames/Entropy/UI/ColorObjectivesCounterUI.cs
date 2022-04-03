using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DoGames.Entropy.UI
{
    public class ColorObjectivesCounterUI : MonoBehaviour
    {

        [SerializeField] protected GameObject parent;
        [SerializeField] protected TextMeshProUGUI receivedCountText;
        [SerializeField] protected TextMeshProUGUI slashText;
        [SerializeField] protected TextMeshProUGUI goalCountText;

        private bool _isActive = true;
        public bool IsActive{
            get{
                return _isActive;
            }
            set{
                if(value){
                    parent?.SetActive(true);
                } else {
                    parent?.SetActive(false);
                }
                _isActive = value;
            }
        }

        public void UpdateColor(Color color)
        {
            if (receivedCountText == null || slashText == null || goalCountText == null)
            {
                Debug.LogError($"Missing fields on ColorObjectivesCounterUI {this.gameObject.name}");
                return;
            }
            receivedCountText.color = color;
            slashText.color = color;
            goalCountText.color = color;

        }

        public void UpdateReceivedCountText(int value)
        {
            if (receivedCountText == null || slashText == null || goalCountText == null)
            {
                Debug.LogError($"Missing fields on ColorObjectivesCounterUI {this.gameObject.name}");
                return;
            }
            receivedCountText.text = $"{value}";
        }
        public void UpdateGoalCount(int value)
        {
            if (receivedCountText == null || slashText == null || goalCountText == null)
            {
                Debug.LogError($"Missing fields on ColorObjectivesCounterUI {this.gameObject.name}");
                return;
            }
            goalCountText.text = $"{value}";
        }

    }

}