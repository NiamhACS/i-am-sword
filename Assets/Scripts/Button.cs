using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public AudioSource buttonAudio;
    public void MoveToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MoveToMenu()
    {
        Destroy(GameController.instance.gameObject);
        SceneManager.LoadScene(0);
    }

    public void PlayClickSound()
    {
        buttonAudio.Play();
    }
}
