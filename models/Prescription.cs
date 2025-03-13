using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public enum MeasuringUnit{
        mg,
        g,
        kg,
        stk
    }
    public enum TimeUNIT
    {
        minute,
        hour,
        day,
        week,
        month,
        year
    }
    public class Prescription
    {
        public Guid PrescriptionID { get; set; }
        public string reason { get; set; }
        public string Medicine { get; set; }
        public double dose { get; set; }
        public MeasuringUnit unit { get; set; }
        public TimeUNIT Frequency { get; set; }
        public TimeUNIT Duration { get; set; }
        public bool expired { get; set; }

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("HealthJournalID")]
        public Guid HealthJournalID { get; set; }
        public HealthJournal HealthJournal { get; set; }

        [ForeignKey("InjuieID")]
        public Guid? InjuieID { get; set; }
        public Injurie? injurie {get; set;}
    }
}
