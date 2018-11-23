using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {

	public static void Swap<T>(ref T value1 , ref T value2)
    {
        T temp = value1;
        value1 = value2;
        value2 = temp;
    }
    public static void SwapSprites(SpriteRenderer sr1,SpriteRenderer sr2)
    {
        Sprite temp = sr1.sprite;
        sr1.sprite = sr2.sprite;
        sr2.sprite = temp;
        Color temp1 = sr1.color;
        sr1.color = sr2.color;
        sr2.color = temp1;
    }
}
