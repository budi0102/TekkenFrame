using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    public class SpecialMoves :Moves
    {
        public SpecialMoves()
            : base()
        {
        }
        public SpecialMoves(Move move)
            : base(move)
        {
        }
        public SpecialMoves(Moves moves)
            :base(moves)
        {
        }
        public SpecialMoves(IEnumerable<Move> moves)
            :base(moves)
        {
        }
    }
}
