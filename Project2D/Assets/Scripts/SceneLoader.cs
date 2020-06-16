using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene0()
    {
        SceneManager.LoadScene(0);
    }
}
