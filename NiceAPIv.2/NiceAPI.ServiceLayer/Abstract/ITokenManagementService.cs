using NiceAPI.BaseClass;
using NiceAPI.DtoLayer;



namespace NiceAPI.ServiceLayer.Abstract
{
    public interface ITokenManagementService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
    }
}
