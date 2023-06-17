//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIButtonClick : MonoBehaviour
//{
//    public PlayerManager playerManager;

//    public void LeftClick()
//    {
//        playerManager.SetMoveLeft(true);
//        playerManager.SetMoveRight(false);
//    }

//    public void RightClick()
//    {
//        playerManager.SetMoveRight(true);
//        playerManager.SetMoveLeft(false);
//    }

//    public void JumpClick()
//    {
//        playerManager.Jump();
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class UIButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
//{
//    public PlayerManager playerManager;

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if (gameObject.name == "LeftButton")
//        {
//            playerManager.SetMoveLeft(true);
//            playerManager.SetMoveRight(false);
//        }
//        else if (gameObject.name == "RightButton")
//        {
//            playerManager.SetMoveRight(true);
//            playerManager.SetMoveLeft(false);
//        }
//    }

//    public void OnPointerUp(PointerEventData eventData)
//    {
//        if (gameObject.name == "LeftButton" || gameObject.name == "RightButton")
//        {
//            playerManager.StopMoving();
//        }
//    }

//    public void JumpClick()
//    {
//        playerManager.Jump();
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class UIButtonClick : MonoBehaviour
//{
//    public PlayerManager playerManager;

//    public void LeftClick()
//    {
//        playerManager.SetMoveLeft(true);
//        playerManager.SetMoveRight(false);
//    }

//    public void RightClick()
//    {
//        playerManager.SetMoveRight(true);
//        playerManager.SetMoveLeft(false);
//    }

//    public void JumpClick()
//    {
//        playerManager.Jump();
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class UIButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
//{
//    public PlayerManager playerManager;

//    private bool isLeftButtonPressed = false;
//    private bool isRightButtonPressed = false;

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if (gameObject.name == "LeftButton")
//        {
//            isLeftButtonPressed = true;
//            playerManager.SetMoveLeft(true);
//            playerManager.SetMoveRight(false);
//        }
//        else if (gameObject.name == "RightButton")
//        {
//            isRightButtonPressed = true;
//            playerManager.SetMoveRight(true);
//            playerManager.SetMoveLeft(false);
//        }
//    }

//    public void OnPointerUp(PointerEventData eventData)
//    {
//        if (gameObject.name == "LeftButton")
//        {
//            isLeftButtonPressed = false;
//        }
//        else if (gameObject.name == "RightButton")
//        {
//            isRightButtonPressed = false;
//        }

//        if (!isLeftButtonPressed && !isRightButtonPressed)
//        {
//            playerManager.StopMoving();
//        }
//    }

//    public void JumpClick()
//    {
//        playerManager.Jump();
//    }
//}