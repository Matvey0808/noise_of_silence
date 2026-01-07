using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractivePlayer : MonoBehaviour
{
    [SerializeField] private float _maxDistanceRaycast = 5f;
    private PickUpItems _currentItems;
    RaycastHit hit;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hit, _maxDistanceRaycast))
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && hit.collider.CompareTag("PickUp"))
            {
                PickUpItems pickUpItem = hit.collider.GetComponent<PickUpItems>();

                if (pickUpItem != null)
                {
                    pickUpItem.PickUp();
                    _currentItems = pickUpItem;
                }
            }
        }
        else if (Keyboard.current.qKey.wasPressedThisFrame && _currentItems != null)
        {
            _currentItems.Drop();
            _currentItems = null;
        }
    }
}
