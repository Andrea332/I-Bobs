using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public UnityEvent onGameOver;
    public AudioSource OST;
    public void GameOverStop()
    {
        onGameOver?.Invoke();
        OST.Stop();
    }


}
