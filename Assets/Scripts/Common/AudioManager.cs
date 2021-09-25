using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音效管理类
/// </summary>
public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    //音频开关 0关闭 1打开
    public int soundState = 0;

    public const int MusicUI = 0;
    public const int MusicGame0 = 0;


    public const int SoundButtonClick = 0;
    public const int SoundBoom = 17;
    public const int SoundSave = 2;
    public const int SoundHit0 = 3;
    public const int SoundAddGold = 4;
    public const int SoundReward = 5;
    public const int SoundHit1 = 6;
    public const int SoundGameWin = 7;
    public const int SoundGameLose = 8;
    public const int SoundReadygo = 9;

    public const int Sound10 = 10;
    public const int Sound11 = 11;
    public const int Sound12 = 12;
    public const int Sound13 = 13;
    public const int Sound14 = 14;
    public const int Sound15 = 15;
    public const int Sound16 = 16;
    public const int Sound17 = 1;
    public const int Sound18 = 18;

    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;
    public AudioClip[] audioClipsMusic;
    public AudioClip[] audioClipsOne;
    public static AudioManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(int id)
    {
        if (soundState == 0)
        {
            return;
        }
        audioSourceMusic.volume = 1;
        audioSourceMusic.clip = audioClipsMusic[id];
        audioSourceMusic.Play();
    }

    public void PlaySound(int id)
    {
        if (soundState == 0)
        {
            return;
        }
        
        audioSourceSound.PlayOneShot(audioClipsOne[id]);
    }


    public void StopMusic()
    {
        if (soundState == 0)
        {
            return;
        }
        audioSourceMusic.volume = 0;
    }

    public void RePlayMusic()
    {
        if (soundState == 0)
        {
            return;
        }
        audioSourceMusic.volume = 1;
    }

    public void SetSoundState(int _state)
    {
        soundState = _state;
        if (soundState == 0)
        {
            if (audioSourceMusic.isPlaying)
                audioSourceMusic.Stop();
        }
        else
        {
            if (audioSourceMusic.isPlaying == false)
                audioSourceMusic.Play();
        }
    }

    private void Update()
    {
        //if (GameController.GetInstance().soundState == 0)
        //{
        //    if (audioSourceMusic.isPlaying)
        //        audioSourceMusic.Stop();
        //}
        //else
        //{
        //    if (audioSourceMusic.isPlaying==false)
        //        audioSourceMusic.Play();
        //}
    }
}
