using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public Camera cam;
    private float _speed = 800f;
    private float _height = 200f;

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                StartCoroutine(MovableObject(hit.transform));
            }
        }
    }

    IEnumerator MovableObject(Transform obj)
    {
        yield return obj;
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * _speed, ForceMode.Force);
        obj.GetComponent<Rigidbody>().AddForce(transform.up * _height, ForceMode.Force);
    }
}
