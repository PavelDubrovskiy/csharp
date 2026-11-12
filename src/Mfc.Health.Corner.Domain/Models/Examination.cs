namespace Mfc.Health.Corner.Domain.Models
{
    public class Examination
    {
        public string Group { get; set; }
        public Data Data { get; set; }
        public string Ip { get; set; }
    }

    public class Data
    {
        public bool Gaz { get; set; }
        public bool Bpbio { get; set; }
        public bool Pulse { get; set; }
        public bool Analyzer { get; set; }
        public bool Bsm { get; set; }
        public Result Result { get; set; }
        public int CountDone { get; set; }
    }

    public class Result
    {
        public Pulses Pulse { get; set; }
        public Gaz Gaz { get; set; }
        public Bpbio Bpbio { get; set; }
        public Analyzer Analyzer { get; set; }
        public Bsm Bsm { get; set; }
    }

    public class Pulses
    {
        public double Spo2 { get; set; }
        public string Plethysm { get; set; }
        public double Pulse { get; set; }
        public string FullDeviceData { get; set; }
    }

    public class Gaz
    {
        public double Ppmco { get; set; }
        public string Cohb { get; set; }
        public string FullDeviceData { get; set; }
    }

    public class Bpbio
    {
        public double Systolic { get; set; }
        public string Diastolic { get; set; }
        public double Pulse { get; set; }
        public string FullDeviceData { get; set; }
    }

    public class Analyzer
    {
        public double Wt { get; set; }
        public string Bmi { get; set; }
        public string Waist_Circ { get; set; }
        public double Hips_Circ { get; set; }
        public string Whr { get; set; }
        public string FullDeviceData { get; set; }
    }

    public class Bsm
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Bmi { get; set; }
        public string FullDeviceData { get; set; }

    }

    public class Expert
    {
        public int CountDone { get; set; }
    }

    public class Сlient
    {
        public string InBodyId { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
    }
}
