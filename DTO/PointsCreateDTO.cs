namespace Fideo.DTO
{
    public class PointsCreateDTO
    {
        public string UserId { get; set; }
        public int BusinessId { get; set; }
        public int Balance { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
