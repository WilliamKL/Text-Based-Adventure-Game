using System;
using System.Collections.Generic;

//This would have been used to contain items we wanted. We decided against it at the
//end but decided to keep the code in to show that we were planning on using ut.
namespace DungeonGame
{
	public interface IItemContainer : IItem
	{
		void put(IItem item);
		IItem remove(string itemName);
		string contents();
	}
	public class ItemContainer : IItemContainer
	{
		private Dictionary<string, IItem> items;
		public string Name { get; set; }
		private float _weight;
		private float _carryMax;
		private float _carryCapacity { get; set; }
		public float Weight {
			get
			{
				float tWeight = _weight;
				foreach(IItem item in items.Values)
				{
					tWeight += item.Weight;
				}
				return tWeight;
			}
			set
			{
				_weight = value;
			}
				}
		public float CarryCapacity {
			get
			{
				float Max = _carryCapacity;
				return Max;
			}
			set
			{
				_carryMax = 100.0f;
			}
				 }


		public ItemContainer()
		{
			items = new Dictionary<string, IItem>();
		}
		public void put(IItem item)
		{
			if(Weight > CarryCapacity)
			{
				Console.WriteLine("This is to heavy!");
			}
			else
			{
				items[item.Name] = item;
			}
		}
		public IItem remove ( string itemName)
		{
			IItem item = null;
			items.Remove(itemName, out item);
			return item;
		}

		public void  AddDecorator(IItem decorator)
		{

		}

		public string contents()
		{
			string itemNames = "Items: \n";
			Dictionary<string, IItem>.KeyCollection keys = items.Keys;
			foreach(string itemName in keys)
			{
				itemNames += " " + items[itemName].ToString() + "\n";
			}
			return itemNames;
		}
		public string LongName()
		{
            return "";
        }
		override
		public string ToString()
		{
			return Name + ", Weight: " + Weight;
		}
	}
}
