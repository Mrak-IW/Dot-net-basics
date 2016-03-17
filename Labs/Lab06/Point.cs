struct Point
{
	public double x;
	public double y;

	public override bool Equals(object obj)
	{
		bool res = false;

		if (obj is Point)
		{
			res = ((Point)obj).x == this.x && ((Point)obj).y == this.y;
		}

		return res;
	}

	public override int GetHashCode()
	{
		return this.x.GetHashCode() + this.y.GetHashCode();
	}

	public override string ToString()
	{
		return "(" + this.x + "; " + this.y + ")";
	}
}