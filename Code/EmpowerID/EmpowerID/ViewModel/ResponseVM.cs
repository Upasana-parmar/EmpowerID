namespace EmpowerID.ViewModel
{
    public class ResponseVM
    {
        public ResponseVM() { }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string URL { get; set; }
        public object Result { get; set; }
        public string color { get; set; }
    }
}
