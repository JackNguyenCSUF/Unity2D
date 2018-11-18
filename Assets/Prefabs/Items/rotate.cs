using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public GameObject item;
	public float rotationSpeed = 5;
	private float x;
	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x += 1;
			Quaternion target = Quaternion.Euler(0, 0, x);

        	// Dampen towards the target rotation
        	//transform.rotation = Quaternion.Slerp(transform.rotation, target,  700f);
			//transform.Rotate(Vector3.right, 90 * Time.deltaTime * rotationSpeed);
			transform.Rotate (new Vector3 (0, 0, 10) * Time.deltaTime * rotationSpeed);

			SpriteRenderer component = item.GetComponent<SpriteRenderer>();

			Color newColor;

   			newColor.r = 0;
   			newColor.g = Random.Range(0.00f,1.00f);
   			newColor.b = Random.Range(0.00f,1.00f);
   			newColor.a = 0.3f;

   			component.color = newColor;
	}
}
