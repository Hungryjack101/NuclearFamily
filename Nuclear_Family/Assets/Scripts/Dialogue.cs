using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject wizardgameObject;
    
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (textComponent.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            gameObject.SetActive(false);
            Destroy(wizardgameObject);
        }
    }
    
    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    
    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
            Destroy(wizardgameObject);
        }
    }
}
