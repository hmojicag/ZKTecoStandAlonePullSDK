using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandaloneSDKDemo
{
    [Serializable]
    public class Punches 
    {
        public virtual int id { get; set; }
        public virtual string pin { get; set; }
        //[Reportable(LenFactor = 3)]
        //public virtual Employee employee { get; set; }
        //[Reportable(LenFactor = 3)]
        public virtual DateTime punch_time { get; set; }
        //[Reportable(LenFactor = 3)]
        public virtual int workcode { get; set; }
        //[Reportable(LenFactor = 3)]
        public virtual int workstate { get; set; }

        public virtual string verifycode { get; set; }
        public virtual string operators { get; set; }
        public virtual string operator_reason { get; set; }
        public virtual DateTime? operator_time { get; set; }
        public virtual int IsSelect { get; set; }

        //[Reportable(LenFactor = 3, RelationField = "terminal.terminal_name")]
        //public virtual Terminal terminal { get; set; }

        //[Reportable(LenFactor = 3)]
        public virtual string punch_type { get; set; }

        public virtual int iuser1 { get; set; }

        public virtual int iuser2 { get; set; }

        //for middleware data sync
        public virtual long middleware_id { get; set; }
        public virtual string attendance_event { get; set; }
        public virtual int login_combination { get; set; }
        public virtual int status { get; set; }
        public virtual string annotation { get; set; }
        public virtual int processed { get; set; }

        //public bool Equals(Punches other)
        //{
            //if (Object.ReferenceEquals(other, null)) return false;

            //eturn (employee.id.Equals(other.employee.id) && punch_time.Equals(other.punch_time));
        //}
    }
}
