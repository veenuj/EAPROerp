public class MachineTwin
{
    public string MachineId { get; set; } = "ROORKEE_L1_INVERTER_TESTER";
    public double CoreTemperature { get; set; } // Real-time C°
    public double OutputPurity { get; set; } // Sine wave THD %
    public int Rpm { get; set; } // Cooling fan speed
    
    public DateTime LastHeartbeat { get; set; }

    public string HealthStatus { get; set; } = "Optimal"; // Default value prevents the warning
}