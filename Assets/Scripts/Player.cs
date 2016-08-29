using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Rigidbody m_rbody;
    private GameObject m_camera;
    public float force = 10;
    // Use this for initialization
    void Start () {
        m_rbody = GetComponent<Rigidbody>();
        m_camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        //GET JOYSTICK IMPUT AND APPLY MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        m_rbody.AddForce(new Vector3(x * force, 0.0f, z * force));

        //MOVE CAMERA ALONG WITH PLAYER
        m_camera.transform.position = new Vector3(m_rbody.transform.position.x, m_rbody.transform.position.y + 2, m_rbody.transform.position.z - 9f);

    }
}
