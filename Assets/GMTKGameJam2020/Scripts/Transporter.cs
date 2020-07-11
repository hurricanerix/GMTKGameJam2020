using UnityEngine;

public class Transporter : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "MainCamera")
        {
            return;
        }
        Debug.Log("Transport");
    }
}
