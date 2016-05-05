using UnityEngine;
using System.Collections;

public class SpellController : MonoBehaviour {
	public GameObject spellWheelClass;

	private int currentWheelIndex = 0;
	private ArrayList wheels;

	// Use this for initialization
	void Start () {
		float spellWheelOffset = .25f;

		GameObject wheel2 = Instantiate(spellWheelClass);
		wheel2.GetComponent<SpellWheel>().spinClockwise = false;
		Vector3 initialPosition = wheel2.transform.position;
		Vector3 newPosition = new Vector3(initialPosition.x, initialPosition.y + spellWheelOffset, initialPosition.z);
		GameObject wheel1 = (GameObject)Instantiate(spellWheelClass, newPosition, wheel2.transform.rotation);
		newPosition.y = initialPosition.y - spellWheelOffset;
		GameObject wheel3 = (GameObject)Instantiate(spellWheelClass, newPosition, wheel1.transform.rotation);

		this.wheels = new ArrayList {wheel1, wheel2, wheel3};
		foreach (GameObject wheel in this.wheels) {
			wheel.transform.parent = gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject wheel in this.wheels) {
			wheel.GetComponent<SpellWheel>().setActiveState(false);
		}
		((GameObject)this.wheels[currentWheelIndex]).GetComponent<SpellWheel>().setActiveState(true);
		if (Input.GetKeyDown("space")) {
			triggerSpell();	
		}
	}

	private void triggerSpell() {
		
	}
}
