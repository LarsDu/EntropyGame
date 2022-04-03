using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DoGames.Entropy.Scenes
{
    public class SceneChanger : MonoBehaviour
    {
        
        [SerializeField] string sceneName;

        public void ChangeScene(){
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void ReloadCurrentScene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}