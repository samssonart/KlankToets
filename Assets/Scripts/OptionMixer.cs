using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionMixer : MonoBehaviour {

	public RectTransform but0Pos;
    public RectTransform but1Pos;
    public RectTransform but2Pos;
    public RectTransform but0Obj;
    public RectTransform but1Obj;
    public RectTransform but2Obj;

    RectTransform[] polePos = new RectTransform[3];
    List<int> blackList = new List<int>();

    void Awake()
    {

        polePos[0] = but0Pos;
        polePos[1] = but1Pos;
        polePos[2] = but2Pos;

    }

	public void arrangeOptions()
	{

        RectTransform[] positions = new RectTransform[3];
        int turn = 0;
        for (int i = 0; i < 3; i++)
        {
            //Let's get a unique random number
            turn = (int)Random.Range(0, 3);
            //Debug.Log("Before:"+turn.ToString());
            if (blackList.Contains(turn))
            {
                switch (turn)
                {
                    case 0:
                        if (!blackList.Contains(1)) turn = 1;
                        else turn = 2;
                        break;
                    case 1:
                        if (!blackList.Contains(0)) turn = 0;
                        else turn = 2;
                        break;
                    case 2:
                        if (!blackList.Contains(1)) turn = 1;
                        else turn = 0;
                        break;
                }
                
            }
            //Debug.Log("After:" + turn.ToString());
            switch (i)
            {
                case 0:
                    //there's no need to check anything, the first one can go wherever it wants
                    positions[turn] = but0Obj;
                    blackList.Add(turn);
                    break;
                case 1:
                    positions[turn] = but1Obj;
                    blackList.Add(turn);
                    break;
                case 2:
                    positions[turn] = but2Obj;
                    blackList.Add(turn);
                    break;
            }
        }
        for (int j = 0; j < 3; j++)
        {
            //Debug.Log(positions[j].name);
            if(polePos[j] != null) positions[j].position = polePos[j].position;

        }
        blackList.Clear();
	}
}
