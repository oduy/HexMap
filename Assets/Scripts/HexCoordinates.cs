﻿using System;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates 
{
    [SerializeField]
    private int x, z;

    public int X {get{ return x;}}

    public int Z {get{return z;}}

    public int Y {get {return -X -Z;}}

    public HexCoordinates(int x, int z){
        this.x = x;
        this.z = z;
    }

    public static HexCoordinates FromOffsetCoordinates (int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    } 

    public override string ToString() 
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }

    internal static HexCoordinates FromPosition(Vector3 position)
    {
        float x = position.x / (HexMatrics.innerRadius * 2f);
		float y = -x;
        float offset = position.z / (HexMatrics.outerRadius * 3f);
		x -= offset;
		y -= offset;
        int iX = Mathf.RoundToInt(x);
		int iY = Mathf.RoundToInt(y);
		int iZ = Mathf.RoundToInt(-x -y);

		return new HexCoordinates(iX, iZ);
    }
}
