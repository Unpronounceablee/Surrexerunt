using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Written by Oscar Wadmark(su16b)
    public GameObject player;
    public int cameraOffset;
    private float controlOffset;
    private float offset;
    Vector3 refer = Vector3.zero;
    private float smoothing;
    [SerializeField] private float defaultSmoothing;
    //[SerializeField] private float smootingWhileDashing;


    void Start()
    {
        smoothing = defaultSmoothing;
    }


    void Update()
    {
        RoudedOffAxis();
        MoveCamera();
        OnPlayerDash();
    }

    void MoveCamera()
    {
        offset = player.transform.position.x + controlOffset * cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(offset, transform.position.y, 
            transform.position.z), ref refer, smoothing * Time.deltaTime);
    }

    void RoudedOffAxis()
    {
        if (Input.GetAxis("Horizontal") < 0)
            controlOffset = -1;
        else if (Input.GetAxis("Horizontal") > 0)
            controlOffset = 1;
    }

    void OnPlayerDash()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Dashing)
            smoothing = defaultSmoothing * player.GetComponent<PlayerMovement>().slowTimeScale;
        else
            smoothing = defaultSmoothing;
    }
}
