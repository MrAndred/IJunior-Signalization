using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _increaseVolumeSpeed = 0.1f;

    private bool _isSafe = true;

    private IEnumerator AlertCheater()
    {
        while (true)
        {
            if (_isSafe == false)
            {
                _signalization.volume = Mathf.MoveTowards(_signalization.volume, _maxVolume, _increaseVolumeSpeed * Time.deltaTime);
            }
            else
            {
                _signalization.volume = Mathf.MoveTowards(_signalization.volume, _maxVolume, -_increaseVolumeSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void Start()
    {
        _signalization.volume = 0.0f;
        StartCoroutine(AlertCheater());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _isSafe = false;
            Debug.Log("Cheater is not allowed in the house!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");

        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _isSafe = true;
            Debug.Log("Cheater is allowed in the house again!");
        }
    }
}
