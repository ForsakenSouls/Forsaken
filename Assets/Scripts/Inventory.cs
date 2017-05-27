using System.Collections;
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
    public GameObject potion_equipment;
	int weap_amount = 0;
	int pot_amount = 0;
    private GUIStyle guistyle = new GUIStyle();
    int[] arts = { 0, 0, 0, 0, 0, 0 }; //{stuff, teeth, healthpotion ,manapotion , , } 
                                       // Use this for initialization 
    int weap_next = 0;
    int pot_next = 0;
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
            if(potion_equipment.GetComponent<Image>().sprite == Resources.Load<Sprite>("Equip/EmptyCell"))
            {
               Potion_equip();
               pot_next++;
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
        if (Input.GetKeyUp(KeyCode.O)) //// экипировка зелий
        {
            Potion_equip();
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
            if (it.type == "Weapon")
            {
                weap_next = 0;
                weapon_equip();
				weap_amount--;
            }
            else
            {
                pot_next = 0;
                Potion_equip();
				pot_amount--;
            }
        }
        arts[it.art_code]--;
        if (list.Count == 0)
        {
            if (it.type == "Weapon")
                weapon_equip();
            else
                Potion_equip();
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
				if (item.type == "Weapon")
					weap_amount++;
				else
					pot_amount++;
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
    void Potion_equip()
    {
		if (pot_amount == 0) {
			potion_equipment.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Equip/EmptyCell");
		}
		if (pot_next >= list.Count)
            pot_next = 0;
        for (int i = pot_next; i < list.Count; i++)
        {

            Item itp = list[i];
            if (itp.type == "Potion")
            {

                potion_equipment.transform.SetParent(equip.transform.GetChild(1).transform, false);
                potion_equipment.GetComponent<Image>().sprite = Resources.Load<Sprite>(itp.sprite);
                pot_next ++;
                if (weap_next >= list.Count)
                    weap_next = 0;
                break;
            }
            else
                pot_next++;
        }
    }

    void weapon_equip()
    {
		if (weap_amount == 0) {
			weapon_equipment.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Equip/EmptyCell");
		}
        if (weap_next >= list.Count)
            weap_next = 0;
        for (int i = weap_next; i < list.Count; i++)
        {

            Item itw = list[i];
            if (itw.type == "Weapon")
            {

                weapon_equipment.transform.SetParent(equip.transform.GetChild(0).transform, false);
                weapon_equipment.GetComponent<Image>().sprite = Resources.Load<Sprite>(itw.sprite);
                weap_next ++;
                if (weap_next >= list.Count)
                    weap_next = 0;
                break;
            }
            else
                weap_next++;

        }
    }
}
