using UnityEngine;
using UnityEngine.SceneManagement;
//Sebastian Olsson SU16b
public class LoadScene : MonoBehaviour {
    void Start()
    {


    }
    public void LoadOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}