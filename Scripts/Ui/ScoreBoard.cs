using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui
{
    public class ScoreBoard : MonoBehaviour
    {

        public static int Score { get; set; }
        
        [SerializeField] private TextMeshProUGUI scoreText;

		[SerializeField] private float timeUnitlStarve;

		[SerializeField] private float hunger;

		[SerializeField] private HealthBar healthBar;

		
		[SerializeField] private Rabbit theRabbit;
		[SerializeField] private Image blackScreen;

		[SerializeField] private SoundManager soundMan;

		private float _timeLeftUnitlStarve;
		[SerializeField] private float _timeEndScreen = 1f;//make longer when not testing

        public void Awake()
        {
            TreeHouse.OnPointsGained += AddToScore;
			_timeLeftUnitlStarve = timeUnitlStarve;
			soundMan.PlaySound(9);
			Score = 0;
        }
        
        private void AddToScore(int pointsGained)
        {
            Score += pointsGained;

            Debug.Log($"{Score}");
            
            scoreText.text = $"{Score}";
			soundMan.PlaySound(2);

			// reset time until starve
			_timeLeftUnitlStarve = timeUnitlStarve;

        }

		public void QuickHunger()
        {

			_timeLeftUnitlStarve = 0.5f;
        }

		private void FixedUpdate()
		{

			//Debug.Log($"{_timeLeftUnitlStarve} {hunger} {Time.deltaTime}");

			_timeLeftUnitlStarve -= hunger * Time.fixedDeltaTime;


			if (_timeLeftUnitlStarve <= 0)
			{
				Debug.Log("You Lose!");
				_timeEndScreen -= Time.fixedDeltaTime;
				
				
				theRabbit.KillRabbit();
				
				blackScreen.color = new Color(0f, 0f, 0f, 0.5f);

			}

			//Debug.Log($"{_timeLeftUnitlStarve} {_timeEndScreen}");

			if ((_timeLeftUnitlStarve <= 0)&&(_timeEndScreen <=0))
			{
				Debug.Log("called scenemanager successfully");
				//Debug.Log("You Lose!");
				SceneManager.LoadScene(SceneUtil.ScoreScene);

				soundMan.PlaySound(11);
			}
			
			float healthPercent = _timeLeftUnitlStarve / timeUnitlStarve;

			healthBar.Health = healthPercent;

		}

		private void Update()
		{
	        if (Input.GetKey(KeyCode.Escape))
	        {
    	        Application.Quit();
	        }
		}
    }

}
