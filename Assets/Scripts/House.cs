using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField]private UnityEvent _onSafetyChange = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _onSafetyChange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _onSafetyChange?.Invoke();
        }
    }
}
