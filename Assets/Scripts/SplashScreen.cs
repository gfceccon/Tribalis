using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class SplashScreen : MonoBehaviour {
    public float targetAlpha = 0f;
    public float fadeIn = 1f;
    public float stay = 1f;
    public float fadeOut = 1f;
    public string sceneName;
    private Image img;
    private AsyncOperation loadScene;
	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
        StartCoroutine(FadeCoroutine());
	}

    private IEnumerator LoadScene()
    {
        loadScene = SceneManager.LoadSceneAsync(sceneName);
        loadScene.allowSceneActivation = false;
        yield return loadScene;
    }

    private IEnumerator FadeCoroutine()
    {
        float time = 0f;
        Color c = img.color;
        float alpha = c.a;
        while (time < fadeIn)
        {
            c.a = GameMusic.CosineInterpolate(alpha, 0f, time / fadeIn);
            img.color = c;
            yield return null;
            time += Time.deltaTime;
        }
        StartCoroutine(LoadScene());
        yield return new WaitForSeconds(stay);
        time = 0f;
        while (time < fadeOut)
        {
            c.a = GameMusic.CosineInterpolate(0f, alpha, time / fadeOut);
            img.color = c;
            yield return null;
            time += Time.deltaTime;
        }
        loadScene.allowSceneActivation = true;
    }
}
