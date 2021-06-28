﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public void OnPointerDown(PointerEventData data)
    {
        if (this.gameObject.tag == "MoveLeftBtn")
            GameManager.instance.MoveThePlayerToLeft();
        else if (this.gameObject.tag == "MoveRightBtn")
            GameManager.instance.MoveThePlayerToRight();
    }

    public void OnPointerUp(PointerEventData data)
    {
        GameManager.instance.StopTheMovement();
    }

}
