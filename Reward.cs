using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour {

    //public int Gold;
    public int Expirience;
    public int sphereRed;
    public int sphereBlue;
    public int sphereGreen;
    public int spherePurple;
    //public int Souls;
    public List<Item> items;

    public Reward() {
        Expirience = 0;
        sphereRed = 0;
        sphereBlue = 0;
        sphereGreen = 0;
        spherePurple = 0;
        items = new List<Item>();
    }
    public Reward(int exp, int sphRed, int sphBlue, int sphGreen, int sphPurple, params Item[] _items/*List<Item> _items, Card crd*/)
    {
        Expirience = exp;
        sphereRed = sphRed;
        sphereBlue = sphBlue;
        sphereGreen = sphGreen;
        spherePurple = sphPurple;
        items = new List<Item>();
        for (int i = 0; i < _items.Length; i++)
        {
            items.Add(_items[i]);
        }
    }
    public Reward(int exp, int countOfShperes, int countOfRandomSpheres, params Item[] _items /*,Card crd*/)
    {
        Expirience = exp;

        for (int i = 0; i < countOfShperes; i++)
        {
            switch (Random.Range(0, 4)) {
                case 0: {
                        sphereRed += Random.Range(0, countOfRandomSpheres);
                        break;
                    }
                case 1:
                    {
                        sphereBlue += Random.Range(0, countOfRandomSpheres);
                        break;
                    }
                case 2:
                    {
                        sphereGreen += Random.Range(0, countOfRandomSpheres);
                        break;
                    }
                case 3:
                    {
                        spherePurple += Random.Range(0, countOfRandomSpheres);
                        break;
                    }
            }
        }
        items = new List<Item>();
        for (int i = 0; i < _items.Length; i++)
        {
            items.Add(_items[i]);
        }
    }
    public Reward(int exp, int countOfRandomShperes, params Item[] _items/*, Card crd*/)
    {
        Expirience = exp;
        for (int i = 0; i < countOfRandomShperes; i++)
        {
            int j = Random.Range(0, 4);
            switch (j)
            {
                case 0:
                    {
                        sphereRed += 1;
                        break;
                    }
                case 1:
                    {
                        sphereBlue += 1;
                        break;
                    }
                case 2:
                    {
                        sphereGreen += 1;
                        break;
                    }
                case 3:
                    {
                        spherePurple += 1;
                        break;
                    }
            }
        }
        items = new List<Item>();
        for (int i = 0; i < _items.Length; i++)
        {
            items.Add(_items[i]);
        }
    }

    public void GetReward(Player player) {
        player.Exp = Expirience;
        player.SphereRed += sphereRed;
        player.SphereBlue += sphereBlue;
        player.SphereGreen += sphereGreen;
        player.SpherePurple += spherePurple;
        if (items != null)
        {
            foreach (Item it in items)
            {
                player.AddNewItem(it);
                //Debug.Log("REWARD: ItemID" + it.ID);
            }
        }
        player.Cards[player.CurrentCard].Exp = Expirience;
    }

    public void DeepCopy(Reward rew) {
        Expirience = rew.Expirience;
        sphereRed = rew.sphereRed;
        sphereBlue = rew.sphereBlue;
        sphereGreen = rew.sphereGreen;
        spherePurple = rew.spherePurple;
        items = new List<Item>();
        if (rew.items != null)
        {
            foreach (Item it in rew.items)
            {
                items.Add(it);
            }
        }
    }

    public override string ToString()
    {
        string str = "";
        if (Expirience != 0) {
            str += "Exp: " + Expirience + "\n";
        }
        if (sphereRed != 0) {
            str += "Red: " + sphereRed + "\n";
        }
        if (sphereBlue != 0)
        {
            str += "Blue: " + sphereBlue + "\n";
        }
        if (sphereGreen != 0)
        {
            str += "Green: " + sphereGreen + "\n";
        }
        if (spherePurple != 0)
        {
            str += "Purple: " + spherePurple + "\n";
        }
        return str;
    }

    void Start () {
		
	}
	void Update () {
		
	}
}
