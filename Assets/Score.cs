using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public GameObject player;

	void Start()
     {
		var parent = transform.parent;
 
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;
 
        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;

		Player score = player.GetComponent<Player>();

        text.text = string.Format("{0}, {1}", "Score: ",score.score);
     }
	// Update is called once per frame
	void Update () {
		
        var parent = transform.parent;
 
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;
 
        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;

		Player score = player.GetComponent<Player>();

        text.text = string.Format("{0}", "Wins: " + score.score);
	}
}
