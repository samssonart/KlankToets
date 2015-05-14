using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public enum ApplicationState
    {
        UserData,
        QuestionsTime,
        SendingEmail,
        End

    };

    public static GameLogic instanceRef;
    public UserData dataScreen;
    public LoadQuestion questionLoader;
    public EmailSender emailSender;
    public ApplicationState appState;
    private string userName = "";
    private string userMail = "";

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

    }

	// Use this for initialization
	void Start () {
        appState = ApplicationState.UserData;
	
	}

    public void changeState(string newState)
    {

        switch (newState)
        {
            case "UserData":
                appState = ApplicationState.UserData;
                break;

            case "Test":
                appState = ApplicationState.QuestionsTime;

                break;

            case "Mail":
                appState = ApplicationState.SendingEmail;

                break;

            default:
                appState = ApplicationState.End;

                break;
        }

    }

    public void setUserData(string name, string mail)
    {

        userName = name;
        userMail = mail;

    }
}
