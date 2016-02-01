using UnityEngine;
using System.Collections;

public class Option {

	public string optionText;
	public EventsList.Events consequence;

	public Option(string optionText, EventsList.Events consequence){
		this.optionText = optionText;
		this.consequence = consequence;
	}
}
