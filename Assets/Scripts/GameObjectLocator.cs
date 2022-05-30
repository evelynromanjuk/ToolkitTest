using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLocator
{
    public static Scanner ScannerObject;

    public static void RegisterScanner(Scanner newScannerObject)
    {
        ScannerObject = newScannerObject;
    }
}
