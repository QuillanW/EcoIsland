using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopMenu : MonoBehaviour
{
    bool menuActive = false;

    public RectTransform buildingsItems;
    public RectTransform collectorsItems;
    public RectTransform greeneryItems;

    public GameObject ShopItemUIPrefab;
    public List<Item> items = new();

    public static ShopMenu instance;

    private void Start()
    {
        instance = this;

        transform.position = new Vector3(25, -500, 0);

        int b = 0;
        int c = 0;
        int g = 0;

        foreach (Item item in items)
        {
            RectTransform itemsParent = buildingsItems;

            switch(item.category)
            {
                case ShopCategories.buildings:
                    InstantiateItemUI(b, item, buildingsItems);
                    b++;
                    break;
                case ShopCategories.collectors:
                    InstantiateItemUI(c, item, collectorsItems);
                    c++;
                    break;
                case ShopCategories.greenery:
                    InstantiateItemUI(g, item, greeneryItems);
                    g++;
                    break;
            }
        }
    }

    private void InstantiateItemUI(int index, Item item, Transform parent)
    {
        GameObject newItem = Instantiate(ShopItemUIPrefab, parent);
        newItem.GetComponent<ShopItem>().Setup(item);
        newItem.transform.localPosition = new Vector2(0, index * -100);
    }

    public void ToggleMenu()
    {
        if (menuActive)
        {
            transform.localPosition = new Vector3(20, -500, 0);
        }
        else
        {
            transform.localPosition = new Vector3(25, 25, 0);
        }
        menuActive = !menuActive;
    }

    public void MenuVisibility(bool visible)
    {
        if (visible)
        {
            transform.localPosition = transform.localPosition = new Vector3(20, -500, 0);
            return;
        }
        transform.localPosition = new Vector3(-1000, -1000);

    }
}

public enum ShopCategories
{
    buildings,
    collectors,
    greenery
}

[Serializable]
public class Item
{
    public string name;
    public int price;
    public int level;
    public GameObject prefab;
    public ShopCategories category;

    public Item(string name, int price, int level, GameObject prefab, ShopCategories category)
    {
        this.name = name;
        this.price = price;
        this.level = level;
        this.prefab = prefab;
        this.category = category;
    }

    public Item()
    {
        name = "";
    }
}