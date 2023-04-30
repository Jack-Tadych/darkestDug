using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    private List<GameObject> items;

    private void Start()
    {
        items = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Add the item to the list
            items.Add(other.gameObject);
            // Disable the item
            other.gameObject.SetActive(false);
            // Print a message
            Debug.Log("Item grabbed: " + other.gameObject.name);
        }
    }

    public int GetItemCount()
    {
        return items.Count;
    }
}
