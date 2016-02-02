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
    public GameMusic music;
    public float delayTime = 2f;
    public float visibleTime = 0.2f;
    [Header("Music Presets")]
    public MusicPreset mercantile;
    public MusicPreset military;
    public MusicPreset religious;
    public MusicPreset mercantileMilitary;
    public MusicPreset militaryReligious;
    public MusicPreset mercantileReligious;

    [HideInInspector]
    public EventsList list;
    private EventsList.Events currentEvent;
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
            immediate = false;
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
        if(!ok)
        {
            if (society.Mercantile == society.Military)
            {
                if (society.Religious > society.Mercantile)
                    currentEvent = EventsList.Events.GoodEndReli;
                else
                    currentEvent = society.path[society.keyDecisionCount - 1] == Society.StyleChoices.Mercantile ? EventsList.Events.GoodEndMerc : EventsList.Events.GoodEndMili;
                ok = true;
            }
            if (society.Military == society.Religious)
            {
                if (society.Mercantile > society.Military)
                    currentEvent = EventsList.Events.GoodEndMerc;
                else
                    currentEvent = society.path[society.keyDecisionCount - 1] == Society.StyleChoices.Military ? EventsList.Events.GoodEndMili : EventsList.Events.GoodEndMerc;
                ok = true;
            }
            if (society.Mercantile == society.Religious)
            {
                if (society.Military > society.Mercantile)
                    currentEvent = EventsList.Events.GoodEndMili;
                else
                    currentEvent = society.path[society.keyDecisionCount - 1] == Society.StyleChoices.Religious ? EventsList.Events.GoodEndReli : EventsList.Events.GoodEndMerc;
                ok = true;
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
                dummy.GetComponent<Image>().enabled = true;
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
            dummy.GetComponent<Image>().enabled = false;

            GameObject modal = Instantiate<GameObject>(modalPrefab);
            modal.transform.SetParent(transform);
            modal.GetComponent<Modal>().CreateModal(e);

        }
        else
            currentEvent = EventsList.Events.None;
    }

    public void Return(EventsList.Events option)
    {
        if (option == EventsList.Events.Lose)
        {
            Lose();
            return;
        }
        else if (option == EventsList.Events.Win)
        {
            Win();
            return;
        }

        ready = true;
        dummy.SetActive(true);
        list.completed[(int)currentEvent] = true;

        Event e = list.events[(int)currentEvent];
        status.Add(e.people, e.resources, e.morale);
        if (e.mercantile == 1)
            society.AddMercantile();
        else if (e.military == 1)
            society.AddMilitary();
        else if (e.religious == 1)
            society.AddReligious();

        if (society.Mercantile > 0)
        {
            if (society.Military > 0)
                mercantileMilitary.Set();
            else if (society.Religious > 0)
                mercantileReligious.Set();
            else
                mercantile.Set();
        }
        else if (society.Military > 0)
        {
            if (society.Religious > 0)
                militaryReligious.Set();
            else
                military.Set();
        }
        else if (society.Religious > 0)
            religious.Set();

        if (option != EventsList.Events.None)
        {

            currentEvent = option;
            immediate = true;
            list.completed[(int)option] = true;
        }
        else if (status.People == 0)
        {
            currentEvent = EventsList.Events.BadEndPess;
            immediate = true;
        }
        else if (status.Resources == 0)
        {
            currentEvent = EventsList.Events.BadEndRecu;
            immediate = true;
        }
        else if (status.Morale == 0)
        {
            currentEvent = EventsList.Events.BadEndMora;
            immediate = true;
        } 
    }

    private void Win()
    {
        Application.Quit();
        music.Stop();
    }

    private void Lose()
    {
        Application.Quit();
        music.Stop();
    }
}
