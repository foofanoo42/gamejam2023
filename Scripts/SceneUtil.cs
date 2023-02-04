using UnityEngine.SceneManagement;


public static class SceneUtil
{

    public const int SplashScene = 0;

    public const int PlayScene = 1;
    
    public const int ScoreScene = 2;
    
    public static void LoadSplashScreen() => SceneManager.LoadScene(SceneUtil.ScoreScene);
    
    public static void LoadPlayScreen() => SceneManager.LoadScene(SceneUtil.PlayScene);
    
    public static void LoadScoreScreen() => SceneManager.LoadScene(SceneUtil.ScoreScene);
    
}