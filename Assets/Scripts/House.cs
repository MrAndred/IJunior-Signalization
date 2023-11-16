using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _signalization.ChangeSafeState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cheater cheater) == true)
        {
            _signalization.ChangeSafeState(true);
        }
    }
}
