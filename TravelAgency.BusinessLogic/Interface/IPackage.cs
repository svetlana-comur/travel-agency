using TravelAgency.Domains.Models.Package;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IPackage
    {
        List<PackageDto> GetAllPackages();
        PackageDto GetPackageById(int id);

        ResponceMsg CreatePackage(PackageDto dto);
        ResponceMsg UpdatePackage(PackageDto dto);
        ResponceMsg DeletePackage(int id);
    }
}