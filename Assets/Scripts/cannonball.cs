using UnityEngine;
using System.Collections;

public class cannonball : MonoBehaviour {
    public float speed_y = 10f;
    public float speed_z = 1000f;
    private Rigidbody rbody;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            rbody.AddForce(0f, speed_y * 1000, speed_z * 1000);
    }
}
