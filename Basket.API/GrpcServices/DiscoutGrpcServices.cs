using Discount.GRPC.Protos;

namespace Basket.API.GrpcServices;

public class DiscoutGrpcServices
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

    public DiscoutGrpcServices(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
    {
        _discountProtoService = discountProtoService;
    }

    public async Task<CouponModel> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest { ProductName = productName };

        return await _discountProtoService.GetDiscountAsync(discountRequest);
    }
}
