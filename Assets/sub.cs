using UnityEngine;
using System.Collections;

public class sub : MonoBehaviour {
    public bool on = false;
    public Sprite[] textures;

    // Use this for initialization
    void Start () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            on = (!on);
            if (on)
                GetComponent<SpriteRenderer>().sprite = textures[1];
            else
                GetComponent<SpriteRenderer>().sprite = textures[0];
        }
    }
}
