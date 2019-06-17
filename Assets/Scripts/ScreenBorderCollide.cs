using UnityEngine;
using System.Collections;

public class ScreenBorderCollide : MonoBehaviour {
	public GameObject top, bottom, left, right;

	// Use this for initialization
	void Start () {
		var dist = Camera.main.transform.position.y;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, dist, 0)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, dist, 0)).x;
		float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).z;
		float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).z;

		top.transform.position = new Vector3(0f,0f,topBorder);
		bottom.transform.position = new Vector3(0f,0f,bottomBorder);
		left.transform.position = new Vector3(leftBorder,0f,0f);
		right.transform.position = new Vector3(rightBorder,0f,0f);
	}

}
