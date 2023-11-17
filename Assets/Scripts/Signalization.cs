using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _minVolume = 0.0f;
    [SerializeField] private float _increaseVolumeSpeed = 0.1f;

    private bool _isSafe = true;

    public void ChangeSafeState()
    {
        _isSafe = !_isSafe;

        if (_isSafe == true)
        {
            StartCoroutine(SilenceHouse());
        }
        else
        {
            StartCoroutine(AlertHouse());
        }
    }

    private IEnumerator AlertHouse()
    {
        _audio.Play();

        while (_isSafe == false && _audio.volume < _maxVolume)
        {
            UpdateVolume(_maxVolume);
            yield return null;
        }
    }

    private IEnumerator SilenceHouse()
    {
        while (_isSafe == true && _audio.volume > _minVolume)
        {
            UpdateVolume(_minVolume);
            yield return null;
        }

        _audio.Stop();
    }

    private void UpdateVolume(float maxVolume)
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, maxVolume, _increaseVolumeSpeed * Time.deltaTime);
    }
}
