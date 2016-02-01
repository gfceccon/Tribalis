using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(EventsList))]
public class Game : MonoBehaviour
{
    public StatusPanel status;
    public Society society;
    public GameObject modalPrefab;
    public GameObject dummy;
    public float delayTime = 2f;
    public float visibleTime = 0.2f;
    
    [HideInInspector]
    public EventsList list;
    private EventsList.Events? currentEvent;
    private Image dummyImage;
    private bool ready = true;
    private bool immediate = false;

    void Start()
    {
        if (list == null)
            list = GetComponent<EventsList>();
        dummyImage = dummy.GetComponent<Image>();
    }

    void Update()
    {
        if (ready)
        {
            ready = false;
            StartCoroutine("NextEvent");
        }
    }

    IEnumerator NextEvent()
    {
        Event e = null;
        bool ok = false;
        if (immediate)
        {
            e = list.events[(int)currentEvent];
            ok = true;
        }
        else foreach (EventsList.Events eventEnum in list.eventsOnTime)
            {
                if (list.completed[(int)eventEnum])
                    continue;

                e = list.events[(int)eventEnum];
                bool isEvAvaiable = true;
                foreach (EventsList.Events req in e.requirements)
                {
                    if (list.completed[(int)req] == false)
                        isEvAvaiable = false;
                }
                if (isEvAvaiable)
                {
                    currentEvent = eventEnum;
                    ok = true;
                    break;
                }
            }
        if (ok)
        {
            float time = Time.realtimeSinceStartup;
            Color color = dummyImage.color;
            if (e.defaultImg)
            {
                dummyImage.sprite = null;
                yield return new WaitForSeconds(delayTime);
            }
            else
            {
                while (Time.realtimeSinceStartup < time + delayTime)
                {
                    dummyImage.sprite = e.image;
                    color.a = Mathf.Lerp(0f, 1f, (Time.realtimeSinceStartup - time) / delayTime);
                    dummyImage.color = color;
                    yield return new WaitForEndOfFrame();
                }
                yield return new WaitForSeconds(visibleTime);

                dummyImage.sprite = null;
            }

            dummyImage.color = color;
            dummy.SetActive(false);

            GameObject modal = Instantiate<GameObject>(modalPrefab);
            modal.transform.SetParent(transform);
            modal.GetComponent<Modal>().CreateModal(e);

        }
        else
            currentEvent = null;
    }

    public void Return(EventsList.Events? option)
    {
        ready = true;
        dummy.SetActive(true);
        list.completed[(int)currentEvent] = true;
        if (option == null)
            return;

        currentEvent = option;
        list.completed[(int)option] = true;
        Event e = list.events[(int)option];


        status.Add(e.people, e.resources, e.morale);
        if (e.religious == 1)
            society.AddReligious();
        else if (e.military == 1)
            society.AddMilitary();
        else if (e.mercantile == 1)
            society.AddMercantile();
    }
}
