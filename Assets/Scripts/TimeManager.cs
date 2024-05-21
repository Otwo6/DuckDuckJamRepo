using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject ruinsMap;
    bool inRuins = true;
    public GameObject medievalMap;
    bool inMedieval = false;
    public GameObject pirateMap;
    bool inPirate = false;

    public bool hasMedieval = false;
    public bool hasPirate = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))   // Go forward
        {
            if(inRuins && hasMedieval)
            {
                inRuins = false;
                inMedieval = true;
                inPirate = false;
            }
            else if(inMedieval && hasPirate)
            {
                inRuins = false;
                inMedieval = false;
                inPirate = true;
            }
            else if(inPirate)
            {
                inRuins = true;
                inMedieval = false;
                inPirate = false;
            }
            PickMap();
        }
        if(Input.GetKeyDown("q"))   // Go back
        {
            if(inRuins && hasPirate)
            {
                inRuins = false;
                inMedieval = false;
                inPirate = true;
            }
            else if(inMedieval)
            {
                inRuins = true;
                inMedieval = false;
                inPirate = false;
            }
            else if(inPirate && hasMedieval)
            {
                inRuins = false;
                inMedieval = true;
                inPirate = false;
            }
            PickMap();
        }
    }

    void PickMap()
    {
        if(inRuins)
        {
            ruinsMap.SetActive(true);
            medievalMap.SetActive(false);
            pirateMap.SetActive(false);
        }
        else if(inMedieval)
        {
            ruinsMap.SetActive(false);
            medievalMap.SetActive(true);
            pirateMap.SetActive(false);
        }
        else if(inPirate)
        {
            ruinsMap.SetActive(false);
            medievalMap.SetActive(false);
            pirateMap.SetActive(true);
        }
    }
}
