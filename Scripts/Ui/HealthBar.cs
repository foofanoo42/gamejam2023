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
            //Color currentColor = Color.Lerp(fullHealth, noHealth, healthPercent);
            //bar.color = currentColor;

            //bar.rectTransform.rect = new Rect( );

            //Rect oldRect = bar.rectTransform.rect;
            //bar.rectTransform.rect = new Rect(oldRect.x, oldRect.y, healthPercent, oldRect.height);

            Debug.Log($"{healthPercent}");
            
            SetWidth(healthPercent);

        }

        private void SetWidth(float width)
        {
            RectTransform rectTransform = bar.rectTransform;
            
            Debug.Log($"Update Bar Width {width}");
            
            Debug.Log($"{rectTransform.offsetMin.x} {rectTransform.offsetMin.x + _initialOffsetMax.x * width}");
            
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMin.x + _initialOffsetMax.x * width, _initialOffsetMax.y);
        }
        
        // public void SetSize(Vector2 newSize) {
        //     Vector2 oldSize = trans.rect.size;
        //     Vector2 deltaSize = newSize - oldSize;
        //     bar.rectTransform.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * bar.rectTransform.pivot.x, deltaSize.y * bar.rectTransform.pivot.y);
        //     bar.rectTransform.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - bar.rectTransform.pivot.x), deltaSize.y * (1f - bar.rectTransform.pivot.y));
        // }
        
    }
}