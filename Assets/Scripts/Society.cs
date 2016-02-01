using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Society : MonoBehaviour
{

    public enum StyleChoices
    {
        Religious,
        Mercantile,
        Military
    };
    //	[SerializeField]
    //	private int peopleVariation;
    //	[SerializeField]
    //	private int resourcesVariation;
    //	[SerializeField]
    //	private int moraleVariation;

    private int religious;
    private int mercantile;
    private int military;

    public int keyDecisionCount = 0;
    public StyleChoices[] path = new StyleChoices[4];
    //public Sprite[] roomObjects = new Sprite[4];
    public Sprite[] allRoomObjects = new Sprite[12];
    public GameObject[] roomObjects = new GameObject[4];

    public StatusPanel statusPanel;

    // Aspectos culturais
    public void AddReligious()
    {
        religious += 1;
        path[keyDecisionCount] = StyleChoices.Religious;
        roomObjects[keyDecisionCount].SetActive(true);
        roomObjects[keyDecisionCount].GetComponent<Image>().sprite = allRoomObjects[keyDecisionCount * 3 + (int)StyleChoices.Religious];
        keyDecisionCount++;

    }
    public void AddMercantile()
    {
        mercantile += 1;
        path[keyDecisionCount] = StyleChoices.Mercantile;
        roomObjects[keyDecisionCount].SetActive(true);
        roomObjects[keyDecisionCount].GetComponent<Image>().sprite = allRoomObjects[keyDecisionCount * 3 + (int)StyleChoices.Mercantile];
        keyDecisionCount++;
    }
    public void AddMilitary()
    {
        military += 1;
        path[keyDecisionCount] = StyleChoices.Religious;
        roomObjects[keyDecisionCount].SetActive(true);
        roomObjects[keyDecisionCount].GetComponent<Image>().sprite = allRoomObjects[keyDecisionCount * 3 + (int)StyleChoices.Military];
        keyDecisionCount++;
    }



}
