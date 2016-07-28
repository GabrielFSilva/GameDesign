using UnityEngine;
using System.Collections;

public class ColorInfo
{
	public enum ColorType
	{
		RED,
		BLUE,
		GREEN
	}

	public static Color ColorTypeToColor(ColorType p_type)
	{	
		if (p_type == ColorType.RED)
			return new Color (245f / 255f, 67f / 255f, 5f / 255f);
		else if (p_type == ColorType.BLUE)
			return new Color (12f / 255f, 174f / 255f, 153f / 255f);
		else
			return new Color (175f / 255f, 210f / 255f, 14f / 255f);
	}
	public static ColorType GetRandomColor()
	{
		return (ColorType)Random.Range (0, 3);
	}
	public static ColorType GetNextColor(ColorType p_type)
	{
		if (p_type == ColorType.RED)
			return ColorType.BLUE;
		else if (p_type == ColorType.BLUE)
			return ColorType.GREEN;
		else
			return ColorType.RED;
	}
	public static ColorType GetPreviousColor(ColorType p_type)
	{
		if (p_type == ColorType.RED)
			return ColorType.GREEN;
		else if (p_type == ColorType.BLUE)
			return ColorType.RED;
		else
			return ColorType.BLUE;
	}
}

