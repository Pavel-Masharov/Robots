using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSettings : MonoBehaviour
{

    [SerializeField] private Image _imageLoadingBar;
    [SerializeField] private DotsLoading _dotsLoading;

    private string _nameMainScene = "MainMenu";
    private void Start()
    {
        StartCoroutine(LoadingView(2));

        _dotsLoading.StartAnim();
    }


    private IEnumerator LoadingView(float timeLoading)
    {
        float time = 0;

        while (time < timeLoading)
        {

            yield return null;
            time += Time.deltaTime;
           // Debug.Log(time);
            var percent = time / timeLoading;

            _imageLoadingBar.fillAmount = percent;
        }

        SceneManager.LoadScene(_nameMainScene);
    }

}
