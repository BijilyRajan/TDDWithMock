using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Core
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
    }
}
