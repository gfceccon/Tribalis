using UnityEngine;
using System.Collections;

public class IntroButton : MonoBehaviour
{
    public GameObject canvas;
    public void OnClick()
    {
        canvas.SetActive(false);
    }
}
