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
    public const int SoundClick0 = 1;
    public const int SoundClick1 = 2;
    public const int SoundClick2 = 3;
    public const int SoundMove = 4;
    public const int SoundMoveEnd = 5;
    public const int SoundGameLose = 6;
    public const int SoundGameWin = 7;

    public const int SoundMove0 = 8;
    public const int SoundMove1 = 9;
    public const int SoundMove2 = 10;
    public const int SoundMove3 = 11;
    public const int SoundMove4 = 12;
    public const int SoundMove5 = 13;
    public const int SoundMove6 = 14;

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

    public void PlaySound(int id)
    {
        if (soundState == 0)
        {
            return;
        }

        audioSourceSound.PlayOneShot(audioClipsOne[id]);
    }

    public void StopSound()
    {
        if (soundState == 0)
        {
            return;
        }

        audioSourceSound.Stop();
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
      


    public void StopMusic()
    {
        audioSourceMusic.volume = 0;
    }

    public void RePlayMusic()
    {
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
    
}
