namespace RapidBSP
{
	public class Vector
	{
		private float _x;
		private float _y;
		private float _z;

		public Vector()
		{
			_x = 0.0f;
			_y = 0.0f;
			_z = 0.0f;
		}
		public Vector(float x, float y, float z)
		{
			_x = x;
			_y = y;
			_z = z;
		}
	};
}