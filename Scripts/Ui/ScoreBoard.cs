using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ui
{
    public class ScoreBoard : MonoBehaviour
    {

        [SerializeField] private int _score;
        
        [SerializeField] private TextMeshProUGUI scoreText;

		[SerializeField] private float timeUnitlStarve;

		[SerializeField] private float hunger;

		[SerializeField] private HealthBar healthBar;

		private float _timeLeftUnitlStarve;

        public void Awake()
        {
            TreeHouse.OnPointsGained += AddToScore;
			_timeLeftUnitlStarve = timeUnitlStarve;
        }
        
        private void AddToScore(int pointsGained)
        {
            _score += pointsGained;

            Debug.Log($"{_score}");
            
            scoreText.text = $"{_score}";

			// reset time until starve
			_timeLeftUnitlStarve = timeUnitlStarve;

        }
        
		private void FixedUpdate()
		{

			Debug.Log($"{_timeLeftUnitlStarve} {hunger} {Time.deltaTime}");

			_timeLeftUnitlStarve -= hunger * Time.fixedDeltaTime;

			if (_timeLeftUnitlStarve <= 0)
			{
				Debug.Log("You Lose!");
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
