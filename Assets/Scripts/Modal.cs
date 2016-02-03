using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Modal : MonoBehaviour
{
    public GameObject optionPrefab;
    public Text description;
    public float fontDownscale = 0.4f;

    private Game master;
    private Event currentEvent = null;
    private EventsList list = null;


    void Start()
    {
        master = GetComponentInParent<Game>();
        list = master.list;
    }

    void Update()
    {
        if(description != null)
            description.fontSize = Mathf.RoundToInt(Camera.main.pixelWidth * fontDownscale);
    }

    public void Event(EventsList.Events option)
    {
        master.Return(option);
        Destroy(gameObject);
    }

    public void CreateModal(Event modalEvent)
    {
        if (currentEvent != null)
            return;
        if(list == null)
        {
            master = GetComponentInParent<Game>();
            list = master.list;
        }
        currentEvent = modalEvent;

        GetComponent<Image>().sprite = currentEvent.image;
        
        description.text = currentEvent.text;
        if(currentEvent.options.Length == 0)
        {
            GameObject button = Instantiate<GameObject>(optionPrefab);
            RectTransform buttonTransform = button.GetComponent<RectTransform>();
            buttonTransform.SetParent(transform, false);
            buttonTransform.sizeDelta.Set(1f, 1f);
            button.GetComponentInChildren<Text>().text = "Continuar";
            button.GetComponent<ModalButton>().option = EventsList.Events.None;
        }
        else foreach (Option op in currentEvent.options)
        {
            bool isOpAvaiable = true;
            if (list.events[(int)op.consequence] != null)
                foreach (EventsList.Events req in list.events[(int)op.consequence].requirements)
                {
                    if (list.completed[(int)req] == false)
                    {
                        isOpAvaiable = false;
                        break;
                    }
                }
            if(isOpAvaiable)
            {
                GameObject button = Instantiate<GameObject>(optionPrefab);
                RectTransform buttonTransform = button.GetComponent<RectTransform>();
                buttonTransform.SetParent(transform, false);
                buttonTransform.sizeDelta.Set(1f, 1f);
                button.GetComponentInChildren<Text>().text = op.optionText;
                button.GetComponent<ModalButton>().option = op.consequence;
            }
        }
    }
}
