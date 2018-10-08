using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Written by Oscar Wadmark(su16b)
    public GameObject player;
    private Vector3 offset;
    private float x;
    Vector3 refer = Vector3.zero;
    [SerializeField] private float camera;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void Update()
    {
        x = player.transform.position.x;
        print("asd");
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x,transform.position.y,transform.position.z) - new Vector3(0,0, 10)   , ref refer, camera);
    }
}
