using UnityEngine;
using System.Collections;

public class ModalButton : MonoBehaviour
{
    public EventsList.Events option;
    [HideInInspector]
    public AudioSource source;

    public void OnClick()
    {
        source.Play();
        GetComponentInParent<Modal>().Event(option);
    }

}
