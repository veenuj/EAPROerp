namespace EaproERP.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        
        public DateTime Date { get; set; }
        public TimeSpan? PunchInTime { get; set; }
        public TimeSpan? PunchOutTime { get; set; }
        
        public string Status { get; set; } = "Present"; // Present, Late, Half-Day
    }
}