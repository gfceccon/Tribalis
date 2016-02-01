using UnityEngine;
using System.Collections;

public class ModalButton : MonoBehaviour
{
    public EventsList.Events? option;

    public void OnClick()
    {
        GetComponentInParent<Modal>().Event(option);
    }

}
