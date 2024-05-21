using Discount.Grpc;
using Grpc.Core;

namespace DiscountGrpc.Services;

    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {

            return await base.GetDiscount(request, context);
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {

            return await  base.CreateDiscount(request, context);
        }


        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return await base.UpdateDiscount(request, context);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return await base.DeleteDiscount(request, context);
        }

    }

