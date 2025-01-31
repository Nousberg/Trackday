using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject trigger;
    public GameObject objs;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == trigger)
        {
            objs.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
         if (collision.gameObject == trigger)
        {
            objs.gameObject.SetActive(true);
        }
    }

}