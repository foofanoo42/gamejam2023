using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{

    public void PlayAgain()
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
