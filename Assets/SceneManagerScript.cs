using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] GameObject target;

    // Start is called before the first frame update
    public void TransverseScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowObject()
    {
        if (target.activeSelf) target.SetActive(false);
        else target.SetActive(true);
    }

    public static void TransverseScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
