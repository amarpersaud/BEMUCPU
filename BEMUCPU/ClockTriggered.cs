using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEMUCPU
{
    public interface ClockTriggered
    {
        void ClockRisingEdge();
        void ClockFallingEdge();
    }
}
