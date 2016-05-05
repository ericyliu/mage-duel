using UnityEngine;
using System.Collections;

public class SpellWheelText {
	private GameObject textObject;
	private bool isHighlighted;
	private string spellText;
	public SpellWheelText(GameObject textObject) {
		this.textObject = textObject;
	}

	public void setSpellText(string spellText) {
		this.textObject.GetComponent<TextMesh>().text = spellText;
	}

	public void setHighlighted(bool isHighlighted) {
		this.isHighlighted = isHighlighted;
		if (isHighlighted) {
			this.textObject.GetComponent<TextMesh>().color = Color.black;
		} else {
			this.textObject.GetComponent<TextMesh>().color = Color.red;
		}
	}
}
