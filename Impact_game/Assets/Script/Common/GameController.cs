using System.Collections.Generic;
using UnityEngine.InputSystem.DualShock;

using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

public static class GameController
{
    //Point of where the projectils should be allow to being destroy
    [SerializeField] public static Vector2 pointAttackAvailable = new Vector2(0,0);
    private static DualShockGamepad gamepad;
    private static Keyboard keyboard;
    private static ButtonControl[] authorisedKeybordCodes;
    private static ButtonControl[] authorisedControllerCodes;

    public static DualShockGamepad GetDualShockGamepad()
    {
        if(gamepad == null)
            gamepad = DualShockGamepad.current;
        return gamepad;

    }

    public static Keyboard GetKeyboard()
    {
        if (keyboard == null)
            keyboard = Keyboard.current;
        return keyboard;

    }

    private static ButtonControl[] GetAuthorisedKeybordCodes()
    {
        if(authorisedKeybordCodes == null)
        {
            GetKeyboard();
            authorisedKeybordCodes = new KeyControl[]
            {
                keyboard.wKey,keyboard.aKey,keyboard.sKey,keyboard.dKey,
                keyboard.iKey,keyboard.jKey,keyboard.kKey,keyboard.lKey,
                keyboard.fKey
            };
        }
        return authorisedKeybordCodes;
    }

    private static ButtonControl[] GetAuthorisedControllerCodes()
    {
        if (authorisedControllerCodes == null)
        {
            GetDualShockGamepad();
            authorisedControllerCodes = new ButtonControl[]
            {
                gamepad.bButton,gamepad.xButton,gamepad.yButton,gamepad.rightShoulder,gamepad.leftShoulder,
                gamepad.buttonEast,gamepad.buttonNorth,gamepad.buttonWest,gamepad.buttonSouth,
            };
        }
        return authorisedControllerCodes;
    }

    public static ButtonControl[] GetAuthorizedCodes()
    {
        return GetEnvironnement() switch
        {
            0 => GetAuthorisedKeybordCodes(),
            1 => GetAuthorisedControllerCodes(),
            _ => throw new System.Exception("Can't found environnement."),
        };
    }

    public static int GetEnvironnement()
    {
        return 0;
    }


}
