using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySounf : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(PlaySoundOnClick);
    }

    public void PlaySoundOnClick()
    {
        audioSource.Play();
    }
}
