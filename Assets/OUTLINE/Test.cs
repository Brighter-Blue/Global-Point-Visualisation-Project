using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject objectAffected;
    public GameObject playerCamera;
    public float distance;
    [SerializeField] private float size;
    public float sizeChange;

    private void Start()
    {
        size = objectAffected.GetComponent<JumpFloodOutlineRenderer>().outlinePixelWidth + sizeChange;
    }

    // Update is called once per frame
    void Update()
    {

        playerCamera = Camera.main.gameObject;
        Vector3 targetObj = objectAffected.transform.position - playerCamera.transform.position;
        float horizontal = Mathf.Sqrt((targetObj.x * targetObj.x) + (targetObj.z * targetObj.z));
        distance = Mathf.Sqrt((horizontal * horizontal) + (targetObj.y * targetObj.y));

        objectAffected.GetComponent<JumpFloodOutlineRenderer>().outlinePixelWidth = size / distance;


    }
}
