using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
   public class SplashScreen : MonoBehaviour
    {

        public void StartGame()
        {
            SceneManager.LoadScene(1);
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