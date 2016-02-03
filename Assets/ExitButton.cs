using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButton : MonoBehaviour
{
    public Text playButtonText;
    public int size = 16;
    void Start()
    {
#if UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_EDITOR
        gameObject.SetActive(false);
        playButtonText.fontSize += size;
#endif
    }
    public void OnClick()
    {
        Application.Quit();
    }
}
