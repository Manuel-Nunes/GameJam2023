using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagementController : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Load Scene?");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
