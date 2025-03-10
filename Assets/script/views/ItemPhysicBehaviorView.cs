using System.Collections;
using UnityEngine;

public class ItemPhysicBehaviorView : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            StartCoroutine(SetItemToPickUp());
        }
    }
    IEnumerator SetItemToPickUp()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject.GetComponentInChildren<Rigidbody>());
        this.gameObject.transform.parent.gameObject.GetComponent<SphereCollider>().center = this.gameObject.transform.localPosition;
    }
}
