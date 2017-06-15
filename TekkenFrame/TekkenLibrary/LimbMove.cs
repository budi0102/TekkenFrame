using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class LimbMove
	{
		[Flags]
		internal enum Limb
		{
			Nothing = 0,
			LeftPunch = 1,
			RightPunch = 1 << 1,
			LeftKick = 1 << 2,
			RightKick = 1 << 3
		}
		public enum Property
		{
			Normal,
			Hold
		}

		public static readonly LimbMove Nothing = new LimbMove(Limb.Nothing);
		public static readonly LimbMove LeftPunch = new LimbMove(Limb.LeftPunch);
		public static readonly LimbMove RightPunch = new LimbMove(Limb.RightPunch);
		public static readonly LimbMove AllPunches = new LimbMove(Limb.LeftPunch | Limb.RightPunch);
		public static readonly LimbMove LeftKick = new LimbMove(Limb.LeftKick);
		public static readonly LimbMove RightKick = new LimbMove(Limb.RightKick);
		public static readonly LimbMove AllKicks = new LimbMove(Limb.LeftKick | Limb.RightKick);
		public static readonly LimbMove AllLeft = new LimbMove(Limb.LeftPunch | Limb.LeftKick);
		public static readonly LimbMove AllRight = new LimbMove(Limb.RightPunch | Limb.RightKick);
		public static readonly LimbMove LeftPunchRightKick = new LimbMove(Limb.LeftPunch | Limb.RightKick);
		public static readonly LimbMove RightPuchLeftKick = new LimbMove(Limb.RightPunch | Limb.LeftKick);
		public static readonly LimbMove All = new LimbMove(Limb.LeftPunch | Limb.RightPunch | Limb.LeftKick | Limb.RightKick);

		#region Public Property
		internal Limb CurrentLimb { get; set; }
		public Property CurrentProperty { get; set; }
		public string Note { get; set; }
		#endregion

		#region Global Settings
		private static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		private static CharacterPosition CurrentCharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }
		#endregion

		#region  Constructor
		internal LimbMove(Limb limb, Property property = Property.Normal, string note = null)
		{
			CurrentLimb = limb;
			CurrentProperty = property;
			Note = note;
		}
		#endregion

		public override string ToString()
		{
			List<string> limbs = new List<string>();
			if (CurrentLimb != Limb.Nothing)
			{
				if (CurrentLanguage == Language.Japanese)
				{

					if ((CurrentLimb & Limb.LeftPunch) > 0)
					{
						limbs.Add("LP");
					}
					if ((CurrentLimb & Limb.RightPunch) > 0)
					{
						limbs.Add("RP");
					}
					if ((CurrentLimb & Limb.LeftKick) > 0)
					{
						limbs.Add("LK");
					}
					if ((CurrentLimb & Limb.RightKick) > 0)
					{
						limbs.Add("RK");
					}

				}
				else if (CurrentLanguage == Language.English)
				{
					if (CurrentLimb == Limb.LeftPunch)
					{
						limbs.Add("1");
					}
					if (CurrentLimb == Limb.RightPunch)
					{
						limbs.Add("2");
					}
					if (CurrentLimb == Limb.LeftKick)
					{
						limbs.Add("3");
					}
					if (CurrentLimb == Limb.RightKick)
					{
						limbs.Add("4");
					}
				}
				else
				{
					if (CurrentLimb == Limb.LeftPunch)
					{
						limbs.Add("□");
					}
					if (CurrentLimb == Limb.RightPunch)
					{
						limbs.Add("△");
					}
					if (CurrentLimb == Limb.LeftKick)
					{
						limbs.Add("✕");
					}
					if (CurrentLimb == Limb.RightKick)
					{
						limbs.Add("〇");
					}
				}
			}
			return string.Join("+", limbs);
		}
		public bool TryParse(string limbMove)
		{
			LimbMove result;
			if(TryParse(limbMove, out result))
			{
				CurrentLimb = result.CurrentLimb;
				CurrentProperty = result.CurrentProperty;
				return true;
			}
			return false;
		}

		public static bool TryParse(string limbMove, out LimbMove result)
		{
			result = null;
			if(string.IsNullOrEmpty(limbMove))
			{
				return false;
			}
			result = new LimbMove(Limb.Nothing);
			string input = new string(limbMove.ToCharArray());
			if(CurrentLanguage == Language.English)
			{
				result = new LimbMove(Limb.Nothing);
				input = input.Replace("+", string.Empty);
				foreach(char c in input)
				{
					switch(c)
					{
						case '1':
							result.CurrentLimb |= Limb.LeftPunch;
							break;
						case '2':
							result.CurrentLimb |= Limb.RightPunch;
							break;
						case '3':
							result.CurrentLimb |= Limb.LeftKick;
							break;
						case '4':
							result.CurrentLimb |= Limb.RightKick;
							break;
						case 'h':
							result.CurrentProperty = Property.Hold;
							break;
					}
				}
			}
			else if(CurrentLanguage == Language.Japanese)
			{
				input = input.ToLower();
				if(input.Contains("lp"))
				{
					result.CurrentLimb |= Limb.LeftPunch;
				}
				else if (input.Contains("rp"))
				{
					result.CurrentLimb |= Limb.RightPunch;
				}
				else if(input.Contains("wp"))
				{
					result.CurrentLimb |= Limb.LeftPunch | Limb.RightPunch;
				}
				else if (input.Contains("lk"))
				{
					result.CurrentLimb |= Limb.LeftKick;
				}
				else if(input.Contains("rk"))
				{
					result.CurrentLimb |= Limb.RightKick;
				}
				else if (input.Contains("wk"))
				{
					result.CurrentLimb |= Limb.LeftKick | Limb.RightKick;
				}
				else if(input.Contains("h"))
				{
					result.CurrentProperty = Property.Hold;
				}
			}

			return true;
		}
	}
}
