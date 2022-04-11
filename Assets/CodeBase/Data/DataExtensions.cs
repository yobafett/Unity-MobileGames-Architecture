using UnityEngine;

namespace CodeBase.Data
{
	public static class DataExtensions
	{
		public static Vector3Data AsVectorData(this Vector3 vector)
		{
			return new Vector3Data(vector.x, vector.y, vector.z);
		}

		public static Vector3 AsUnityVector(this Vector3Data vector)
		{
			return new Vector3(vector.X, vector.Y, vector.Z);
		}

		public static Vector3 AddY(this Vector3 vector, float y)
		{
			vector.y += y;
			return vector;
		}

		public static T ToDeserialized<T>(this string json)
		{
			return JsonUtility.FromJson<T>(json);
		}

		public static string ToJson(this object obj)
		{
			return JsonUtility.ToJson(obj);
		}
	}
}