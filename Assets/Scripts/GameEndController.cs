using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{

    public Collider2D DeathZoneCollider;
    public delegate void NonPlayerCallback(GameObject Target);
    public NonPlayerCallback nonPlayerCallback;
    public GameController gameController = null;
    private bool isPlayerDead = false;
    public GameObject GameEndedPanel;
    public Text GameEndedText;

    public PlayerLifeManager PlayerLifeManager;
    public GameObject[] PlayerOptions;

    void Start()
    {
        GameEndedPanel?.SetActive(false);
    }

    public void resolveNonPlayerInteractions0(GameObject Target){
        if (nonPlayerCallback != null )
        {
            nonPlayerCallback.Invoke(Target);
        }
    }

    public void ResolveInteraction(GameObject Target){
        if (isPlayerDead || Target.tag != "Player") {
            return;
        }

        Debug.Log("Player hit dead zone");

        if (this.name.Equals("Dead Zone"))
        {
            Debug.Log("Dead Zone");
            DieToDeathZone();
            return;
        }

        if (this.name.Equals("Fire") || this.name.Equals("FutureFireRoomFire"))
        {
            Debug.Log("Fire");
            DieToFireRoom();
            return;
        }

        if (this.name.Equals("NoO2Zone"))
        {
            Debug.Log("NoO2Zone");
            Suffocate();
            return;
        }

        if (gameController != null)
        {
            Debug.Log("gameController");
            if (this.name.Equals("Won") && gameController.hasPower)
            {
                Debug.Log("WON");
                WonGame();
                return;
            }

            if (this.name.Equals("Won") && !gameController.hasPower)
            {
                Debug.Log("No power");
                gameController.ShowModal("The spaceship has no power!", 1);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col){
        ResolveInteraction(col.gameObject);
        resolveNonPlayerInteractions0(col.gameObject);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        ResolveInteraction(collision.gameObject);
        resolveNonPlayerInteractions0(collision.gameObject);
    }

    private void UnAlivePlayer()
    {
        isPlayerDead = true;
        PlayerLifeManager.KillPlayer();
        GameEndedPanel.SetActive(true);
        DisableOptions();
    }

    private void DieToDeathZone(){
        GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
        GameEndedText.text = "You fell through a hole in the floor, wrong place, wrong time";
        UnAlivePlayer();
        DisableOptions();
    }

    private void DieToFireRoom(){
        GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
        GameEndedText.text = "You were burned to a chrisp, if only the fire could be extinguished";
        UnAlivePlayer();
        DisableOptions();
    }

    private void Suffocate(){
        GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
        GameEndedText.text = "You suffocated...";
        UnAlivePlayer();
        DisableOptions();
    }

    private void WonGame()
    {
        Debug.Log("WonGame function called");
        GameEndedPanel.GetComponent<Image>().color = new Color32(25, 164, 64, 100);  // green
        GameEndedText.text = "You safely navigated the asteroid field!";
        
        isPlayerDead = true;
        PlayerLifeManager.EndPlayer();
        GameEndedPanel.SetActive(true);
        DisableOptions();
    }

    public void DisplayMessage(bool Good, string Message){

        if (Good){
            GameEndedPanel.GetComponent<Image>().color = new Color32(25, 164, 64, 100);  // green
        } else {
            GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
        }

        GameEndedText.text = Message;

        isPlayerDead = true;
        GameEndedPanel.SetActive(true);
        DisableOptions();
    }

    public void DisbleDeathZone(){
        if (this.DeathZoneCollider){
            Debug.Log(" Death zone disabled: "+ this.name);

            this.DeathZoneCollider.enabled = false;
            this.gameObject.SetActive(false);
            EnableOptions();
        }
    }

    public void EnableDeathZone(){

        if (this.DeathZoneCollider){
            Debug.Log(" Death zone enabled: "+ this.name);
            this.DeathZoneCollider.enabled = true;
            this.gameObject.SetActive(true);
            DisableOptions();
        }
    }

    public void DisableOptions()
    {
        Debug.Log("disable options");
        foreach(GameObject PlayerOption in PlayerOptions)
        {
            PlayerOption.SetActive(false);
        }
    }

    public void EnableOptions()
    {
        Debug.Log("enable options");
        foreach (GameObject PlayerOption in PlayerOptions)
        {
            PlayerOption.SetActive(true);
        }
    }
}
