using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryscript : MonoBehaviour
{
public AudioClip musicClipOne;
public AudioSource Victorysound;
public int scoreValue;


    // Start is called before the first frame update
    void Start()
    {
            if (scoreValue == 8)
            {
                Victorysound.clip = musicClipOne;
                Victorysound.Play();
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
