using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //Written by Oscar Wadmark(su16b)
    public GameObject player;
    public int cameraOffset;
    private float controlOffset;
    private float offset;
    Vector3 refer = Vector3.zero;
    public float smoothing;
    [SerializeField] private float defaultSmoothing;
    [SerializeField] private float smootingReturn;

    //[SerializeField] private float smootingWhileDashing;


    void Start()
    {
        smoothing = defaultSmoothing;
    }


    void Update()
    {
        WhenToSmoth();
        RoudedOffAxis();
        MoveCamera();
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

    void WhenToSmoth()
    {
        if (controlOffset < 0 && Input.GetAxis("Horizontal") > 0)
        {
            smoothing = defaultSmoothing;
        }
        else if (controlOffset > 0 && Input.GetAxis("Horizontal") < 0)
        {
            smoothing = defaultSmoothing;
        }
        else if (smoothing > 1)
        {
            smoothing = smoothing / smootingReturn;
        }

    }

    void OnPlayerDash()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Dashing)
            smoothing = defaultSmoothing * player.GetComponent<PlayerMovement>().slowTimeScale;
        else
            smoothing = defaultSmoothing;
    }

    void Restart()
    {
        if (Input.GetButton("Back"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
