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

        private Vector2 _initialOffsetMax;
       
        public void Awake()
        {
            _initialOffsetMax = bar.rectTransform.offsetMax;
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
            RectTransform rectTransform = bar.rectTransform;
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMin.x + _initialOffsetMax.x * width, _initialOffsetMax.y);
        }
        
    }
}