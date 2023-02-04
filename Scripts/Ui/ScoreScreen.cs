using System.Collections;
using System.Collections.Generic;
using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TextMeshProUGUI scorelabel;
    
    /// <summary>
    /// 
    /// </summary>
    public void PlayAgain()
    {
		Debug.Log($"Loading Scene: {SceneUtil.PlayScene}");
        SceneManager.LoadScene(SceneUtil.PlayScene);
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        scorelabel.text = $"Score: {ScoreBoard.Score}";
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
}
