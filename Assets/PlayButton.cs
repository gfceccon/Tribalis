using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    public string gameSceneName;
    public void OnClick()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
