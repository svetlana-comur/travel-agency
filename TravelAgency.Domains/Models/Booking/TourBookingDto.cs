public class TourBookingDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TourId { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string Status { get; set; } = "Pending";

    public string? FullName { get; set; }
    public string? DepartureCity { get; set; }
    public int Guests { get; set; } = 1;
    public string? PaymentMethod { get; set; }
}