using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //Written by Oscar Wadmark(su16b) and Pontus Mattsson(Su16B)
    public GameObject player;
    private float cameraOffset;
    public float controlOffset;
    private float offset;
    Vector3 refer = Vector3.zero;
    public float smoothing;
    [SerializeField] public float defaultSmoothing;
    [SerializeField] private float smootingReturn;
    private bool aiming;
    [SerializeField] float shakeAmmount;
    [SerializeField] private float maxAimDur;
    private float aimTimePassed;
    private bool runOnce;


    //[SerializeField] private float smootingWhileDashing;


    void Start()
    {
        smoothing = defaultSmoothing;
        runOnce = true;
    }


    void Update()
    {

        WhenToSmoth();
        RoudedOffAxis();
        MoveCamera();
        OnPlayerDashAim();
        print(aimTimePassed);
    }

    void MoveCamera()
    {
        offset = player.transform.position.x + controlOffset + cameraOffset;
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
            smoothing = smoothing / (defaultSmoothing / 10);
        }



    }

    void OnPlayerDash()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Dashing)
            smoothing = defaultSmoothing * player.GetComponent<PlayerMovement>().slowTimeScale;
        else
            smoothing = defaultSmoothing;
    }

    void OnPlayerDashAim()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Aiming)
        {
            aiming = true;
            if (runOnce)
            {
                StartCoroutine(CameraShake());

            }
        }
        else
        {
            cameraOffset = 0;
            aiming = false;
        }

    }

    void Restart()
    {
        if (Input.GetButton("Back"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private IEnumerator CameraShake()
    {
        runOnce = false;
        while (aiming)
        {
            aimTimePassed += Time.deltaTime * 10;
            cameraOffset = (Random.Range(-1, 1) * (aimTimePassed) * shakeAmmount / (maxAimDur * 10));

            if (aimTimePassed >= maxAimDur)
            {
                Knockback();
            }

            yield return false;
        }
        aimTimePassed = 0;
        runOnce = true;

    }

    private void Knockback()
    {
        player.GetComponent<PlayerMovement>().dashState = PlayerMovement.DashState.Knockback;


    }
}
