using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB
{
    [DataContract]
    public class Damage
    {
        #region Public Members
        [DataMember]
        public int NormalDamage
        {
            get
            {
                return normalDamage;
            }
            set
            {
                normalDamage = value;
            }
        }
        [IgnoreDataMember]
        public int GroundDamage
        {
            get
            {
                return normalDamage * GROUND_SCALE / NORMAL_SCALE;
            }
        }
        [DataMember(IsRequired = false)]
        public int? CleanDamage
        {
            get
            {
                return cleanDamage;
            }
            set
            {
                cleanDamage = value;
            }
        }
        #endregion

        #region Constructors
        public Damage()
        {
            normalDamage = 0;
            cleanDamage = 0;
        }
        public Damage(int damage)
        {
            normalDamage = damage;
            cleanDamage = null;
        }
        public Damage(int damage, int clean)
        {
            normalDamage = damage;
            cleanDamage = clean;
        }
        public Damage(int damage, int? clean)
        {
            normalDamage = damage;
            cleanDamage = clean;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            if (cleanDamage != null && cleanDamage.HasValue && cleanDamage.Value != normalDamage)
            {
                return string.Format("{0} ({1})", normalDamage, cleanDamage);
            }
            else
            {
                return normalDamage.ToString();
            }
        }
        #endregion

        #region private members
        private int normalDamage;
        private int? cleanDamage;
        private const int NORMAL_SCALE = 135;
        private const int GROUND_SCALE = 100;
        #endregion
    }
}
