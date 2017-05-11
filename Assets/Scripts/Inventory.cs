using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{

    List<Item> list;
    public GameObject inventory;
    public GameObject container;

    // Use this for initialization

    void Start()
    {
        list = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (list.Count != 16 && !inventory.activeSelf)
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero);

                Item item;
                if (hit.collider != null)
                {
                    item = hit.collider.GetComponent<Item>();
                    if (item != null)
                    {

                        list.Add(item);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);

                for (int i = 0; i < inventory.transform.childCount; i++)
                {
                    if (inventory.transform.GetChild(i).transform.childCount > 0)
                    {
                        Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
                    }
                }
            }
            else
            {
                inventory.SetActive(true);
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    Item it = list[i];
                    if (inventory.transform.childCount >= i)
                    {
                        GameObject img = Instantiate(container);
                        img.transform.SetParent(inventory.transform.GetChild(i).transform, false);
                        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
                        img.AddComponent<Button>().onClick.AddListener(() => remove(it, img));
                    }
                    else
                        break;
                }
                inventory.SetActive(false);
                inventory.SetActive(true);
            }
        }

    }


    void remove(Item it, GameObject obj)
    {
        GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));
        newo.transform.position = transform.position + 3 * transform.right;
        Destroy(obj);
        list.Remove(it);
    }
}