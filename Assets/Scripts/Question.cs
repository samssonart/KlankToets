using UnityEngine;
using System.Collections;

public class Question : MonoBehaviour {

    public string statement
    {
        get;
        set;
    }
    public string wrongOne
    {
        get;
        set;
    }
    public string wrongTwo
    {
        get;
        set;
    }
    public string correct{
        get;
        set;
    }

    public Question()
    {
        this.statement = string.Empty;
        this.wrongOne = string.Empty;
        this.wrongTwo = string.Empty;
        this.correct = string.Empty;
    }

}
