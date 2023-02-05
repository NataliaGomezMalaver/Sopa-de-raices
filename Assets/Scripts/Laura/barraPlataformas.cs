using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class barraPlataformas : MonoBehaviour
{
    // Start is called before the first frame update
    public Image barraVeg;
    public GameObject plataformas;

    private void Update()
    {
        if (barraVeg.fillAmount == 1) {
            plataformas.gameObject.SetActive(true);

        }
    }
}
