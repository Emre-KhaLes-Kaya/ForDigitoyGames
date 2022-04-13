using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchTable : MonoBehaviour
{
    List<Table> listMasa = new List<Table>();
    
    public Slider BahisSlider;
    private int Bahisdeger;
    int snapInterval = 100;
    public Toggle Hizli;
    private bool HizliV;

    public Toggle TekeTek;
    private bool TekeTekV;

    public Toggle Rovans;
    private bool RovansV;
    
    bool RandomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
    void CreatRandomTable(int num)
    {
        for (int i = 0; i < num; i++)
            listMasa.Add(new Table(RandomBoolean(), RandomBoolean(), RandomBoolean(),200+100*Random.Range(0,48)));
    }
    void output(int index)
    {
        Debug.Log(index.ToString()+"  index table  /  Hýz = "+listMasa[index].Hýz.ToString()+"  Tek = " +listMasa[index].Tek.ToString()+"    Rov = "+ listMasa[index].Rov.ToString()+"    Bahis = "+listMasa[index].Bahis.ToString());
    }
    public void ShowSliderValue()
    {
        float value = BahisSlider.value;
        value = Mathf.Round(value / snapInterval) * snapInterval;
        BahisSlider.value = value;
    }
    void takevalue()
    {
        HizliV = Hizli.isOn;
        TekeTekV = TekeTek.isOn;
        RovansV = Rovans.isOn;
        Bahisdeger = (int)BahisSlider.value;
    }

    void Searchvalue()
    {
        for (int i = 0; i < listMasa.Count; i++)
        {
            if (HizliV == listMasa[i].Hýz)
            {
                if (TekeTekV == listMasa[i].Tek)
                {
                    if (RovansV == listMasa[i].Rov)
                    {
                        if (Bahisdeger == listMasa[i].Bahis)
                        {
                            output(i);
                        }
                    }
                }
            }

        }
    
    }
    public void Buttonaction()
    {
        takevalue();
        Searchvalue();

    }
    private void Awake()
    {
        BahisSlider = GameObject.Find("BahisSlider").GetComponent<Slider>();
        Hizli = GameObject.Find("HýzlýToggle").GetComponent<Toggle>();
        TekeTek = GameObject.Find("TeketekToggle").GetComponent<Toggle>();
        Rovans = GameObject.Find("RovanasToggle").GetComponent<Toggle>();
        BahisSlider.minValue = 200;
        BahisSlider.maxValue = 5000;
        CreatRandomTable(200);
    }
    void Start()
    {
        BahisSlider.onValueChanged.AddListener(delegate { ShowSliderValue(); });
        listMasa.Add(new Table(true, true, true, 3000));

    }


    
}
public struct Table
{
    public bool Hýz;
    public bool Tek;
    public bool Rov;
    public int Bahis;

    public Table(bool hýz, bool tek, bool rov, int bahis)
    {
        this.Hýz = hýz;
        this.Tek = tek;
        this.Rov = rov;
        this.Bahis = bahis;
    }

}