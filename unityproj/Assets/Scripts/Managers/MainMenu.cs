using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _uiDocument;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.Q<Button>("PlayButton").clicked += () => PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        GameInfo.CloseLoadingDoors(LoadHQ);
    }

    private void LoadHQ()
    {
        GameInfo.Campaign = new Campaign();
        // GetComponentInParent<Canvas>().gameObject.SetActive(false);
        // destinationCanvas.SetActive(true);
        // _uiDocument.enabled = false;
        GameInfo.Headquarters.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
