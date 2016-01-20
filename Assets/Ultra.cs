using UnityEngine;
using System.Collections;

public class Ultra : MonoBehaviour {
	public bool on = false;
	public Sprite[] textures;

	// Use this for initialization
	void Start () {
		Grid.ultra = this;
	}
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
            if (!Grid.targetsRolled)
            {
                on = (!on);
                if (on)
                    GetComponent<SpriteRenderer>().sprite = textures[1];
                else
                    GetComponent<SpriteRenderer>().sprite = textures[0];
                Grid.changeUltra();
            }
		}
	}
}
