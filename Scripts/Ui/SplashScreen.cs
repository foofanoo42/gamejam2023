using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
   public class SplashScreen : MonoBehaviour
    {

        public void StartGame()
        {
            Debug.Log($"Loading Scene: {SceneUtil.PlayScene}");
            SceneManager.LoadScene(SceneUtil.PlayScene);
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        
    }
}