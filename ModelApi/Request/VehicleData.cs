namespace TutorialMaUI.ModelApi.Request
{
    public class VehicleData
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int VehicleId { get; set; }
        public string VehiclePlate { get; set; }
        public bool IsEnableAcc { get; set; }
        public bool GetAddress { get; set; }
        public bool LimitSpeedByPNC { get; set; }
        public bool LimitByGeocoding { get; set; }
        public int SpeedAllow { get; set; }
        public bool UseSpeakerSoundModule { get; set; }
        public bool ViewDriverInfo { get; set; }
        public VehicleConfigs VehicleConfigs { get; set; }
    }

    public class VehicleConfigs
    {
        public int VMin { get; set; }

        public int MaxVelocityBlue { get; set; }

        public int MaxVelocityRed { get; set; }

        public int MinuteStopLongTime { get; set; }

        public int TimeLossGSM { get; set; }

        public int MinTimeLossGPS { get; set; }

        public int MaxTimeLossGPS { get; set; }

    }
}
