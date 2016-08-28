using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class explosion : MonoBehaviour {
    public float force = 100f;
    public float max_force_distance = 250f;
    List<GameObject> m_cubes = new List<GameObject>();
    GameObject m_bomb;
    int m_i = 0;
	// Use this for initialization
	void Start () {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if(go.name.Contains("Cube"))
            {
                m_cubes.Add(go);
            }

            if (go.name.Contains("bomb"))
                m_bomb = go;
        }

        print("found " + m_cubes.Count.ToString() + " cubes");
    }
	
	// Update is called once per frame
	void Update () {
        m_i = (m_i + 1) % 10;

        if (m_i == 0)
        {
            GameObject cube = (GameObject)Instantiate(Resources.Load("cube"), new Vector3(0f, 6f, 0f), Quaternion.identity);
            cube.name = "cube_" + m_cubes.Count.ToString();
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            //APPLY EXPLOSION TO CUBE
            rb.AddForce(0f, 1000f, 0f);
            m_cubes.Add(cube);
        }

        m_bomb.transform.Rotate(0f, 10f, 0f);
        if (Input.GetKeyDown("space"))
        {
            for (int i = 0; i < m_cubes.Count; i++)
            {
                var heading = m_cubes[i].transform.position - m_bomb.transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;

                float explosive_multiplier = max_force_distance - distance;
                if (explosive_multiplier < 0f)
                    explosive_multiplier = 0f;

                Rigidbody rb = m_cubes[i].GetComponent<Rigidbody>();
                //APPLY EXPLOSION TO CUBE
                rb.AddForce(direction * explosive_multiplier * force);
            }
        }
    }
}
