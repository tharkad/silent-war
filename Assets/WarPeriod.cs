using UnityEngine;
using System.Collections;

public class WarPeriod : MonoBehaviour {
	public Sprite[] textures;

	// Use this for initialization
	void Start () {
		if (this.name == "war_period_1") {
			Grid.warPeriods[0] = this;
		}
		else if (this.name == "war_period_2") {
			Grid.warPeriods[1] = this;
		}
		else if (this.name == "war_period_3") {
			Grid.warPeriods[2] = this;
		}
		else if (this.name == "war_period_4") {
			Grid.warPeriods[3] = this;
		}
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			Grid.changeWarPeriod(this);
		}
	}

}
