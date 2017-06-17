using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    public class BasicMoves : Moves
    {
        public BasicMoves()
            : base()
        {
        }
        public BasicMoves(Move move)
            : base(move)
        {
        }
        public BasicMoves(Moves moves)
            :base(moves)
        {
        }
        public BasicMoves(IEnumerable<Move> moves)
            :base(moves)
        {
        }
    }
}
