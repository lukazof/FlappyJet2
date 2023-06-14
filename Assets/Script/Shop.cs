using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Plane[] planes;
    public Image planeImage;
    public Text planeName;
    public Text planeButton;

    public int index;

    public int equipedPlane;
    public static Shop instance;

    public List<int> purchasedPlanes = new List<int>();
    public string purchasedPlanesString;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        AddDefaultPlane();
    }

    private void Start()
    {

        ApplyPlane();

        string[] planesArray = PlayerPrefs.GetString("planes").Split(',');
        purchasedPlanes.Clear();
        
        foreach (string item in planesArray)
        {
            // Irá pegar os ints do array e adicioná-lo a lista
            int i;
            if (int.TryParse(item, out i))
            {
                purchasedPlanes.Add(i);
                planes[i].alreadyHave = true;
            }
        }

        
        index = equipedPlane;

    }


    // Update is called once per frame
    void Update()
    {
        planeImage.sprite = planes[index].planeSprite;
        planeName.text = planes[index].planeName;

        planeButton.text = planes[index].alreadyHave ? "Equip" : $"Buy: {planes[index].planeCost}";
    }

    public void BuyEquip()
    {
        if (planes[index].alreadyHave)
        {
            PlayerPrefs.SetInt("equipedPlane", index);
            ApplyPlane();
        }
        else
        {
            if (planes[index].planeCost <= Game.Instance.coins)
            {
                Game.Instance.coins -= planes[index].planeCost;

                PlayerPrefs.SetInt("equipedPlane", index);
                planes[index].alreadyHave = true;
                ApplyPlane();
                SavePlane();
            }
        }

        
    }

    void AddDefaultPlane()
    {
        planes[0].alreadyHave = true;
    }

    void SavePlane()
    {
        purchasedPlanes.Add(index);
        purchasedPlanesString = string.Join(",", purchasedPlanes.Select(x => x.ToString()).ToArray());
        PlayerPrefs.SetString("planes", purchasedPlanesString);
        PlayerPrefs.Save();
    }



    public void ApplyPlane()
    {
        equipedPlane = PlayerPrefs.GetInt("equipedPlane");
        Player.Instance.GetComponent<SpriteRenderer>().sprite = planes[equipedPlane].planeSprite;

    }

    public void NextPlane()
    {
        if (index < planes.Length - 1)
        {
            index++;
        }
    }

    public void PreviousPlane()
    {
        if (index > 0)
        {
            index--;
        }
    }

    [System.Serializable]
    public struct Plane
    {
        public string planeName;
        public int planeCost;
        public Sprite planeSprite;
        public bool alreadyHave;
    }
}
