using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VrMovie
{
    [RequireComponent(typeof(Text))]
    public class InformationText : MonoBehaviour
    {
        Text informationText;
        Coroutine currentFadeTextCoroutine;
        
        void Awake()
        {
            informationText = GetComponent<Text>();
            informationText.enabled = false;
        }

        public void Show(string text,float duration)
        {
            informationText.text = text;
            
            if (currentFadeTextCoroutine != null)
            {
                StopCoroutine(currentFadeTextCoroutine);
                informationText.enabled = false;
            }

            currentFadeTextCoroutine = StartCoroutine(VisibleText(duration));
        }

        IEnumerator VisibleText(float duration)
        {
            informationText.enabled = true;
            yield return new WaitForSeconds(duration);
            informationText.enabled = false;
        }
    }
}