using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Camera2;
    // Start is called before the first frame update
    void Start()
    {
        Camera.SetActive(true);
        Camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Camera.SetActive(true);
            Camera2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}
