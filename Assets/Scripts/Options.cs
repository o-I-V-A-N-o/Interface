using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown _difficult;
    [SerializeField] 
    private Toggle _sound;
    [SerializeField] 
    private Slider _volume;

    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        Debug.Log("Save data - difficulty: " + _difficult.value + ", sound: " + _sound.isOn + ", volume: " + _volume.value);
        PlayerPrefs.SetInt("Difficulty", _difficult.value);
        PlayerPrefs.SetInt("Sound", _sound.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", _volume.value);
    }

    private void LoadSettings()
    {
        if(PlayerPrefs.HasKey("Difficulty"))
        {
            _difficult.value = PlayerPrefs.GetInt("Difficulty");
        }
        else
        {
            _difficult.value = 0;
        }

        if (PlayerPrefs.HasKey("Sound"))
        {
            _sound.isOn = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        }
        else
        {
            _sound.isOn = true;
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            _volume.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            _volume.value = 100;
        }
    }
}
