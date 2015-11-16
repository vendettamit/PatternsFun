using System.ServiceModel;
using System.ServiceModel.Activation;

namespace WcfRestAuthentication.Services.Api
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public partial class ApiService
    {
        
    }
}