using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class regame : MonoBehaviour
{
    public void Regame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
