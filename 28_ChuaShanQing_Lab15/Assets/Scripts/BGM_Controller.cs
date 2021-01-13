﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Controller : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;
    private float volumeChangeSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audioSource.Stop();
            int rand = Random.Range(0, AudioClipBGMArr.Length);
            audioSource.PlayOneShot(AudioClipBGMArr[rand]);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.volume += Time.deltaTime * volumeChangeSpeed;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.volume -= Time.deltaTime * volumeChangeSpeed;
        }
    }

}
