namespace EFAA.BusinessLogic.DTOs
{
    public class CreateDesignerRequest
    {
        public string DesignerName { get; set; }
    }

    public class UpdateDesignerRequest
    {
        public int DesignerId { get; set; }
        public string DesignerName { get; set; }
    }

    public class DesignerResponse
    {
        public int DesignerId { get; set; }

        public string DesignerName { get; set; }
    }
}