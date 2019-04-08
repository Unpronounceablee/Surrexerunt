using UnityEngine;
using UnityEngine.SceneManagement;
//Sebastian Olsson SU16b
public class LoadScene : MonoBehaviour {

    public void LoadOnClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}