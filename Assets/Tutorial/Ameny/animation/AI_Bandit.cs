using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bandit : MonoBehaviour {
	private float timer;
	public GameObject Player;
	public int Damage;
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") {
			Player = col.gameObject;
			gameObject.GetComponent<Animator> ().SetBool ("Fire", true);
			transform.LookAt (col.transform.position);
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			onFire ();
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			gameObject.GetComponent<Animator> ().SetBool ("Fire", false);
		}
	}
	void onFire()
	{
		timer += 1 * Time.deltaTime;
		if (timer >= 1.2f) {
			Player.GetComponent<Health_Player> ().Health -= Damage;
			timer = 0;
		}
	}
}