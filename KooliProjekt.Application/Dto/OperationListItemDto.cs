using System;

namespace KooliProjekt.Application.Dto
{
    public class OperationListItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal? Cost { get; set; }
        public string CarName { get; set; }
        public string LicensePlate { get; set; }
        public string OperationTypeName { get; set; }
        public string WorkerName { get; set; }
    }
}