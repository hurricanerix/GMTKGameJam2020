using UnityEngine;

public class EnergyDrop : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void OnTriggerEnter(Collider other)
    {
        Energy oe = other.gameObject.GetComponent<Energy>();
        if (oe == null) return;

        oe.Charge(_amount);

        Destroy(gameObject);
    }

}
