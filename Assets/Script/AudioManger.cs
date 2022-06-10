using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManger : MonoBehaviour
{
    public Sprite SoundOnImage;
    public Sprite MuteImage;
    public Button button;
    bool SoundIsOn = true;
    public AudioSource Audio;

    void Start()
    {
        SoundOnImage = button.image.sprite;
    }

    public void OnButtonClicked()
    {
        if (SoundIsOn)
        {
            SoundIsOn = false;
            button.image.sprite = MuteImage;
            Audio.mute = true;
        }
        else
        {
            SoundIsOn = true;
            button.image.sprite = SoundOnImage;
            Audio.mute = false;
        }
    }
}
