using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCBusbarInspection.Schemas
{
    public class 마킹기정보
    {
        private String NewHost = String.Empty;

        public 마킹기정보(String host, Int32 port)
        {
            this.NewHost = host;
        }
    }
    public class 마킹기제어 : BindingList<마킹기정보>
    {
        public void Init()
        {

        }
    }
}
