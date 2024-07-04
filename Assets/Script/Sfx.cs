using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    static AudioSource AudioSource;
    public static AudioClip AudioClip;
    public static AudioClip AudioClip1;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioClip = Resources.Load<AudioClip>("Money"); //Resources 폴더 안의 "Money" 효과음을 audioClip변수에 저장
    }

    // Update is called once per frame

    public static void SoundPlayMoney()
    {
        AudioSource.PlayOneShot(AudioClip); //SoundPlay()메서드 실행시 audioClip변수에 저장된 "Money"효과음 실행
    }
}
