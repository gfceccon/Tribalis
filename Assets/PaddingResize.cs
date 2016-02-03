using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(LayoutGroup))]
public class PaddingResize : MonoBehaviour
{
    public Canvas canvas;
    public float multiplier = 0.3f;
    private LayoutGroup layout;
    private RectOffset offset = new RectOffset();
	// Use this for initialization
	void Start ()
    {
        layout = GetComponent<LayoutGroup>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        offset.left = offset.right = Mathf.FloorToInt(canvas.pixelRect.width * multiplier);
        layout.padding = offset;
	}
}
