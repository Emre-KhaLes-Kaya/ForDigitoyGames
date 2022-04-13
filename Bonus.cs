using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    
  
    public int[] masalar = { 1014000, 1000400, 0002000, 1115000, 1110200, 0103050, 1010400, 1114000, 1118000, 1110200 };
    private bool hýzlý = false;
    private bool teketek = false;
    private bool rovans = false;
    private int bahis = 2000;



    int Convertevalue(bool hýz, bool tek, bool rov, int bah)
    {
        if (bah < 200) bah = 200;
        else if (bah > 5000) bah = 5000;
        var x = bah;
        if (hýz == true) x += 1000000;
        if (tek == true) x += 100000;
        if (rov == true) x += 10000;
        return x;
    }
    public void output(int key)
    {
        var para = key % 5000;
        var secenek = key - para;
        for (int i = 0; i < masalar.Length; i++)
        {
            if (masalar[i] <= key)
            {
                if (secenek == 5000)
                {
                    Debug.Log(i.ToString() + " Masa" + masalar[i].ToString());
                }
                else if (masalar[i] == secenek)
                {
                    Debug.Log(i.ToString() + " Masa" + masalar[i].ToString());
                }
            }
        }
    }
    private void Start()
    {
        output(Convertevalue(hýzlý, teketek, rovans, bahis));
    }
  
}
