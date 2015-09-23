using UnityEngine;
using System.Collections;

public class Search : MonoBehaviour {

	public Sprite[] dimTextures;
	public Sprite[] activeTextures;
	public bool active = false;

	// Use this for initialization
	void Start () {
		if (this.name == "search_c1_1") {
			Grid.searches [0, 0] = this;
		}
		else if (this.name == "search_c1_2") {
			Grid.searches [1, 0] = this;
		}
		else if (this.name == "search_c1_3") {
			Grid.searches [2, 0] = this;
		}
		else if (this.name == "search_c1_4") {
			Grid.searches [3, 0] = this;
		}
		else if (this.name == "search_c2_1") {
			Grid.searches [0, 1] = this;
		}
		else if (this.name == "search_c2_2") {
			Grid.searches [1, 1] = this;
		}
		else if (this.name == "search_c2_3") {
			Grid.searches [2, 1] = this;
		}
		else if (this.name == "search_c2_4") {
			Grid.searches [3, 1] = this;
		}
		else if (this.name == "search_tf_1") {
			Grid.searches [0, 2] = this;
		}
		else if (this.name == "search_tf_2") {
			Grid.searches [1, 2] = this;
		}
		else if (this.name == "search_tf_3") {
			Grid.searches [2, 2] = this;
		}
		else if (this.name == "search_tf_4") {
			Grid.searches [3, 2] = this;
		}

		Grid.loadSearchIndices ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			if (!active)
				Grid.changeSearch (this);
		}
	}

}
