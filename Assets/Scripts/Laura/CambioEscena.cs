using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string nombreScena;
    public void cambioEscena()
    {

        SceneManager.LoadScene(nombreScena);

    }
}
