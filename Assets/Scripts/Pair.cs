﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair : MonoBehaviour {

    int x;
    int y;

    public Pair(int x, int y)
    {
        this.x = x; ;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
}
