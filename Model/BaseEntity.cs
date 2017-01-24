using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerHermesInnovathon.Model
{
    public class BaseEntity
    {
        private static object __sync = new object();
        private static int _nextId = 0;

        public int Id { get; set; }

        protected void SetId()
        {
            lock(__sync)
            {
                this.Id = _nextId++;
            }
        }
    }
}
