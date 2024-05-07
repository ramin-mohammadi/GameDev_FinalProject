using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] private bool fadeInOnStart = false;

    void Start(){
        // fadeImage.transform.position = new Vector3(-1426.53f, 5.94f, 0);
        if(fadeInOnStart){
            FadeToClear();
        }
    }

    void FadeToClear(){
        StartCoroutine(FadeToClearRoutine());
        IEnumerator FadeToClearRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                yield return null;
                timer+=Time.deltaTime;
                fadeImage.rectTransform.anchoredPosition = new Vector2(fadeImage.rectTransform.anchoredPosition.x - timer * 3.3f, fadeImage.rectTransform.anchoredPosition.y);
            }
        }
    }

    public void FadeToColor(string newScene = ""){
        StartCoroutine(FadeToColorRoutine());
        IEnumerator FadeToColorRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                yield return null;
                timer+=Time.deltaTime;
                // fadeImage.color = new Color(fadeColor.r,fadeColor.g,fadeColor.b, (timer/fadeTime));
                // fadeImage.rectTransform.anchoredPosition = new Vector2(fadeImage.rectTransform.anchoredPosition.x + timer * 3.6f, fadeImage.rectTransform.anchoredPosition.y);
            }
            if(newScene != ""){
                SceneManager.LoadScene(newScene);
            }
        }
    }
}
