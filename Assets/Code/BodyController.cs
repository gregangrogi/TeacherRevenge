using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    [SerializeField] private float soundEffectCoolDown = 1.3f;
    [SerializeField] private float soundEffectVolRatio = 0.1f;
    [SerializeField] private float soundEffectVolume = 0.1f;
    private float timer;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    } 
    
    public void BodyCollision(string a)
    {
        if (timer <= 0)
        {
            string[] strings = a.Split(new char[] { });
            float volume = Mathf.PI / 2 * Mathf.Atan(float.Parse(strings[0]) * soundEffectVolRatio);
            audioManager.SetVolume(0, volume * soundEffectVolume);
            //Debug.Log(strings.ToString());
            audioManager.Play(Int32.Parse(strings[1]));
            timer = soundEffectCoolDown;
        }
    }
}
