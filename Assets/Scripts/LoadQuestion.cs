using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class LoadQuestion : MonoBehaviour {

    public string fullQuestions;
    public Question[] questions;
    public Text questionText;
    public Text a1Text;
    public Text a2Text;
    public Text a3Text;
    public Text feedback;

    private int questionIndex;

	// Use this for initialization
    void Start()
    {
        questionIndex = 0;
        string url = "";
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        url = "file://"+Application.dataPath + @"/reactivos.txt";
#elif UNITY_WEBGL
        url = "file://" + Application.dataPath + @"/reactivos.txt";
#endif
        Debug.Log("Loading from "+url);
        WWW request = new WWW(url);

        while (!request.isDone)
        {
            Debug.Log("Loading...");
        }
        feedback.enabled = false;
        fullQuestions = request.text;
        parseQuestions();
    }

    IEnumerator errorMessage(bool right)
    {

        if (right)
        {
            feedback.text = "Ja, geweldig";
            feedback.enabled = true;
        }
        else
        {

            feedback.text = "Nee, dat is fout";
            feedback.enabled = true;

        }
        yield return new WaitForSeconds(3);
        feedback.enabled = false;
    }

    void parseQuestions()
    {

        string[] stringSeparators = new string[] {"</reactivo>"};
        string[] sepratedQuestions = fullQuestions.Split(stringSeparators,StringSplitOptions.None);
        int count = sepratedQuestions.Length - 1;
        questions = new Question[count];
        for (int i = 0; i < count; i++)
        {
            //Debug.Log(sepratedQuestions[i]);
            questions[i] = new Question();
            questions[i].statement = sepratedQuestions[i].Substring(sepratedQuestions[i].IndexOf('#') + 1, sepratedQuestions[i].IndexOf('%') - sepratedQuestions[i].IndexOf('#')-1);
            questions[i].wrongOne = sepratedQuestions[i].Substring(sepratedQuestions[i].IndexOf('%') + 1, sepratedQuestions[i].IndexOf('$') - sepratedQuestions[i].IndexOf('%')-1);
            questions[i].wrongTwo = sepratedQuestions[i].Substring(sepratedQuestions[i].IndexOf('$') + 1, sepratedQuestions[i].IndexOf('&') - sepratedQuestions[i].IndexOf('$')-1);
            questions[i].correct = sepratedQuestions[i].Substring(sepratedQuestions[i].IndexOf('&')+1);

            Debug.Log("Q: "+questions[i].statement);
            Debug.Log("W1: "+questions[i].wrongOne);
            Debug.Log("W2: " + questions[i].wrongTwo);
            Debug.Log("C: " + questions[i].correct);
        }

        loadFirstQuestion();
    }

    public void loadFirstQuestion()
    {

        questionText.text = questions[0].statement;
        a1Text.text = questions[0].wrongOne;
        a2Text.text = questions[0].wrongTwo;
        a3Text.text = questions[0].correct;
        questionIndex = 1;
    }

    public void loadNextQueston(int index)
    {

        //Sanity Check, let's see if this is the last question
        if (index == questions.Length - 1)
        {
            Debug.Log("This is the last question");
            questionText.text = questions[index].statement;
            a1Text.text = questions[index].wrongOne;
            a2Text.text = questions[index].wrongTwo;
            a3Text.text = questions[index].correct;
            questionIndex++;
        }
        else if (index >= questions.Length) afterLast();
        else
        {
            questionText.text = questions[index].statement;
            a1Text.text = questions[index].wrongOne;
            a2Text.text = questions[index].wrongTwo;
            a3Text.text = questions[index].correct;
            questionIndex++;
        }

    }

    public void afterLast()
    {

        questionText.enabled = false;
        a1Text.enabled = false;
        a2Text.enabled = false;
        a3Text.enabled = false;
        feedback.text = "Dat is alles, dank u wel";

    }

    public void clickWrongOne()
    {
        Debug.Log("Nee");
        StartCoroutine(errorMessage(false));
        loadNextQueston(questionIndex);
    }

    public void clickWrongTwo()
    {
        Debug.Log("Nee");
        StartCoroutine(errorMessage(false));
        loadNextQueston(questionIndex);

    }

    public void clickRighOne()
    {
        Debug.Log("Ja");
        StartCoroutine(errorMessage(true));
        loadNextQueston(questionIndex);

    }

}
