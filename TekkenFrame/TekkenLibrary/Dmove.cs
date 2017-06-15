using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class DMove
	{
		[Flags]
		internal enum Direction
		{
			Neutral = 0,
			Up = 1 << 0,
			Down = 1 << 1,
			Back = 1 << 2,
			Forward = 1 << 3
		}
		public enum Property
		{
			Normal,
			QuickRelease,
			Hold
		}

		#region Public Type Safe Enum
		public static readonly DMove FullCrouch = new DMove(Direction.Down, Property.Hold);
		public static readonly DMove SideStepUp = new DMove(Direction.Up, Property.QuickRelease);
		public static readonly DMove SideStepDown = new DMove(Direction.Down, Property.QuickRelease);

		public static readonly DMove Up = new DMove(Direction.Up);
		public static readonly DMove Down = new DMove(Direction.Down);
		public static readonly DMove Forward = new DMove(Direction.Forward);
		public static readonly DMove Back = new DMove(Direction.Back);

		public static readonly DMove DownBack = new DMove(Direction.Down | Direction.Back);
		public static readonly DMove DownForward = new DMove(Direction.Down | Direction.Forward);
		public static readonly DMove UpBack = new DMove(Direction.Up | Direction.Back);
		public static readonly DMove UpForward = new DMove(Direction.Up | Direction.Forward);
		#endregion

		#region Public Property
		internal Direction CurrentDirection { get; set; }
		public Property CurrentProperty { get; set; }
		public static CharacterPosition CurrentCharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }
		public static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		#endregion

		#region Constructor
		private DMove()
		{
			CurrentDirection = Direction.Neutral;
			CurrentProperty = Property.Normal;
		}
		internal DMove(Direction direction, Property property = Property.Normal)
			:this()
		{
			CurrentDirection = direction;
			CurrentProperty = property;
		}
		public DMove(DMove dmove)
			: this(dmove.CurrentDirection, dmove.CurrentProperty)
		{
		}
		#endregion


		#region Static Methods
		public static bool TryParse(char dMove, out DMove result)
		{
			string dMoveString = new string(dMove, 1);
			return TryParse(dMoveString, out result);
		}
		public static bool TryParse(string dMoveString, out DMove result)
		{
			result = null;
			if (string.IsNullOrEmpty(dMoveString))
			{
				return false;
			}

			string input = new string(dMoveString.ToCharArray());
			bool IsJapanese = input.Any(char.IsDigit);
			result = new DMove();
			switch (IsJapanese)
			{
				case true:
					input = input.ToLower();
					if (input.Contains('h'))
					{
						result.CurrentProperty = Property.Hold;
						input = input.Replace("h", string.Empty);
					}
					switch (input)
					{
						case "1":
							result.CurrentDirection = Direction.Down | Direction.Back;
							break;
						case "2":
							result.CurrentDirection = Direction.Down;
							break;
						case "3":
							result.CurrentDirection = Direction.Down | Direction.Forward;
							break;
						case "4":
							result.CurrentDirection = Direction.Back;
							break;
						case "5":
							result.CurrentDirection = Direction.Neutral;
							break;
						case "6":
							result.CurrentDirection = Direction.Forward;
							break;
						case "7":
							result.CurrentDirection = Direction.Up | Direction.Back;
							break;
						case "8":
							result.CurrentDirection = Direction.Up;
							break;
						case "9":
							result.CurrentDirection = Direction.Up | Direction.Forward;
							break;
						default:
							return false;
					}
					break;
				case false:
					input = input.Replace("\\", string.Empty).Replace("/", string.Empty).Replace("+", string.Empty);
					foreach (char c in input)
					{
						switch (c)
						{
							case 'B':
								result.CurrentDirection = Direction.Back;
								result.CurrentProperty = Property.Hold;
								break;
							case 'b':
								result.CurrentDirection = Direction.Back;
								break;
							case 'F':
								result.CurrentDirection = Direction.Forward;
								result.CurrentProperty = Property.Hold;
								break;
							case 'f':
								result.CurrentDirection = Direction.Forward;
								break;
							case 'U':
								result.CurrentDirection = Direction.Up;
								result.CurrentProperty = Property.Hold;
								break;
							case 'u':
								result.CurrentDirection = Direction.Up;
								break;
							case 'D':
								result.CurrentDirection = Direction.Down;
								result.CurrentProperty = Property.Hold;
								break;
							case 'd':
								result.CurrentDirection = Direction.Down;
								break;
							case 'N':
							case 'n':
								result.CurrentProperty = Property.QuickRelease;
								break;
							default:
								return false;
						}
					}
					break;
			}
			return true;
		}
		internal static bool IsMoveCorrect(Direction direction)
		{
			switch (direction)
			{
				case (Direction.Back | Direction.Forward):
					return false;
				case (Direction.Up | Direction.Down):
					return false;
				default:
					if (((int)direction >= (1 << 4)) ||
						((int)direction < 0))
					{
						return false;
					}
					return true;
			}
		}
		#endregion
		#region Public Methods
		public bool TryParse(string dmove)
		{
			DMove result;
			if (TryParse(dmove, out result))
			{
				CurrentDirection = result.CurrentDirection;
				CurrentProperty = result.CurrentProperty;
				return true;
			}
			return false;
		}
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			if (CurrentLanguage == Language.English)
			{
				if (CurrentDirection == Direction.Neutral)
				{

				}
				else
				{
					if ((CurrentDirection & Direction.Down) > 0)
					{
						str.Append('d');
					}
					else if ((CurrentDirection & Direction.Up) > 0)
					{
						str.Append('u');
					}
					if ((CurrentDirection & Direction.Back) > 0)
					{
						str.Append('b');
					}
					else if ((CurrentDirection & Direction.Forward) > 0)
					{
						str.Append('f');
					}
				}
				switch (CurrentProperty)
				{
					case Property.Hold:
						return str.ToString().ToUpper();
					case Property.QuickRelease:
						str.Append('N');
						break;
				}
			}
			else if (CurrentLanguage == Language.Japanese)
			{
				switch (CurrentCharacterPosition.Current)
				{
					case CharacterPosition.Position.Left:
						switch (CurrentDirection)
						{
							case Direction.Down | Direction.Back:
								str.Append('1');
								break;
							case Direction.Down:
								str.Append('2');
								break;
							case Direction.Down | Direction.Forward:
								str.Append('3');
								break;
							case Direction.Back:
								str.Append('4');
								break;
							case Direction.Neutral:
								str.Append('5');
								break;
							case Direction.Forward:
								str.Append('6');
								break;
							case Direction.Up | Direction.Back:
								str.Append('7');
								break;
							case Direction.Up:
								str.Append('8');
								break;
							case Direction.Up | Direction.Forward:
								str.Append('9');
								break;
						}
						break;
					case CharacterPosition.Position.Right:
						switch (CurrentDirection)
						{
							case Direction.Down | Direction.Back:
								str.Append('3');
								break;
							case Direction.Down:
								str.Append('2');
								break;
							case Direction.Down | Direction.Forward:
								str.Append('1');
								break;
							case Direction.Back:
								str.Append('6');
								break;
							case Direction.Neutral:
								str.Append('5');
								break;
							case Direction.Forward:
								str.Append('4');
								break;
							case Direction.Up | Direction.Back:
								str.Append('9');
								break;
							case Direction.Up:
								str.Append('8');
								break;
							case Direction.Up | Direction.Forward:
								str.Append('7');
								break;
						}
						break;
				}
				//str.Append(CurrentDirection.ToString());
				switch (CurrentProperty)
				{
					case Property.Hold:
						str.Append("H");
						break;
					case Property.QuickRelease:
						str.Append("☆");
						break;
				}
			}
			return str.ToString();
		}
		#endregion


		#region private helper
		private bool IsMoveCorrect()
		{
			return IsMoveCorrect(CurrentDirection);
		}
		#endregion
	}
}
