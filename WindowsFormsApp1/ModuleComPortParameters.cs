namespace WindowsFormsApp1
{
    public static class ModuleComPortParameters
    {
        public static string Port { get; set; }
        public static int Baudrate { get; set; }
        public static System.IO.Ports.Parity Parity { get; set; }
        public static bool ConfigurationIsValid { get; set; }
    }
}