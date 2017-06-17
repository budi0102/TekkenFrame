using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    [DataContract]
    public class PunishMoves
    {
        #region Public Members
        [DataMember]
        public PunishStandMoves Standing { get; set; }
        [DataMember]
        public PunishCrouchMoves Crouching { get; set; }
        #endregion

        #region Constructors
        public PunishMoves()
        {
            Standing = new PunishStandMoves();
            Crouching = new PunishCrouchMoves();
        }
        public PunishMoves(PunishStandMoves standingPunishes, PunishCrouchMoves crouchingPunishes)
        {
            Standing = new PunishStandMoves(standingPunishes);
            Crouching = new PunishCrouchMoves(crouchingPunishes);
        }
        public PunishMoves(PunishMoves punishMoves)
            : this(punishMoves.Standing, punishMoves.Crouching)
        {
        }
        #endregion
    }
    [DataContract]
    public class PunishStandMoves : Moves
    {
        #region Constructors
        public PunishStandMoves()
            : base()
        {
        }
        public PunishStandMoves(Move move)
            : base(move)
        {
        }
        public PunishStandMoves(Moves moves)
            :base(moves)
        {
        }
        public PunishStandMoves(IEnumerable<Move> moves)
            :base(moves)
        {
        }
        PunishStandMoves(PunishStandMoves moves)
            : base(moves)
        {
        }
        #endregion
    }
    [DataContract]
    public class PunishCrouchMoves : Moves
    {
        #region Constructors
        public PunishCrouchMoves()
            : base()
        {
        }
        public PunishCrouchMoves(Move move)
            : base(move)
        {
        }
        public PunishCrouchMoves(Moves moves)
            : base(moves)
        {
        }
        public PunishCrouchMoves(IEnumerable<Move> moves)
            : base(moves)
        {
        }
        public PunishCrouchMoves(PunishCrouchMoves moves)
            : base(moves)
        {
        }
        #endregion
    }
}
