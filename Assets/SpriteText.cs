using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteText : MonoBehaviour {

	public GameObject player;

	void Start()
     {
		weapon playerWeapon = player.GetComponent<weapon>();
	
        var parent = transform.parent;
 
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;
 
        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;
        text.text = string.Format("{0}, {1}", "X",playerWeapon.numberMines);
     }
	// Update is called once per frame
	void Update () {
		weapon playerWeapon = player.GetComponent<weapon>();
	
        var parent = transform.parent;
 
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;
 
        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;
        text.text = string.Format("{0}",playerWeapon.numberMines);
	}
}
