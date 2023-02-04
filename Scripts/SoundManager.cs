using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource src;
    [SerializeField] public AudioSource src2;

    public AudioClip blip;
    public AudioClip endMusic;
    public AudioClip mainMusic;
    public AudioClip deathMusic;
    public AudioClip scoreCarrot;
    public AudioClip rabbitDie;
    public AudioClip foxGrowl;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound(int clipNum)
        //1 is pulling carrot noise
        //9 is main music
        //10 is death music
    {
        
        //src.clip = blip;
        //src.Play();

        switch (clipNum)
        {
            case 1:
                src.clip = blip;
                src.Play();

                break;
            case 2:
                src.clip = scoreCarrot;
                src.Play();
                

                break;
            case 9:

                src2.clip = mainMusic;
                src2.Play();
                src2.loop = true;

                break;

            case 10:

                src2.clip = deathMusic;
                src2.Play();
                src2.loop = false;

                break;

            case 11:

                src2.clip = endMusic;
                src2.Play();
                src2.loop = false;

                break;

            default:
                // code block
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
