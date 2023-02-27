using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectInteractionDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text titleText;
    public Text messageText;
    public string objectTitle = "Object";
    public string objectMessage = "This is an object.";
    public Font fontType;
    public int titleFontSize = 24;
    public int messageFontSize = 16;
    public FontStyle fontStyle = FontStyle.Normal;
    public float characterDelay = 0.05f;
    public Color panelColor = Color.white;

    private bool isPlayerNearby = false;
    private bool isAnimatingText = false;

    void Update()
    {
        // Check if the player has pressed the "E" key and is nearby.
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby && !isAnimatingText)
        {
            // Toggle the dialogue panel.
            dialoguePanel.SetActive(!dialoguePanel.activeSelf);

            // Set the font style and size for the title text.
            titleText.font = fontType;
            titleText.fontSize = titleFontSize;
            titleText.fontStyle = fontStyle;

            // Set the font style and size for the message text.
            messageText.font = fontType;
            messageText.fontSize = messageFontSize;
            messageText.fontStyle = fontStyle;

            // Set the text for the title and message.
            titleText.text = objectTitle;

            // Set the message text to an empty string to clear any previous text.
            messageText.text = "";

            // Set the color of the panel.
            dialoguePanel.GetComponent<Image>().color = panelColor;

            // Start the text animation coroutine.
            StartCoroutine(AnimateText(objectMessage, characterDelay));
        }
    }

    IEnumerator AnimateText(string message, float delay)
    {
        isAnimatingText = true;

        // Clear text component
        messageText.text = "";

        // Add each character of the message text to the message text component with a delay between characters.
        for (int i = 0; i < message.Length; i++)
        {
            messageText.text += message[i];
            yield return new WaitForSeconds(delay);
        }

        isAnimatingText = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player object with "Player" tag has entered the trigger collider.
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player object with "Player" tag has exited the trigger collider.
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            dialoguePanel.SetActive(false);
        }
    }
}