using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusPanel : MonoBehaviour
{
    public Slider people;
    public Slider resources;
    public Slider morale;

    public int People
    {
        get
        {
            return (int)people.value;
        }
    }
    public int Resources
    {
        get
        {
            return (int)resources.value;
        }
    }
    public int Morale
    {
        get
        {
            return (int)morale.value;
        }
    }

    public void Add(int people, int resources, int morale)
    {
        if (people < 0 && -people > this.people.value)
            this.people.value = 0;
        else if (people > 0 && people + this.people.value > this.people.maxValue)
            this.people.value = this.people.maxValue;
        else
            this.people.value += people;

        if (resources < 0 && -resources > this.resources.value)
            this.resources.value = 0;
        else if (resources > 0 && resources + this.resources.value > this.resources.maxValue)
            this.resources.value = this.resources.maxValue;
        else
            this.resources.value += resources;

        if (morale < 0 && -morale > this.morale.value)
            this.morale.value = 0;
        else if (morale > 0 && morale + this.morale.value > this.morale.maxValue)
            this.morale.value = this.morale.maxValue;
        else
            this.morale.value += people;
    }
}
