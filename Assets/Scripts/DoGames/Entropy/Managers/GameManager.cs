using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DoGames.Events;
namespace DoGames.Entropy.Managers
{   
       public class GameManager : MonoBehaviour
    {
        [SerializeField] IntEventChannelSO totalScoreChannel;
        [SerializeField] List<ColorManager> colorManagers;
        public static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
        public UnityEvent OnGameOver;
        public UnityEvent OnLevelComplete;
        public UnityEvent OnPause;

        private int _score;
        public int Score
        {
            get { return _score; }
            set { 
                _score = value; 
                totalScoreChannel?.RaiseEvent(_score);
            }
        }

        // Used to prevent victory logic from executing once the current level is over
        protected bool isGameEnded = false;
        

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                // Destroy duplicates
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        protected void Start(){
            Initializer();
        }

        protected void Initializer(){

            Time.timeScale = 1;
            Physics.gravity = new Vector3(0, 0, -10);
            Physics2D.gravity = new Vector2(0, -10);
        }

        public void Pause(){
            OnPause?.Invoke();
            
        }

        public void GameOver(){
            if(isGameEnded){
                return;
            }
            isGameEnded = true;
            OnGameOver?.Invoke();
            StopAllCoroutines();
            StartCoroutine(PauseInSecs(4));
            //Pause();
        }

        public void GameOverUnwinnable(string colorName){
            GameOver();
            // TODO: Add unwinnable state message to canvas.
        }

        public void LevelComplete(){
            if(isGameEnded){
                return;
            }

            isGameEnded = true;
            OnLevelComplete?.Invoke();
            StopAllCoroutines();
            StartCoroutine(PauseInSecs(.2f));
        }
        
        public void CheckVictoryConditions(){
            bool isVictory = true;

            foreach (ColorManager colorManager in colorManagers){
                isVictory &= colorManager.isThresholdReached;
            }

            // If all colorManagers have reached their thresholds
            // victory is achieved.
           if (isVictory){
               LevelComplete();
           }
        }

        protected IEnumerator PauseInSecs(float secs){
            yield return new WaitForSeconds(secs);
            Time.timeScale = 0f;
        }
    }
}
