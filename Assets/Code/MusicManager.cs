using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    [Range(0.0f, 1.0f)]
    public float musicVolume = 0.5f;
    public float fadeTime;
    public AudioClip[] musicClips;
    
    private GameObject reference;
    private AudioSource mPlayer1;
    private AudioSource mPlayer2;
    private float timer;
    private int lastClipID;

    private void Start()
    {
        reference = transform.GetChild(0).gameObject;
        mPlayer1 = Instantiate(reference).GetComponent<AudioSource>();
        mPlayer2 = Instantiate(reference).GetComponent<AudioSource>();
        mPlayer1.transform.SetParent(transform);
        mPlayer2.transform.SetParent(transform);
        mPlayer1.name = "Player1";
        mPlayer2.name = "Player2";
        Destroy(reference);
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            float progress = timer / fadeTime;
            mPlayer2.volume = progress * musicVolume;
            mPlayer1.volume = (1 - progress) * musicVolume;
            timer -= Time.deltaTime;
        }
        else if(mPlayer1.time > mPlayer1.clip.length - fadeTime)
        {
            Play();
        }
    }

    public void SetMusic(int musID)
    {
        Swap(ref mPlayer1, ref mPlayer2);
        mPlayer1.clip = musicClips[musID];
        mPlayer1.Play();
        timer = fadeTime;
    }

    public void Play()
    {
        int newClipID = lastClipID;
        while (newClipID == lastClipID)
        {
            newClipID = Random.RandomRange(0, musicClips.Length);
        }
        SetMusic(newClipID);
    }

    public static void Swap(ref AudioSource a, ref AudioSource b)
    {
        AudioSource c;
        c = a;
        a = b; 
        b = c;
    }
}
