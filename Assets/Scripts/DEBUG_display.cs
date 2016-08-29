using UnityEngine;
using System.Collections;

public class DEBUG_display : MonoBehaviour {
    float deltaTime = 0.0f;
    int w, h;

    void Start()
    {
        w = Screen.width;
        h = Screen.height;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        Draw_FPS();
        Draw_object_counts();
    }

    private void Draw_FPS()
    {
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    private void Draw_object_counts()
    {
        GUIStyle style = new GUIStyle();
        int cube_count = 0;

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
            if (go.name.Contains("cube"))
                cube_count++;

        Rect rect = new Rect(0, 20, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
        string text = "Cubes: " + cube_count.ToString();
        GUI.Label(rect, text, style);
    }
}
