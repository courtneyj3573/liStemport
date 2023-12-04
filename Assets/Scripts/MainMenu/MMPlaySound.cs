using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMPlaySound : MonoBehaviour
{
    public AudioSource soundPlayer;
    public void playThisSoundEffect()
    {
        soundPlayer.Play(); 
    }

}
