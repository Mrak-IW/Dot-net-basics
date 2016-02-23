using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class Dimmer : IAdjustable<int>
	{
		private int currentLevel;
		private readonly int min;
		private readonly int max;
		private readonly int step;

		public Dimmer(int min, int max, int step)
		{
			if (min < 0)
			{
				throw new IndexOutOfRangeException("Попытка создать диммер с отрицательными значениями яркости в диапазоне");
			}
			if (max < min)
			{
				throw new IndexOutOfRangeException("Попытка создать диммер с некорректными границами диапазона значений ");
			}
			if (step < 0 || step > max - min)
			{
				throw new IndexOutOfRangeException("Попытка создать диммер с некорректным шагом");
			}
			this.min = min;
			this.max = max;
			this.step = step;
			this.CurrentLevel = this.Max;
		}

		public virtual int CurrentLevel
		{
			get
			{
				return currentLevel;
			}
			set
			{
				if (value >= Min && value <= Max)
				{
					currentLevel = value;
				}
			}
		}

		public virtual int Max
		{
			get
			{
				return max;
			}
		}
		public virtual int Min
		{
			get
			{
				return min;
			}
		}

		public int Step
		{
			get
			{
				return step;
			}
		}

		public virtual void Decrease()
		{
			CurrentLevel -= step;
		}
		public virtual void Increase()
		{
			CurrentLevel += step;
		}
	}

}
