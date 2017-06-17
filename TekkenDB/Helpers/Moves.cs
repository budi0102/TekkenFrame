using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    [DataContract]
    public class Moves : ObservableCollection<Move>, IEnumerable<Move>, ICollection<Move>, IList<Move>
    {
        #region Public Members
        [DataMember(Name ="Moves")]
        public List<Move> MoveList
        {
            get
            {
                return movelist;
            }
            set
            {
                movelist = value;
                this.Clear();
                foreach(Move move in movelist)
                {
                    this.Add(move);
                }
            }
        }
        #endregion

        #region Constructor
        public Moves()
            : base()
        {
        }
        public Moves(Move move)
            : base()
        {
            this.Add(move);
        }
        public Moves(Moves moves)
            : base(moves.Items)
        {
        }
        public Moves(IEnumerable<Move> moves)
            : base(moves)
        {
        }
        #endregion

        #region Public Methods
        #endregion

        #region private members
        private List<Move> movelist;
        #endregion
    }
}
