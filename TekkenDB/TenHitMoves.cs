using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;

namespace TekkenDB
{
    public class TenHitsMoves : Moves
    {
        public TenHitsMoves()
            : base()
        {
        }
        public TenHitsMoves(Move move)
            : base(move)
        {
        }
        public TenHitsMoves(Moves moves)
            :base(moves)
        {
        }
        public TenHitsMoves(IEnumerable<Move> moves)
            :base(moves)
        {
        }
    }
}
