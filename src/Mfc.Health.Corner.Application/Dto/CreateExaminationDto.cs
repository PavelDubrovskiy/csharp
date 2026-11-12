namespace Mfc.Health.Corner.Application.Dto
{
    public class CreateExaminationDto
    {
        public string Group { get; set; }
        public DataDto Data { get; set; }
        public string Ip { get; set; }
    }

    public class DataDto
    {
        public string Status { get; set; }
        public object Result { get; set; }
        public bool Gaz { get; set; }
        public bool Bpbio { get; set; }
        public bool Pulse { get; set; }
        public bool Analyzer { get; set; }
        public bool Bsm { get; set; }
    }

    public class ResultDto
    {
        //Pulse
        public double Spo2 { get; set; }
        public string Plethysm { get; set; }
        public double Pulse { get; set; }

        //Gaz
        public double Ppmco { get; set; }
        public string Cohb { get; set; }

        //Bpbio
        public double Systolic { get; set; }
        public string Diastolic { get; set; }

        //Analizer
        public double Wt { get; set; }
        public string Bmi { get; set; }
        public string Waist_Circ { get; set; }
        public double Hips_Circ { get; set; }
        public string Whr { get; set; }

        //Bsm
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
