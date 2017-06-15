using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class StringMove
	{
		public enum Property
		{
			Normal,
			Quick
		}

		#region Public Property
		public List<DMove> DMoves { get; set; }
		public List<LimbMove> LimbMoves { get; set; }
		public Property CurrentProperty { get; set; }
		#endregion


		private static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		private static CharacterPosition CharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }

		#region Constructor
		public StringMove()
		{
			DMoves = new List<DMove>();
			LimbMoves = new List<LimbMove>();
			CurrentProperty = Property.Normal;
		}
		public StringMove(IEnumerable<DMove> dMoves, IEnumerable<LimbMove> limbMoves, Property property)
		{
			DMoves = new List<DMove>(dMoves);
			LimbMoves = new List<LimbMove>(limbMoves);
			CurrentProperty = property;
		}
		#endregion

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			if (DMoves != null && DMoves.Any())
			{
				if (CurrentLanguage == Language.English)
				{
					result.Append(string.Join(",", DMoves));
				}
				else if (CurrentLanguage == Language.Japanese)
				{
					result.Append(string.Join("", DMoves));
				}
			}
			if (LimbMoves != null && LimbMoves.Any())
			{
				switch (CurrentProperty)
				{
					case Property.Quick:
						if (CurrentLanguage == Language.English)
						{
							result.Append('+');
							result.Append(string.Join("~", LimbMoves));
						}
						else if (CurrentLanguage == Language.Japanese)
						{
							result.Append('【');
							result.Append(string.Join(",", LimbMoves));
							result.Append('】');
						}
						break;
					case Property.Normal:
						result.Append(string.Join(",", LimbMoves));
						break;
				}
			}
			return result.ToString();
		}

		public static bool TryParse(string stringMove, out StringMove result)
		{
			result = null;

			if (string.IsNullOrEmpty(stringMove))
			{
				return false;
			}
			result = new StringMove();
			string input = new string(stringMove.ToCharArray());
			if (CurrentLanguage == Language.Japanese)
			{
				for (int i = 0; i < input.Length; i++)
				{
					if (char.IsDigit(input[i]))
					{
						DMove OneDMove;
						if (DMove.TryParse(input[i], out OneDMove))
						{
							result.DMoves.Add(OneDMove);
						}
					}
					else if (i + 1 < input.Length)
					{
						// Regex!!!

						string limbMoveString = input.Substring(i, 2);
						LimbMove OneLimbMove;
						if (LimbMove.TryParse(limbMoveString, out OneLimbMove))
						{
							result.LimbMoves.Add(OneLimbMove);
						}
						i++;
					}
				}
			}

			return true;
		}

	}
}
