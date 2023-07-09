using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public AudioSource audio;
    public void MoveToScene()
    {
        
        SceneManager.LoadScene(1);
    }

    public void PlayClickSound()
    {
        audio.Play();
    }
}
