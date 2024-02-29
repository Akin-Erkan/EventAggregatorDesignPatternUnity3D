using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public Slider masterAudioSlider;
    public Slider voiceAudioSlider;
    
    private void Awake()
    {
        masterAudioSlider.onValueChanged.AddListener(OnMasterAudioVolumeChange);
        voiceAudioSlider.onValueChanged.AddListener(OnVoiceAudioVolumeChange);
    }
    
    private void OnMasterAudioVolumeChange(float arg0)
    {
        EventAggregator.Instance.Publish(new SoundUIMessage(this));
    }
    
    private void OnVoiceAudioVolumeChange(float arg0)
    {
        EventAggregator.Instance.Publish(new SoundUIMessage(this));
    }
}

public class SoundUIMessage
{
    public SoundUIController senderSoundUIController;

    public SoundUIMessage(SoundUIController soundUIController)
    {
        senderSoundUIController = soundUIController;
    }
}
