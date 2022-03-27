using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip scoreSound, gameoverSound, flySound, clickSound; //luodaan äänet
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        scoreSound = Resources.Load<AudioClip>("scoreSound"); //ladataan äänet
        gameoverSound = Resources.Load<AudioClip>("gameoverSound");
        flySound = Resources.Load<AudioClip>("flySound");
        clickSound = Resources.Load<AudioClip>("clickSound");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip) //toistetaan äänet
    {
        switch (clip)
        {
            case "score":
                audioSrc.PlayOneShot(scoreSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameoverSound);
                break;
            case "fly":
                audioSrc.PlayOneShot(flySound);
                break;
            case "click":
                audioSrc.PlayOneShot(clickSound);
                break;
        }
    }
}
