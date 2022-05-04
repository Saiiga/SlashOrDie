using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Changer : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("LVL_1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("LVL_2");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("LVL_3");
    }
    public void LVL_select()
    {
        SceneManager.LoadScene("LVL_select");
    }
}
