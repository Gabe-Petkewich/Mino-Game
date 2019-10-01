using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour {

	public float m_speed = 5;
	public float r_speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Time.deltaTime * m_speed, Space.Self);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * r_speed, 0);
	}
}
