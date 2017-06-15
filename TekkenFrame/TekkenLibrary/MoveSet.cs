using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class MoveSet
	{
		#region Enums
		[Flags]
		public enum HitPos
		{
			None = 0,
			High = 1,
			Mid = 1 << 1,
			SpecialMid = 1 << 2,
			Low = 1 << 3,
			Grounded = 1 << 4,
			ThrowGrab = 1 << 5,
			Unblockable = 1 << 6,
			Homing = 1 << 7,
			Screw = 1 << 8
		}
		[Flags]
		public enum PositionProp
		{
			Unknown = 0,
			Stand = 1,
			Crouch = 1 << 1,
			BackTurned = 1 << 2,
			Jump = 1 << 3,
			SideStepLeft = 1 << 4,
			SideStepRight = 1 << 5,
			FaceUpFeetNearest = 1 << 6,
			FaceUpHeadNearest = 1 << 7,
			FaceDownFeetNearest = 1 << 8,
			FaceDownHeadNearest = 1 << 9
		}
		[Flags]
		public enum CrushProp
		{
			None = 0,
			[Display(Description = "Evade Enemy's High Attack", Name = "High Crush", ShortName = "HighCrush")]
			HighCrushEvadeHigh,
			[Display(Description = "Evade Enemy's Mid Attack", Name = "Mid Crush", ShortName = "MidCrush")]
			MidCrushEvadeMid,
			[Display(Description = "Evade Enemy's Low Attack", Name = "Low Crush", ShortName = "LowCrush")]
			LowCrushEvadeLow,
			[Display(Description = "Evade Enemy's Attack by Stepping Back first", Name = "Step Back", ShortName = "StepBack")]
			StepBack,
			[Display(Description = "Evade Enemy's High Attack", Name = "High Crush", ShortName = "HighCrush")]
			PowerCrush,

			Invicible

		}
		#endregion

		public MultiLocaleString Name { get; set; }
		public List<StringMove> Moves { get; set; }
		public List<HitPos> HitPositions { get; set; }
		public CrushProp CrushProperty { get { return CrushProperties.LastOrDefault(); } }
		/// <summary>
		/// Player Property on the Move
		/// </summary>
		public List<CrushProp> CrushProperties { get; set; }
		public PositionProp PositionPropertiy { get { return PositionProperties.LastOrDefault(); } }
		/// <summary>
		/// Player Property after Move is completed
		/// </summary>
		public List<PositionProp> PositionProperties { get; set; }
		public PositionProp EnemyPositionProperty { get; set; }
		public int Damage { get { return (Damages != null) ? Damages.Sum() : 0; } }
		public List<int> Damages { get; set; }
		public List<int> ActiveFrames { get; set; }
		public int? FastestFrame { get; set; }
		public int? FrameOnBlock { get; set; }
		public int? FrameOnHit { get; set; }
		public int? FrameOnCounterHit { get; set; }
		public string Note { get; set; }

		public MoveSet()
		{
			Name = new MultiLocaleString();
			Moves = new List<TekkenLibrary.StringMove>();
			HitPositions = new List<HitPos>();
			CrushProperties = new List<CrushProp>();
			PositionProperties = new List<PositionProp>();
			EnemyPositionProperty = PositionProp.Stand;
			Damages = new List<int>();
			ActiveFrames = new List<int>();
			FastestFrame = null;
			FrameOnBlock = null;
			FrameOnHit = null;
			FrameOnCounterHit = null;
			Note = null;
		}

		public void AddMove(StringMove move, HitPos hitPosition, int damage,
			CrushProp crushProperty = CrushProp.None,
			PositionProp positionProperty = PositionProp.Stand,
			PositionProp enemyPositionProperty = PositionProp.Stand)
		{
			Moves.Add(move);
			HitPositions.Add(hitPosition);
			Damages.Add(damage);
			CrushProperties.Add(crushProperty);
			PositionProperties.Add(positionProperty);
		}
	
	}
}
