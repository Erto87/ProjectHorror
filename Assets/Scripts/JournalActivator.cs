using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class JournalActivator : MonoBehaviour
{
    [SerializeField] private AddJournal journalObject; // Reference to the scriptable object containing journal text
    public GameObject journalTextPanel;// Reference to the panel containing the journal text
    public TextMeshProUGUI journalText;// Reference to the TextMeshProUGUI component displaying the journal text
    public bool showJournal;// Bool indicating whether the journal text should be shown
    private float showJournalTime;// Time remaining for displaying the journal text
    public bool isTextShown;// Bool indicating whether the journal text is currently shown




    public void Read()
    {
        if (!isTextShown)// If the journal text is not currently shown
        {
            isTextShown = true;// Set the bool to indicate that the text is now shown
            showJournal = true;// Set the bool to show the journal text
            showJournalTime = 5f;// Set the time duration for showing the text to 5 seconds
            journalText.text = journalObject.text;// Set the text of the journalText component to the text from the journalObject
            journalTextPanel.SetActive(true);// Activate the journalTextPanel to display the journal text
        }
    }

    void Update()
    {
        if (showJournal)// If the bool to show the journal text is true

        {
            showJournalTime -= Time.deltaTime;// Decrease the remaining time by the time passed since the last frame(5 seconds)

            if (showJournalTime <= 0.01f)// If the remaining time is less than or equal to 0.01 seconds
            {
                showJournal = false;// Set the bool to indicate that the journal text should no longer be shown
            }
        }

        if (!showJournal && isTextShown)// If the bool to show the journal text is false and the text was previously shown
        {
            isTextShown = false;// Reset the bool to indicate that the text is no longer shown
            journalTextPanel.SetActive(false);// Deactivate the journalTextPanel to hide the journal text
        }
    }
}
