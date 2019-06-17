using UnityEngine;
using System.Collections;

public class CalculateResult : MonoBehaviour {

	public GameObject[] dice;
	bool moving = true;
	bool found = false;
	int result = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!found) {
			if (moving) {
				StartCoroutine (HandleIt ());
			} else {
				foreach (GameObject die in dice) {
					result += Result(die);
				}
				Debug.Log (result);
			}
		}
	}

	private IEnumerator HandleIt()
	{
		int still = 0;
		foreach (GameObject die in dice) {
			if (die.GetComponent<Rigidbody> ().velocity == Vector3.zero)
				still ++;
		}

		if (still == dice.Length) {
			still = 0;
			yield return new WaitForSeconds(1);
			foreach (GameObject die in dice) {
				if (die.GetComponent<Rigidbody> ().velocity == Vector3.zero)
					still ++;
			}
			if(still == dice.Length)
				moving = false;

		}

		yield return null;
	}

	int Result(GameObject die){

		int r;
		Transform one = die.transform.Find ("1");
		Transform two = die.transform.Find ("2");
		Transform three = die.transform.Find ("3");
		
		if (one.transform.position.y < 0.2f) {
			if (two.transform.position.y < 0.2f) {
				if (three.transform.position.y < 0.2f)
					r = 1;
				else
					r = 0;
			} else
				r = 0;
		} else
			r = 1;	

		moving = true;
		found = true;
		return r;
	}
}
