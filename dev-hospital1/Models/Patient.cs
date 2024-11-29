using System;
using System.Collections.Generic;

namespace dev_hospital1.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Phoneno { get; set; } = null!;

    public int DoctorId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Doctor Doctor { get; set; } = null!;
}
