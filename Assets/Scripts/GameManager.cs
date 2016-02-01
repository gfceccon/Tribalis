using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Sprite backgroundImg;
	public Log log;
	public StatusPanel statusPanel;

	public GameObject logEntryPrefab;
	public EventsList.Events[] pastEvents;
	public EventsList allEvents;
	private int eventCount = 0;




	void Start(){
		allEvents = new EventsList ();
		eventCount = 0;
	}

	void Update (){
		if ( pastEvents.Length != eventCount ){
			//atualiza o log
//
//
////			Vector2 offset = log.GetComponent<RectTransform>().offsetMax;
////			offset.y = 600;
////			log.GetComponent<RectTransform> ().offsetMin = offset;
//
//			//log.GetComponent<RectTransform> ().rect.height = 100;
//			Rect rect = new Rect (log.GetComponent<RectTransform> ().rect);
//			rect.height = 100;
//			log.GetComponent<RectTransform> ().rect.Set (rect.x, rect.y, rect.width, 100.0f);
//			Debug.Log("Atualiza log " + rect.height +" -> " +  log.GetComponent<RectTransform> ().rect.height);


			//Registra novas entradas de eventos no log
			while (eventCount < pastEvents.Length) {
				GameObject logEvent = Instantiate (logEntryPrefab, Vector3.zero, Quaternion.identity) as GameObject;
				logEvent.GetComponent<RectTransform>().position = new Vector3 (0, 100 * eventCount, 0);
				logEvent.transform.SetParent (log.transform);
//				logEvent.transform.localPosition = new Vector3 (0, 100 * eventCount - 248, 0);

				//int index = (int)pastEvents [eventCount];
				//logEvent.transform.GetChild(0).FindChild("Image").gameObject.GetComponent<Image> ().sprite = allEvents.events [index].eventImage;


				//logEvent.transform.GetChild(0).GetComponentInChildren<Image> ().sprite = allEvents.events [index].eventImage;
				//logEvent.GetComponentInChildren<Text> ().text = allEvents.events [index].eventText;

//				logEvent.image.sprite = allEvents.events [index].eventImage;
//				logEvent.text.text = allEvents.events [index].eventText;


				eventCount++;
				Debug.Log (eventCount);
			}


			// Calcula redimensionamento do log
			float height;
			if (pastEvents.Length > 6) {
				height = 100 * pastEvents.Length;
			} else {
				height = 600;
			}

			//Redimensiona o canvas do log
			log.GetComponent<RectTransform> ().sizeDelta = new Vector2 (log.GetComponent<RectTransform> ().sizeDelta.x, height);
			//Rola o Scroll para a última mensagem
			log.transform.parent.parent.FindChild ("Scrollbar Vertical").GetComponent<Scrollbar> ().value = 0;

			//eventCount = pastEvents.Length;

		}
	}
}
