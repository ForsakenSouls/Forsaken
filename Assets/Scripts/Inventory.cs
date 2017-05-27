﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{

    public List<Item> list;
    public GameObject inventory;
    public GameObject equip;
    public GameObject container;
    public GameObject info;
    public GameObject weapon_equipment;
    private GUIStyle guistyle = new GUIStyle();
    string current_am = "";
    int[] arts = { 0, 0, 0, 0, 0, 0 }; //{stuff, teeth, , , , } 
                                       // Use this for initialization 
    int weap_next = 0;
    void Start()
    {
        list = new List<Item>();
    }

    // Update is called once per frame 
    void OnGUI()
    {
        if (info.activeSelf)
        {
            guistyle.fontSize = 16;
            GUI.Label(new Rect(530, 53, 150, 200), GameState.Player.ToString(), guistyle);
        }

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !inventory.activeSelf) //// поднять артефакт 
        {
            GetDrop();
            if (weapon_equipment.GetComponent<Image>().sprite == Resources.Load<Sprite>("Equip/EmptyCell"))
            {
                weapon_equip();
                weap_next++;
            }
        }
        if (Input.GetKeyUp(KeyCode.I)) //// активация(и вместе с тем заполнение) инвентаря 
            LayArts();

        if (Input.GetKeyUp(KeyCode.L)) //// информация о персонаже 
        {
            if (info.activeSelf)
                info.SetActive(false);
            else
                info.SetActive(true);
        }


        if (Input.GetKeyUp(KeyCode.P)) //// экипировка оружия 
        {
            weapon_equip();
        }

    }

    void remove(Item it, GameObject obj)
    {
        GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));
        newo.transform.position = transform.position - 3 * transform.right;
        if (arts[it.art_code] == 1)
        {
            Destroy(obj);
            if ((weap_next != 0 && it == list[weap_next - 1]) || list.Count == 1)
            {
                // weap_next = 0; 
                // weapon_equip(); 
            }
            list.Remove(it);
            weap_next = 0;
            weapon_equip();

        }
        arts[it.art_code]--;
        if (list.Count == 0)
            weapon_equip();
    }
    void weapon_equip()
    {

        weapon_equipment.GetComponent<Image>().sprite = Resources.Load<Sprite>("Equip/EmptyCell");

        for (int i = weap_next; i < list.Count; i++)
        {

            Item itw = list[i];
            if (itw.type == "Weapon")
            {

                weapon_equipment.transform.SetParent(equip.transform.GetChild(0).transform, false);
                weapon_equipment.GetComponent<Image>().sprite = Resources.Load<Sprite>(itw.sprite);
                weap_next = i + 1;
                if (weap_next == list.Count)
                {
                    weap_next = 0;
                }
                break;
            }
        }
    }
    void GetDrop()
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
                    if (arts[item.art_code] == 0)
                        list.Add(item);

                    arts[item.art_code]++;

                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    void LayArts()
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

        //// активация инвентаря 
        // if (Input.GetKeyUp(KeyCode.L)) 
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
