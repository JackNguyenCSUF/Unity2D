using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        CenterCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject cam = GameObject.Find("MainCamera");
        //Debug.Log(cam.transform.rotation);
        //cam.transform.position(0,0,0);
    }

    void CenterCamera()
    {
        //make camera center on the generated level
        GameObject level = GameObject.Find("Level");
        if (level != null)
        {
            int x = level.GetComponent<LevelGen>().xsize;
            int y = level.GetComponent<LevelGen>().ysize;
            Camera.main.transform.position = new Vector3(x - 0.5f, y - 0.5f, -10.0f);
        }
        
    }
}
