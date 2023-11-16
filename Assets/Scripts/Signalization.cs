using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _increaseVolumeSpeed = 0.1f;

    private bool _isSafe = true;

    public Signalization(AudioSource audio, float maxVolume, float increaseVolumeSpeed)
    {
        _audio = audio;
        _maxVolume = maxVolume;
        _increaseVolumeSpeed = increaseVolumeSpeed;
    }

    public void ChangeSafeState(bool isSafe)
    {
        _isSafe = isSafe;

        if (_isSafe == true)
        {
            StartCoroutine(SilenceHouse());
        }
        else
        {
            StartCoroutine(AlertHouse());
        }
    }

    public IEnumerator AlertHouse()
    {
        _audio.Play();

        while (_isSafe == false && _audio.volume < 1f)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _increaseVolumeSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public IEnumerator SilenceHouse()
    {
        while (_isSafe == true && _audio.volume > 0.0f)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0.0f, _increaseVolumeSpeed * Time.deltaTime);

            yield return null;
        }

        _audio.Stop();
    }
}
