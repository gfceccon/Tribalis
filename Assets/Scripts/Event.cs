using UnityEngine;
using System.Collections;

public class Event
{
    public bool defaultImg = false;

	public Sprite image;
	public string text;

    public EventsList.Events[] requirements;
    public Option[] options;

    public int religious;
    public int mercantile;
    public int military;

    public int people;
    public int resources;
    public int morale;


    public Event(string imgPath, string text, EventsList.Events[] requirements, int reli, int merc, int mili, int ppl, int res, int mor, Option[] opt)
    {
        this.defaultImg = imgPath.Equals(EventsList.defaultImg);
		if (imgPath != null)
            this.image = Resources.Load<Sprite> ("Sprites/" + imgPath);
		this.text = text;
        this.requirements = requirements;
        this.religious = reli;
        this.mercantile = merc;
        this.military = mili;
        this.people = ppl;
        this.resources = res;
        this.morale = mor;
        this.options = opt;
	}


}
