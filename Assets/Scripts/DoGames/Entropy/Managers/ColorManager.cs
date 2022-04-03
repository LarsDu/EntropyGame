using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Entropy.Entities;
using TMPro;
using DoGames.Entropy.UI;
namespace DoGames.Entropy.Managers
{
    /// <summary>
    /// Manages the objectives for a given color type
    /// Important note: there can be a slight race condition with this class on initialization
    /// This script has been set to execute early in ProjectSettings>>Script Execution Order settings.
    /// </summary>
    [RequireComponent(typeof(ColorObjectivesCounterUI))]
    public class ColorManager : MonoBehaviour
    {
        [SerializeField] protected ColorTypeSO type;
        [Tooltip("Receive this many to meet the victory conditions for this color")]
        [SerializeField] protected int goalThreshold = 1;
        protected GameManager gameManager;
        protected ColorObjectivesCounterUI objectivesCounter;

        public bool isThresholdReached{

            get{
                return (receivedCount >= goalThreshold);
            }
        }

        // The number of balls that have been received
        private int _receivedCount = 0;
        protected int receivedCount
        {
            get
            {
                return _receivedCount;
            }

            set
            {
                _receivedCount = value;
                objectivesCounter?.UpdateReceivedCountText(_receivedCount);
                CheckIfUnwinnable();
                gameManager?.CheckVictoryConditions();

            }
        }

        private int _activeCount = 0;
        protected int activeCount
        {
            get
            {
                return _activeCount;
            }

            set
            {
                _activeCount = value;
                CheckIfUnwinnable();
                gameManager?.CheckVictoryConditions();
            }
        }

        protected void Start()
        {
            gameManager = GameManager.Instance;
            objectivesCounter = GetComponent<ColorObjectivesCounterUI>();
            SetObjectivesCounterColorGoal();
        }

        protected void OnEnable()
        {
            RegisterColorChannels();
        }

        protected void OnDisable()
        {
            UnregisterColorChannels();
        }


        protected void RegisterColorChannels()
        {
            if (type == null)
            {
                Debug.LogError("Missing color channel!");
                return;
            }

            type.activeCountChannel.eventAction += AddToActiveCount;
            type.receivedCountChannel.eventAction += AddToReceivedCount;

        }

        protected void UnregisterColorChannels()
        {
            if (type == null)
            {
                Debug.LogError("Missing color channel!");
                return;
            }

            type.activeCountChannel.eventAction -= AddToActiveCount;
            type.receivedCountChannel.eventAction -= AddToReceivedCount;

        }

        protected void AddToReceivedCount(int value)
        {
            receivedCount += value;
        }

        protected void AddToActiveCount(int value)
        {
            activeCount += value;
        }


        protected void SetObjectivesCounterColorGoal()
        {
            objectivesCounter.UpdateColor(type.color);
            if (goalThreshold > 0)
            {
                objectivesCounter.UpdateGoalCount(goalThreshold);
                objectivesCounter.IsActive = true;
            }
            else
            {
                objectivesCounter.IsActive = false;
            }
        }

        /// <summary>
        /// Determine whether the number of active colors currently makes
        /// the game unwinnable. If unwinnable trigger a GameOver
        /// </summary>
        protected void CheckIfUnwinnable(){
            // Check 

            Debug.Log($"{type.name}, active: {activeCount}, received:{receivedCount}, goal:{goalThreshold}");
            if(activeCount + receivedCount < goalThreshold){
                gameManager?.GameOverUnwinnable(type.name);
            }

        }

    }
}