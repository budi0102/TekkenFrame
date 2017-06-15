using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TekkenDB.Enums;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Directions : IEnumerable<Direction>
    {
        #region Public Members
        [DataMember]
        public List<Direction> DirectionList
        {
            get
            {
                return directions;
            }
            set
            {
                directions = value;
            }
        }
        [DataMember]
        public bool IsQuick { get; set; }
        [IgnoreDataMember]
        public Locale Locale = Locale.English;
        #endregion

        #region Constructor
        public Directions()
        {
            directions = new List<Direction>();
            IsQuick = false;
        }
        public Directions(IEnumerable<Direction> directions)
        {
            if (directions is List<Direction>)
            {
                this.directions = (List<Direction>)directions;
            }
            else
            {
                this.directions = directions.ToList();
            }
            IsQuick = false;
        }
        public Directions(IEnumerable<Direction> directions, bool isQuick)
        {
            if (directions is List<Direction>)
            {
                this.directions = (List<Direction>)directions;
            }
            else
            {
                this.directions = directions.ToList();
            }
            IsQuick = isQuick;
        }
        public Directions(Directions directions)
        {
            this.directions = directions.directions;
            this.IsQuick = directions.IsQuick;
        }
        #endregion

        #region private members
        private List<Direction> directions;
        #endregion

        #region Public Methods
        public IEnumerator<Direction> GetEnumerator()
        {
            return ((IEnumerable<Direction>)DirectionList).GetEnumerator();
        }

        public override string ToString()
        {
            string delimiter = IsQuick ? "~" : ",";
            return string.Join(delimiter, DirectionList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Direction>)DirectionList).GetEnumerator();
        }
        #endregion
    }
}
