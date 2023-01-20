using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLag : MonoBehaviour
{

    private Vector3 vectOffset;
    public GameObject goFollow;
    public GameObject locationAttach;
    [SerializeField] private float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        //goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(locationAttach.transform.position.x, locationAttach.transform.position.y + 1.4f, locationAttach.transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }
}
