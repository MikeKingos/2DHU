using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource s;

    public AudioClip[] audioClipArray;

    private void Awake()
    {
        s = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        s.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        s.PlayOneShot(s.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
