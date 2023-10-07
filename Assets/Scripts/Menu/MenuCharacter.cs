using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuCharacter : MonoBehaviour
{
    public Button playButton;
    public Vector2 originalScale; // Kích thước ban đầu của button
    public Vector2 highlightedScale = new Vector2(1.5f, 1.5f); // Kích thước khi nằm trên button

    void Start()
    {
        
        // Lưu kích thước ban đầu của button
        originalScale = playButton.transform.localScale;
        
    }

    void OnPointerEnter()
    {
        // Khi chuột hover vào button, thay đổi kích thước của button
        playButton.transform.localScale = highlightedScale;
    }

    void OnPointerExit()
    {
        // Khi chuột rời khỏi button, khôi phục kích thước ban đầu của button
        playButton.transform.localScale = originalScale;
    }
}
