using System;

//The item class is used throughout the game. The only part of it that has been
//unusable is the CarryCapacity, as we were unable to implement it properly.
namespace DungeonGame
{
	public interface IItem
	{
		string Name { get; set; }
		float Weight { get; set; }
		void AddDecorator(IItem decorator);
		string LongName();
		float CarryCapacity { get; set; }

		string ToString();

	}
	public class Item : IItem
	{
		public string Name { get; set; }
		private float _weight { get; set; }
		private float _carryCapacity { get; set; }
		public float CarryCapacity
		{
			get
			{
				return _carryCapacity;
			}
			set
			{
				_carryCapacity = 100f;
			}
		}
		public float Weight {
			get
			{
				return _weight + (_decorator == null ? 0 : _decorator.Weight);
			}
			set
			{
				_weight = value;
			}
				}

		private IItem _decorator;

		public Item() : this("Thingy thing", 0.1f)
		{
		}
		public Item(string name, float weight)
		{
			Name = name;
			Weight = weight;
			_decorator = null;

		}
		public void AddDecorator(IItem decorator)
		{
			if(_decorator == null)
			{
				_decorator = decorator;
			}
			else
			{
				_decorator.AddDecorator(decorator);
			}
			
		}
		public string LongName()
		{
			return Name +(_decorator == null ? "" : ", " + _decorator.LongName());
		}

		override
		public string ToString()
		{
			return Name +  "(" + LongName() + ")" + ", Weight: " + Weight;
		}
	}

}
