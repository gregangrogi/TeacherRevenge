using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject reference;
    public AudioPlayer[] audioPlayers;

    [System.Serializable]
    public class AudioPlayer
    {
        public string name;
        public AudioClip clip;
        public AudioSource audioSource;
        [Range(0.0f, 1.0f)]
        public float volume = 0.5f;
        
        public void Play()
        {
            audioSource.pitch = 1 + ((float)Random.RandomRange(-30, 30) / 300);
            audioSource.Play();
        }
    }

    private void Start()
    {
        reference = transform.GetChild(0).gameObject;
        for (int i = 0; i < audioPlayers.Length; i++)
        {
            audioPlayers[i].audioSource = Instantiate(reference).GetComponent<AudioSource>();
            audioPlayers[i].audioSource.clip = audioPlayers[i].clip;
            audioPlayers[i].audioSource.volume = audioPlayers[i].volume;
            audioPlayers[i].audioSource.gameObject.name = audioPlayers[i].name;
            audioPlayers[i].audioSource.gameObject.transform.parent = transform;
        }
        Destroy(reference);
    }
    public void Play(int audioID)
    {
        audioPlayers[audioID].Play();
    }
    public void SetVolume(int audioID, float volume)
    {
        audioPlayers[audioID].volume = volume;
        audioPlayers[audioID].audioSource.volume = volume;
    }
}
