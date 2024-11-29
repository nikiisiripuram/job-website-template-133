using System;
using System.Collections.Generic;

namespace dev_hospital1.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentTime { get; set; }

    public int DepartmentId { get; set; }

    public int PatientId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
