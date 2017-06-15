using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Enums;
using Newtonsoft.Json;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Direction
    {
        #region Public Members
        [DataMember(EmitDefaultValue =true)]
        public DirectionEnum Way { get; set; }

        [IgnoreDataMember]
        public bool ForceShowNeutral = false;
        [IgnoreDataMember]
        public Locale Locale = Locale.English;
        [IgnoreDataMember]
        public bool isLeftSide = true;
        #endregion

        #region Constructor
        public Direction()
        {
            Way = DirectionEnum.Neutral;
        }
        public Direction(DirectionEnum direction)
        {
            Way = direction;
        }
        public Direction(Direction direction)
        {
            Way = direction.Way;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            switch (Locale)
            {
                case Locale.Japanese:
                    if (Way == DirectionEnum.Neutral)
                    {
                        if (ForceShowNeutral)
                        {
                            return "5";
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        string result = null;
                        if ((Way & (DirectionEnum.Down | DirectionEnum.Back)) != 0)
                        {
                            if(!isLeftSide)
                            {
                                result = "3";
                            }
                            else
                            {
                                result = "1";
                            }
                        }
                        else if ((Way | DirectionEnum.Down) != 0)
                        {
                            result = "2";
                        }
                        else if ((Way & (DirectionEnum.Down | DirectionEnum.Forward)) != 0)
                        {
                            if (!isLeftSide)
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "3";
                            }
                        }
                        else if ((Way | DirectionEnum.Back) != 0)
                        {
                            if (!isLeftSide)
                            {
                                result = "6";
                            }
                            else
                            {
                                result = "4";
                            }
                        }
                        else if ((Way | DirectionEnum.Forward) != 0)
                        {
                            if (!isLeftSide)
                            {
                                result = "4";
                            }
                            else
                            {
                                result = "6";
                            }
                        }
                        else if ((Way & (DirectionEnum.Up | DirectionEnum.Back)) != 0)
                        {
                            if (!isLeftSide)
                            {
                                result = "9";
                            }
                            else
                            {
                                result = "7";
                            }
                        }
                        else if ((Way | DirectionEnum.Up) != 0)
                        {
                            result = "8";
                        }
                        else if ((Way & (DirectionEnum.Up | DirectionEnum.Forward)) != 0)
                        {
                            if (!isLeftSide)
                            {
                                result = "7";
                            }
                            else
                            {
                                result = "9";
                            }
                        }

                        if ((Way | DirectionEnum.Hold) != 0)
                        {
                            return result += "H";
                        }
                        return result.ToString();
                    }
                case Locale.English:
                default:
                    if (Way == DirectionEnum.Neutral)
                    {
                        if (ForceShowNeutral)
                        {
                            return "N";
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        StringBuilder result = new StringBuilder();
                        if ((Way & DirectionEnum.Up) != 0)
                        {
                            result.Append("u");
                        }
                        else if ((Way & DirectionEnum.Down) != 0)
                        {
                            result.Append("d");
                        }

                        if ((Way & DirectionEnum.Up) != 0)
                        {
                            if (result.Length > 0)
                            {
                                result.Append("/");
                            }
                            result.Append("u");
                        }
                        else if ((Way & DirectionEnum.Down) != 0)
                        {
                            if (result.Length > 0)
                            {
                                result.Append("/");
                            }
                            result.Append("d");
                        }

                        if ((Way & DirectionEnum.Forward) != 0)
                        {
                            result.Append("u");
                        }
                        else if ((Way & DirectionEnum.Back) != 0)
                        {
                            result.Append("d");
                        }

                        if ((Way & DirectionEnum.Hold) != 0)
                        {
                            return result.ToString().ToUpper();
                        }
                        return result.ToString();
                    }
            }
        }
        #endregion
        
        
    }
}
