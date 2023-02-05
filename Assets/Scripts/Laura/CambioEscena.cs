using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour
{
    public string sceneName;
    

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
