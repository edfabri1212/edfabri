namespace EFAA.BusinessLogic.DTOs;

public class CreateGarmentRequest
{
    
        public int? DesignerId { get; set; }

        public string? SupplierName { get; set; }

        public string? GarmentCode { get; set; }

        public string GarmentName { get; set; } = null!;

        public string? GarmentDescription { get; set; }

        public string? GarmentImage { get; set; }

        public decimal? PriceUnitPurchase { get; set; }

        public decimal? PriceUnitSale { get; set; }

        public int? Stock { get; set; }

        public bool GarmentStatus { get; set; }
    }

    public class UpdateGarmentRequest
    {
        public long GarmentId { get; set; }

        public int? DesignerId { get; set; }

        public string? SupplierName { get; set; }

        public string? GarmentCode { get; set; }

        public string GarmentName { get; set; } = null!;

        public string? GarmentDescription { get; set; }

        public string? GarmentImage { get; set; }

        public decimal? PriceUnitPurchase { get; set; }

        public decimal? PriceUnitSale { get; set; }

        public int? Stock { get; set; }

        public bool GarmentStatus { get; set; }
    }

    public class GarmentResponse
    {
        public long GarmentId { get; set; }

        public string? SupplierName { get; set; }

        public string? GarmentCode { get; set; }

        public string GarmentName { get; set; } = null!;

        public string? GarmentImage { get; set; }

        public decimal? PriceUnitSale { get; set; }

        public int? Stock { get; set; }

        public string DesignerName { get; set; } = null!;
    }

    public class GarmentByIdResponse
    {
        public long GarmentId { get; set; }

        public int? DesignerId { get; set; }

        public string? SupplierName { get; set; }

        public string? GarmentCode { get; set; }

        public string GarmentName { get; set; } = null!;

        public string? GarmentDescription { get; set; }

        public string? GarmentImage { get; set; }

        public decimal? PriceUnitPurchase { get; set; }

        public decimal? PriceUnitSale { get; set; }

        public int? Stock { get; set; }

        public bool GarmentStatus { get; set; }
    }