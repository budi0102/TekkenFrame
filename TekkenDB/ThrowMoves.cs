using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    public class ThrowMoves : Moves
    {
        public ThrowMoves()
            : base()
        {
        }
        public ThrowMoves(Move move)
            : base(move)
        {
        }
        public ThrowMoves(Moves moves)
            :base(moves)
        {
        }
        public ThrowMoves(IEnumerable<Move> moves)
            :base(moves)
        {
        }
    }
}
