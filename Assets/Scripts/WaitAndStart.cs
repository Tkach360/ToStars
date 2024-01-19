using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndStart : MonoBehaviour
{
    public Behaviour script;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            StartCoroutine(EnableScript());
        }

    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(0.3f);
        script.enabled = true;
    }
}
