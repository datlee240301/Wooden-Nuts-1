using UnityEngine;

public class HomeSceneButtonManager : MonoBehaviour {
    public GameObject soundOn, soundOff, soundIconOn, soundIconOff;
    public GameObject musicOn, musicOff, musicIconOn, musicIconOff;
    public GameObject vibrateOn, vibrateOff, vibrateIconOn, vibrateIconOff;

    // Key names for PlayerPrefs
    private const string SoundKey = "SoundState";
    private const string MusicKey = "MusicState";
    private const string VibrateKey = "VibrateState";

    private void Start() {
        LoadState();
    }

    public void SoundBtn() {
        ToggleState(soundOn, soundOff, soundIconOn, soundIconOff, SoundKey);
    }

    public void MusicBtn() {
        ToggleState(musicOn, musicOff, musicIconOn, musicIconOff, MusicKey);
    }

    public void VibrateBtn() {
        ToggleState(vibrateOn, vibrateOff, vibrateIconOn, vibrateIconOff, VibrateKey);
    }

    private void ToggleState(GameObject onObj, GameObject offObj, GameObject iconOn, GameObject iconOff, string key) {
        bool currentState = onObj.activeSelf;
        onObj.SetActive(!currentState);
        offObj.SetActive(currentState);
        iconOn.SetActive(!currentState);
        iconOff.SetActive(currentState);
        PlayerPrefs.SetInt(key, currentState ? 0 : 1);
        PlayerPrefs.Save();
    }

    private void LoadState() {
        soundOn.SetActive(PlayerPrefs.GetInt(SoundKey, 1) == 1);
        soundOff.SetActive(!soundOn.activeSelf);
        soundIconOn.SetActive(soundOn.activeSelf);
        soundIconOff.SetActive(!soundOn.activeSelf);

        musicOn.SetActive(PlayerPrefs.GetInt(MusicKey, 1) == 1);
        musicOff.SetActive(!musicOn.activeSelf);
        musicIconOn.SetActive(musicOn.activeSelf);
        musicIconOff.SetActive(!musicOn.activeSelf);

        vibrateOn.SetActive(PlayerPrefs.GetInt(VibrateKey, 1) == 1);
        vibrateOff.SetActive(!vibrateOn.activeSelf);
        vibrateIconOn.SetActive(vibrateOn.activeSelf);
        vibrateIconOff.SetActive(!vibrateOn.activeSelf);
    }
}
