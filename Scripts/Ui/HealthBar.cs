using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Ui
{
   public class HealthBar : MonoBehaviour
    {
        [SerializeField] public float health;

        public float Health
        {
            get => health;

            set
            {
                health = value;
                UpdatHealth(health);
            }
        }
        
        [SerializeField] Image bar;
        [SerializeField] private Color fullHealth;
        [SerializeField] private Color noHealth;

        /// <summary>
        /// 
        /// </summary>
        //private Vector2 _initialOffsetMax;

        [SerializeField] private float _maxWidth;

        [SerializeField] private float _topY;
        [SerializeField] private float _bottomY;

        [SerializeField] private float _leftX;
        
        /// <summary>
        /// 
        /// </summary>
        public void Awake()
        {
            _leftX = bar.rectTransform.offsetMin.x;
            _bottomY = bar.rectTransform.offsetMin.y;
            _topY = bar.rectTransform.offsetMax.y;
            _maxWidth = bar.rectTransform.offsetMax.x - bar.rectTransform.offsetMin.x;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="healthPercent"></param>
        /// <returns></returns>
        public void UpdatHealth(float healthPercent)
        {
            Color currentColor = Color.Lerp(noHealth,fullHealth, healthPercent);
            bar.color = currentColor;
            SetWidth(healthPercent);
        }

        private void SetWidth(float width)
        {

            float percent = width;
            
            //RectTransform rectTransform = bar.rectTransform;

            float newEndPoint = _leftX + _maxWidth * percent;

            Debug.Log($"{_leftX} {_maxWidth} {percent} {newEndPoint}");
            
            //Debug.Log($"{width} {bar.rectTransform.offsetMin.x} {newEndPoint} {bar.rectTransform.offsetMax.x}");
            
            bar.rectTransform.offsetMax = new Vector2(newEndPoint, _topY);
        }
        
    }
}